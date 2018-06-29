using System;
using System.Globalization;

namespace Jellyfish.Forms
{
    /// <summary>
    ///     NOT IMPLEMENTED
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DoubleInputAttribute : Attribute, IFormInput<double>
    {
        public DoubleInputAttribute(string text, Func<double, string> formatter)
        {
            Text = text;
            Formatter = formatter;
        }

        public DoubleInputAttribute(string text) : this(text, t => t.ToString(CultureInfo.InvariantCulture))
        {
        }

        public DoubleInputAttribute() : this("")
        {
        }

        /// <summary>
        ///     The formatter to use for custom formatting the field
        /// </summary>
        /// <example>
        ///     You can define a formatter to display hours like this:
        ///     var formatter = val => $"{val}h";
        /// </example>
        public Func<double, string> Formatter { get; set; }

        public string Text { get; set; }
    }
}