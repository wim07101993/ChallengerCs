using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using DataConverter.Core.Converters;

namespace DataConverter.Shared.ConvertedValueTypes
{
    public class ConvertedValue<T> : AsyncBindableBase, IConvertedValue, INotifyDataErrorInfo
    {
        private readonly DelayedInvoker _delayedInvoker = new DelayedInvoker(500);

        private T _value;
        private bool _hasErrors;
        private string _validationError;

        public ConvertedValue(Func<Action, Task> uiThreadInvoker)
            : base(uiThreadInvoker)
        {
        }

        #region PROPERTIES

        public IConverter Converter { get; set; }

        public T Value
        {
            get => _value;
            set
            {
                lock (Lock)
                {
                    // For some reason the two-way binding of UWP tries to update the value again
                    // when PropertyChanged is called.
                    if (IsPropertyChanging && ChangingProperty == nameof(Value))
                        return;
                }

                _ = SetProperty(ref _value, value);
                _delayedInvoker.Update(() => _ = UpdateBytesFromValueAsync(value));
            }
        }

        public bool HasErrors => _hasErrors;

        public string Error => _validationError ?? $"Could not converter {Name ?? typeof(T).Name}";

        object IConvertedValue.Value
        {
            get => Value;
            set => Value = (T)value;
        }

        public virtual string Name
        {
            get => Value switch
            {
                ushort _ => "UInt16",
                short _ => "Int16",
                uint _ => "UInt32",
                int _ => "Int32",
                ulong _ => "UInt64",
                long _ => "Int64",
                float _ => "Float32",
                double _ => "Float64",
                decimal _ => "Float128",
                _ => "UTF8 string",
            };
        }

        #endregion PROPERTIES

        /// <summary>
        ///     Updates the <see cref="Value" /> property by converting the <paramref name="bytes"
        ///     /> to <see cref="T" /> without checking validation. (to prevent reëntrance.)
        /// </summary>
        /// <param name="bytes">Value to set</param>
        public async Task UpdateAsync(byte[] bytes)
        {
            bool success;
            try
            {
                _value = FromBytes(bytes);
                success = true;
            }
            catch (Exception e)
            {
                Trace.WriteLine($"Failed to convert to {Name ?? typeof(T).Name}: {e.Message}");
                _value = default;
                success = false;
                _ = await SetErrorAsync($"Failed to convert to {Name ?? typeof(T).Name}");
            }

            await RaisePropertyChangedAsync(nameof(Value));
            _ = await SetHasErrorsAsync(!success);
        }

        public async Task UpdateBytesFromValueAsync(T value)
        {
            try
            {
                var bytes = ToBytes(value);

                _ = await SetHasErrorsAsync(false);
                OnValueChanged(this, bytes);
            }
            catch (Exception e)
            {
                Trace.WriteLine($"Failed to parse {Name ?? typeof(T).Name}: {e.Message}");

                _ = await SetHasErrorsAsync(true);
                _ = await SetErrorAsync($"Failed to convert {Name ?? typeof(T).Name}");
            }
        }

        public Task UpdateBytesFromValueAsync(object value) => UpdateBytesFromValueAsync((T)value);

        private async Task<bool> SetHasErrorsAsync(bool value)
        {
            if (!await SetPropertyAsync(ref _hasErrors, value))
                return false;

            if (value)
                _ = await SetErrorAsync(null);

            await RaiseErrorsChangedAsync(nameof(HasErrors));
            return true;
        }

        protected Task<bool> SetErrorAsync(string value) => SetPropertyAsync(ref _validationError, value, nameof(Error));

        protected virtual Task RaiseErrorsChangedAsync([CallerMemberName] string propertyName = null)
            => UiThreadInvoker(() => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Value))));

        protected virtual byte[] ToBytes(T value) => Converter.GetBytes(value);

        protected virtual T FromBytes(byte[] bytes) => Converter.GetValue<T>(bytes);

        public IEnumerable GetErrors(string propertyName)
        {
            yield return Error;
        }

        public event EventHandler<byte[]> OnValueChanged;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    }

    public interface IConvertedValue : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        IConverter Converter { get; set; }

        object Value { get; set; }

        string Error { get; }

        string Name { get; }

        /// <summary>
        ///     Updates the <see cref="Value" /> property by converting the <paramref name="bytes"
        ///     /> to <see cref="T" /> without checking validation. (to prevent reëntrance.)
        /// </summary>
        /// <param name="bytes">Value to set</param>
        Task UpdateAsync(byte[] bytes);

        Task UpdateBytesFromValueAsync(object value);

        event EventHandler<byte[]> OnValueChanged;
    }
}
