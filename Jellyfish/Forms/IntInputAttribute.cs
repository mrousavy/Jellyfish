using Jellyfish.Annotations;
using System;

namespace Jellyfish.Forms
{
    /// <summary>
    ///     NOT IMPLEMENTED
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class IntInputAttribute : Attribute, IFormInput<int>
    {
        public IntInputAttribute([NotNull] string text, [NotNull] Func<int, int> formatter)
        {
            Text = text;
            Formatter = formatter;
        }
        public IntInputAttribute([NotNull] string text) : this(text, t => t)
        {
        }
        public IntInputAttribute() : this("")
        {
        }

        public Func<int, int> Formatter { get; set; }
        public string Text { get; set; }
    }
}
