using System;
using System.Text.RegularExpressions;

namespace Grynwald.Utilities
{
    /// <summary>
    /// Represents a wildcard expression.
    /// </summary>
    public sealed class Wildcard : IEquatable<Wildcard>
    {
        readonly Regex m_Regex;
        readonly string m_Pattern;

        /// <summary>
        /// Initializes a new instance of <see cref="Wildcard"/> with the specified pattern
        /// </summary>
        /// <param name="pattern">The wildcard pattern. Supported placeholders are '*' (any number of characters) and '?' (a single character)</param>
        public Wildcard(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
                throw new ArgumentException("Value must not be null or empty", nameof(pattern));

            m_Pattern = pattern;
            m_Regex = new Regex(
                $"^{Regex.Escape(pattern).Replace(@"\*", ".*").Replace(@"\?", ".")}$",
                RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }


        /// <inheritdoc />
        public override int GetHashCode() => StringComparer.Ordinal.GetHashCode(m_Pattern);

        /// <inheritdoc />
        public override bool Equals(object obj) => Equals(obj as Wildcard);

        /// <inheritdoc />
        public bool Equals(Wildcard other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return StringComparer.Ordinal.Equals(m_Pattern, other.m_Pattern);
        }

        /// <summary>
        /// Determines whether the wildcard matches the specified input string.
        /// </summary>
        /// <example>
        /// <code language="csharp"><![CDATA[
        /// var wildcard = new Wildcard("Foo*");
        ///
        /// Debug.Assert(wildcard.IsMatch("Foobar"));
        /// Debug.Assert(!wildcard.IsMatch("Bar"));
        /// ]]>
        /// </code>
        /// </example>
        public bool IsMatch(string value) => m_Regex.IsMatch(value);

    }
}
