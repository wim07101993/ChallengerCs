using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using DataConverter.Core.Converters;

using Prism.Mvvm;

namespace DataConverter.Shared.ConvertedValueTypes
{
    public class ConvertedValue<T> : BindableBase, IConvertedValue, INotifyDataErrorInfo
    {
        private T _value;
        private bool _hasErrors;
        private string _validationError;

        public IConverter Converter { get; set; }

        public T Value
        {
            get => _value;
            set
            {
                if (EqualityComparer<T>.Default.Equals(Value, value))
                    return;

                try
                {
                    var bytes = ToBytes(value);
                    HasErrors = false;
                    _value = value;
                    RaisePropertyChanged();
                    OnValueChanged(this, bytes);
                }
                catch (Exception e)
                {
                    Trace.WriteLine($"Failed to parse {Name ?? typeof(T).Name}: {e.Message}");
                    HasErrors = true;
                    Error = $"Failed to convert {Name ?? typeof(T).Name}";
                    _value = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool HasErrors
        {
            get => _hasErrors;
            private set
            {
                if (!SetProperty(ref _hasErrors, value))
                    return;

                if (value)
                    Error = null;

                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Value)));
            }
        }

        public string Error
        {
            get => _validationError ?? $"Could not converter {Name ?? typeof(T).Name}";
            set => SetProperty(ref _validationError, value);
        }

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

        /// <summary>
        ///     Updates the <see cref="Value" /> property by converting the <paramref name="bytes"
        ///     /> to <see cref="T" /> without checking validation. (to prevent reëntrance.)
        /// </summary>
        /// <param name="bytes">Value to set</param>
        public void Update(byte[] bytes)
        {
            bool success;
            try
            {
                _value = FromBytes(bytes);
                success = true;
            }
            catch
            {
                _value = default;
                success = false;
                Error = $"Failed to convert to {Name ?? typeof(T).Name}";
            }

            RaisePropertyChanged(nameof(Value));
            HasErrors = !success;
        }

        public new void RaisePropertyChanged(string propertyName) => base.RaisePropertyChanged(propertyName);

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
        void Update(byte[] bytes);

        void RaisePropertyChanged(string propertyName);

        event EventHandler<byte[]> OnValueChanged;
    }
}
