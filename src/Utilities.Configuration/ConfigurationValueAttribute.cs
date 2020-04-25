using System;

namespace Grynwald.Utilities.Configuration
{
    /// <summary>
    /// Marks a property as setting to be imported through <see cref="ConfigurationBuilderExtensions.AddObject"/>.    
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ConfigurationValueAttribute : Attribute
    {
        /// <summary>
        /// The property's settings key.
        /// </summary>
        /// <remarks>
        /// Uses the same format as the in-memory configuration provider.
        /// Hierarchical keys must separated by <c>:</c>, e.g. <c>setting:subkey</c>
        /// </remarks>
        /// <seealso href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1#memory-configuration-provider">Memory configuration provider (Microsoft Docs)</seealso>
        public string Key { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="ConfigurationValueAttribute"/>.
        /// </summary>
        /// <param name="key">Sets the property's settings key. (see <see cref="Key"/>).</param>
        public ConfigurationValueAttribute(string key)
        {
            Key = key;
        }
    }
}
