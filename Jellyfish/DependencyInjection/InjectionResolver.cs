﻿using System;
using System.Linq;
using Jellyfish.Attributes;
using Jellyfish.Extensions;

namespace Jellyfish.DependencyInjection
{
    public class InjectionResolver
    {
        /// <summary>
        ///     Inject all properties for the type `<see cref="T" />` with the found injections
        /// </summary>
        /// <typeparam name="T">The type to inject properties into</typeparam>
        /// <param name="reference">A reference to the type to inject into (or null if static properties)</param>
        /// <param name="injector">The injector instance to use</param>
        public static void InjectProperties<T>(T reference, IInjector injector)
        {
            var type = typeof(T);
            var attributeType = typeof(DependencyAttribute);
            var properties = type.PropertiesWithAttribute(attributeType);
            foreach (var property in properties)
            {
                var attribute = property.CustomAttributes.SingleOrDefault(a => a.AttributeType == attributeType);
                if (attribute != null)
                {
                    var arguments = attribute.ConstructorArguments;
                    var typeArgument = arguments.Single(a => a.ArgumentType == typeof(Type));
                    var paramsArgument = arguments.Single(a => a.ArgumentType == typeof(object[]));
                    var subType = typeArgument.Value as Type;
                    var parameters = paramsArgument.Value as object[];

                    injector.Register(property.PropertyType, subType, parameters);
                    var val = injector.Initialize(property.PropertyType);
                    property.SetValue(reference, val);
                }
            }
        }

        /// <summary>
        ///     Inject all fields for the type `<see cref="T" />` with the found injections
        /// </summary>
        /// <typeparam name="T">The type to inject fields into</typeparam>
        /// <param name="reference">A reference to the type to inject into (or null if static fields)</param>
        /// <param name="injector">The injector instance to use</param>
        public static void InjectFields<T>(T reference, IInjector injector)
        {
            var type = typeof(T);
            var attributeType = typeof(DependencyAttribute);
            var fields = type.FieldsWithAttribute(attributeType);
            foreach (var field in fields)
            {
                var attribute = field.CustomAttributes.SingleOrDefault(a => a.AttributeType == attributeType);
                if (attribute != null)
                {
                    var arguments = attribute.ConstructorArguments;
                    var typeArgument = arguments.Single(a => a.ArgumentType == typeof(Type));
                    var paramsArgument = arguments.Single(a => a.ArgumentType == typeof(object[]));
                    var subType = typeArgument.Value as Type;
                    var parameters = paramsArgument.Value as object[];

                    injector.Register(field.FieldType, subType, parameters);
                    var val = injector.Initialize(field.FieldType);
                    field.SetValue(reference, val);
                }
            }
        }
    }
}