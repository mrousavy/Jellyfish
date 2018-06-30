using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Jellyfish.Extensions
{
    public static class AttributeReflector
    {
        public static IEnumerable<PropertyInfo> PropertiesWithAttribute(this Type classType, Type attributeType)
        {
            var properties = classType.GetProperties();
            return properties.Where(p => p.CustomAttributes.Any(a => a.AttributeType == attributeType));
        }
        public static IEnumerable<FieldInfo> FieldsWithAttribute(this Type classType, Type attributeType)
        {
            var fields = classType.GetFields();
            return fields.Where(f => f.CustomAttributes.Any(a => a.AttributeType == attributeType));
        }
    }
}