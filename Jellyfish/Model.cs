using System.Runtime.CompilerServices;

namespace Jellyfish
{
    /// <summary>
    ///     The base class of any Model in the MVVM pattern
    /// </summary>
    public abstract class Model
    {
        protected Model([CallerMemberName] string callerName = "")
        {
        }
    }
}
