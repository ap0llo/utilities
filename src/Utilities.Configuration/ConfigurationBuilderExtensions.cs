using System;
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
        /// Adds all values of properties of the object annotated with <see cref="ConfigurationValueAttribute"/>
        /// to the configuration builder.
        /// <para>
        /// Supported property types for settings are
        /// <list type="bullet">
        ///     <item><description><see cref="string"/></description></item>
        ///     <item><description><see cref="bool"/></description></item>
        ///     <item><description>Nullable <see cref="bool"/> values (<c>bool?</c>)</description></item>
        ///     <item><description>Enum types</description></item>
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

                if (value is object)
                    settings.Add(attribute.Key, Convert.ToString(value));
            }

            return settings;
        }

        internal static bool IsSupportedPropertyType(Type propertyType)
        {
            if (propertyType == typeof(string))
                return true;

            if (propertyType == typeof(bool))
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
    }
}
