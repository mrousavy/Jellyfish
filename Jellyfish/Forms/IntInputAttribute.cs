using System;

namespace Jellyfish.Forms
{
    /// <summary>
    ///     NOT IMPLEMENTED
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class IntInputAttribute : Attribute, IFormInput<int>
    {
        public IntInputAttribute(string text, Func<int, string> formatter)
        {
            Text = text;
            Formatter = formatter;
        }

        public IntInputAttribute(string text) : this(text, t => t.ToString())
        {
        }

        public IntInputAttribute() : this("")
        {
        }

        /// <summary>
        ///     The formatter to use for custom formatting the field
        /// </summary>
        /// <example>
        ///     You can define a formatter to display hours like this:
        ///     var formatter = val => $"{val}h";
        /// </example>
        public Func<int, string> Formatter { get; set; }

        public string Text { get; set; }
    }
}