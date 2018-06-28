using System.ComponentModel;
using System.Runtime.CompilerServices;
using Jellyfish.Properties;

namespace Jellyfish
{
    /// <inheritdoc />
    /// <summary>
    ///     The observable base class for every view model providing a rich
    ///     <see cref="T:System.ComponentModel.INotifyPropertyChanged" /> wrapper
    /// </summary>
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        /// <inheritdoc />
        /// <summary>
        ///     The event on property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Raise the <see cref="PropertyChanged" /> event
        /// </summary>
        /// <param name="propertyName">The caller member name of the property (auto-set)</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///     Set a property and raise the <see cref="PropertyChanged" /> event
        /// </summary>
        /// <typeparam name="T">The type of the Property</typeparam>
        /// <param name="field">A reference to the backing field from the property</param>
        /// <param name="value">The new value being set</param>
        /// <param name="callerName">The caller member name of the property (auto-set)</param>
        protected void Set<T>(ref T field, T value, [CallerMemberName] string callerName = null)
        {
            if (field?.Equals(value) == true)
                return;

            field = value;
            OnPropertyChanged(callerName);
        }
    }
}