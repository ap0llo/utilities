﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Grynwald.Utilities.Configuration
{
    /// <summary>
    /// Provides extensions methods for <see cref="IConfigurationBuilder"/>
    /// </summary>
    public static class ConfigurationBuilderExtensions
    {
        /// <summary>
        /// Adds the specified settings object to the configuration builder.
        /// </summary>
        /// <remarks>
        /// Adds all values of the object's public properties annotated with <see cref="ConfigurationValueAttribute"/> to the configuration builder.
        /// <para>
        /// Supported property types for settings are:
        /// <list type="bullet">
        ///     <item><description><see cref="string"/></description></item>
        ///     <item><description><see cref="bool"/></description></item>
        ///     <item><description><see cref="int"/></description></item>
        ///     <item><description>Enum types</description></item>
        ///     <item><description>Nullable values of <see cref="bool"/>, <see cref="int"/> and enum types</description></item>
        ///     <item><description>Arrays and <see cref="IEnumerable{T}"/>s of above types.</description></item>
        /// </list>
        /// </para>
        /// <para>
        /// When <paramref name="settingsObject"/> is <c>null</c>, no settings are added.
        /// </para>
        /// </remarks>
        public static IConfigurationBuilder AddObject(this IConfigurationBuilder builder, object? settingsObject)
        {
            if (settingsObject is null)
                return builder;

            var settings = GetSettingsDictionary(settingsObject);
            return builder.AddInMemoryCollection(settings);
        }


        internal static Dictionary<string, string> GetSettingsDictionary(object settingsObject)
        {
            var settings = new Dictionary<string, string>();
            foreach (var property in settingsObject.GetType().GetProperties())
            {
                var attribute = property.GetCustomAttribute<ConfigurationValueAttribute>();
                if (attribute is null)
                    continue;

                if (String.IsNullOrEmpty(attribute.Key))
                    continue;

                if (!IsSupportedPropertyType(property.PropertyType))
                    throw new InvalidOperationException($"Property type {property.PropertyType} of property '{property.Name}' is not supported");

                if (property.GetMethod is null)
                    throw new InvalidOperationException($"Property '{property.Name}' does not have a getter");

                var value = property.GetMethod.Invoke(settingsObject, Array.Empty<object>());

                if (value is null)
                    continue;

                if (IsSupportedCollectionType(property.PropertyType))
                {
                    int i = 0;
                    foreach (var item in (IEnumerable)value)
                    {
                        settings.Add($"{attribute.Key}:{i++}", Convert.ToString(item)!);
                    }
                }
                else
                {
                    settings.Add(attribute.Key, Convert.ToString(value)!);

                }
            }

            return settings;
        }

        public static bool IsSupportedPropertyType(Type propertyType)
        {
            return IsSupportedSimpleType(propertyType) || IsSupportedCollectionType(propertyType);
        }


        private static bool IsSupportedSimpleType(Type propertyType)
        {
            if (propertyType == typeof(string))
                return true;

            if (propertyType == typeof(bool))
                return true;

            if (propertyType == typeof(int))
                return true;

            if (propertyType.IsEnum)
                return true;

            // support nullable value types 
            if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return IsSupportedPropertyType(propertyType.GetGenericArguments().Single());
            }


            return false;
        }

        private static bool IsSupportedCollectionType(Type propertyType)
        {
            if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                return IsSupportedSimpleType(propertyType.GetGenericArguments().Single());
            }

            if (propertyType.IsArray && propertyType.GetArrayRank() == 1)
            {
                return IsSupportedSimpleType(propertyType.GetElementType()!);
            }

            return false;
        }

    }
}
