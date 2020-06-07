using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Challenger.Shared
{
    /// <summary>Implementation of <see cref="INotifyPropertyChanged" /> to simplify models.</summary>
    public abstract class AsyncBindableBase : INotifyPropertyChanged
    {
        public AsyncBindableBase(Func<Action, Task> uiThreadInvoker = null)
        {
            UiThreadInvoker = uiThreadInvoker ?? new Func<Action, Task>(x => Task.Run(x));
        }

        protected object Lock { get; } = new object();
        public virtual bool IsPropertyChanging { get; private set; }
        public virtual string ChangingProperty { get; private set; }

        protected Func<Action, Task> UiThreadInvoker { get; }

        /// <summary>
        ///     Checks if a property already matches a desired value. Sets the property and notifies
        ///     listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">     Reference to a property with both getter and setter.</param>
        /// <param name="value">       Desired value for the property.</param>
        /// <param name="propertyName">
        ///     Name of the property used to notify listeners. This value is optional and can be
        ///     provided automatically when invoked from compilers that support CallerMemberName.
        /// </param>
        /// <returns>
        ///     True if the value was changed, false if the existing value matched the desired value.
        /// </returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            _ = RaisePropertyChangedAsync(propertyName);
            return true;
        }

        /// <summary>
        ///     Checks if a property already matches a desired value. Sets the property and notifies
        ///     listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">     Reference to a property with both getter and setter.</param>
        /// <param name="value">       Desired value for the property.</param>
        /// <param name="propertyName">
        ///     Name of the property used to notify listeners. This value is optional and can be
        ///     provided automatically when invoked from compilers that support CallerMemberName.
        /// </param>
        /// <param name="onChanged">   
        ///     Action that is called after the property value has been changed.
        /// </param>
        /// <returns>
        ///     True if the value was changed, false if the existing value matched the desired value.
        /// </returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            onChanged?.Invoke();
            _ = RaisePropertyChangedAsync(propertyName);
            return true;
        }

        /// <summary>
        ///     Checks if a property already matches a desired value. Sets the property and notifies
        ///     listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">     Reference to a property with both getter and setter.</param>
        /// <param name="value">       Desired value for the property.</param>
        /// <param name="propertyName">
        ///     Name of the property used to notify listeners. This value is optional and can be
        ///     provided automatically when invoked from compilers that support CallerMemberName.
        /// </param>
        /// <returns>
        ///     True if the value was changed, false if the existing value matched the desired value.
        /// </returns>
        protected virtual Task<bool> SetPropertyAsync<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return Task.FromResult(false);

            storage = value;
            return Task.Run(async () =>
            {
                await RaisePropertyChangedAsync(propertyName);
                return true;
            });
        }

        /// <summary>
        ///     Checks if a property already matches a desired value. Sets the property and notifies
        ///     listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">     Reference to a property with both getter and setter.</param>
        /// <param name="value">       Desired value for the property.</param>
        /// <param name="propertyName">
        ///     Name of the property used to notify listeners. This value is optional and can be
        ///     provided automatically when invoked from compilers that support CallerMemberName.
        /// </param>
        /// <param name="onChanged">   
        ///     Action that is called after the property value has been changed.
        /// </param>
        /// <returns>
        ///     True if the value was changed, false if the existing value matched the desired value.
        /// </returns>
        protected virtual Task<bool> SetPropertyAsync<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return Task.FromResult(false);

            storage = value;
            onChanged?.Invoke();
            return Task.Run(async () =>
            {
                await RaisePropertyChangedAsync(propertyName);
                return true;
            });
        }

        /// <summary>Raises this object's PropertyChanged event.</summary>
        /// <param name="propertyName">
        ///     Name of the property used to notify listeners. This value is optional and can be
        ///     provided automatically when invoked from compilers that support <see
        ///     cref="CallerMemberNameAttribute" />.
        /// </param>
        protected Task RaisePropertyChangedAsync([CallerMemberName] string propertyName = null)
            => RaisePropertyChangedAsync(new PropertyChangedEventArgs(propertyName));

        /// <summary>Raises this object's PropertyChanged event.</summary>
        /// <param name="args">The PropertyChangedEventArgs</param>
        protected virtual async Task RaisePropertyChangedAsync(PropertyChangedEventArgs args)
        {
            lock (Lock)
            {
                IsPropertyChanging = true;
                ChangingProperty = args.PropertyName;
            }

            await UiThreadInvoker.Invoke(() => PropertyChanged?.Invoke(this, args));

            lock (Lock)
            {
                IsPropertyChanging = false;
                ChangingProperty = null;
            }
        }

        /// <summary>Occurs when a property value changes.</summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
