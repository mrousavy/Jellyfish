using System;
using System.Security;

namespace Jellyfish.Wpf.Forms
{
    /// <summary>
    ///     An Attribute applied on <see cref="SecureString" /> objects (Passwords) generating a <see cref="PasswordBox" />
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class PasswordInputAttribute : Attribute, IFormInput<SecureString>
    {
        public PasswordInputAttribute(string text)
        {
            Text = text;
        }

        public PasswordInputAttribute() : this("")
        { }

        public string Text { get; set; }
    }
}