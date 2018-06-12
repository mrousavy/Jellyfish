using System;

namespace Jellyfish.Forms
{
    /// <summary>
    ///     Any user input form's input field
    /// </summary>
    public interface IFormInput<T>
    {
        /// <summary>
        ///     The text or question to display next to the input field
        /// </summary>
        string Text { get; set; }
        /// <summary>
        ///     The formatter to use for custom formatting the field
        /// </summary>
        /// <example>
        ///     You can define a formatter to display hours like this:
        /// 
        ///     var formatter = val => $"{val}h";
        /// </example>
        Func<T, T> Formatter { get; set; }
    }
}
