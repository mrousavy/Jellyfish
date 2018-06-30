using Jellyfish.DependencyInjection;

namespace Jellyfish
{
    /// <inheritdoc />
    /// <summary>
    ///     The base class of any View-Model in the MVVM pattern providing boilerplate View-Model code (inherits from
    ///     <see cref="ObservableObject" />)
    /// </summary>
    public abstract class ViewModel : ObservableObject
    {
        protected ViewModel()
        {
            InjectionResolver.InjectProperties(this);
            InjectionResolver.InjectFields(this);
        }
    }
}