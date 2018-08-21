using System;

namespace Jellyfish.Wpf.Forms
{
    /// <summary>
    ///     An Attribute applied on <see cref="bool" /> objects generating a <see cref="CheckBox" />
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class CheckInputAttribute : Attribute, IFormInput<bool>
    {
        public CheckInputAttribute(string text)
        {
            Text = text;
        }

        public CheckInputAttribute() : this("")
        { }

        public string Text { get; set; }
    }
}