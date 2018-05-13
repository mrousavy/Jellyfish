using System;
using System.Runtime.CompilerServices;

namespace Jellyfish
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyAttribute : Attribute
    {
        public PropertyAttribute([CallerMemberName] string propertyName = null)
        {
            PropertyName = propertyName;
            Console.WriteLine(PropertyName);
        }

        public string PropertyName { get; set; }
    }
}
