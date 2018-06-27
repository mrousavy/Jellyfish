using System.Runtime.CompilerServices;

namespace Jellyfish
{
    /// <inheritdoc />
    /// <summary>
    ///     The base class of any View-Model in the MVVM pattern
    /// </summary>
    public abstract class ViewModel : ObservableObject
    {
        protected ViewModel([CallerMemberName] string callerName = "")
        {
        }
    }
}
