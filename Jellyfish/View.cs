using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Jellyfish
{
    /// <summary>
    ///     The base class of any View (<see cref="UserControl"/> or <see cref="Window"/>) in the MVVM pattern
    /// </summary>
    public abstract class View
    {
        protected View([CallerMemberName] string callerName = "")
        {
        }
    }
}
