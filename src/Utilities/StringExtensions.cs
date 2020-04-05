using System;
using System.IO;

namespace Grynwald.Utilities
{
    /// <summary>
    /// Extension methods for <see cref="String"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Creates a in-memory stream and writes the string's content to it.
        /// </summary>
        /// <param name="s">The value to write to the stream.</param>
        /// <returns>
        /// Returns a new in-memory stream which content is equivalent to the specified string.
        /// The resulting stream's reading position will be 0.
        /// </returns>
        /// <seealso cref="MemoryStream"/>
        public static Stream ToStream(this string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        // Hide Methods from projects targeting .NET Core 2.0 or later / .NET Standard 2.1 or later
        // because for that target, String.StartsWith(char) and String.EndsWith(char) are built-in
#if !(REFERENCE_ASSEMBLY && (NETCOREAPP2_0 || NETCOREAPP2_1 || NETSTANDARD2_1))
        /// <summary>
        /// Determines if the string starts with the specified character.
        /// </summary>
        /// <remarks>
        /// This method is not included in the reference assembly for the following frameworks
        /// because a equivalent extension method, is available there and using the built-in method is preferable:
        /// <list type="bullet">
        ///     <item><description>.NET Core 2.0 or later</description></item>
        ///     <item><description>.NET Standard 2.1 or later</description></item>
        /// </list>       
        /// </remarks>
        /// <param name="str">The string which's first character to check.</param>
        /// <param name="c">The character to compare to the string's first character.</param>
        /// <returns>Returns true if the string has at least one character and the first character matches <paramref name="c"/>.</returns>
        [HiddenFromReferenceAssembly("netcoreapp2.0")]
        [HiddenFromReferenceAssembly("netstandard2.1")]
        public static bool StartsWith(this string str, char c)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            return str.Length > 0 && str[0] == c;
        }

        /// <summary>
        /// Determines if the string ends with the specified character.
        /// </summary>
        /// <remarks>
        /// This method is not included in the reference assembly for the following frameworks
        /// because a equivalent extension method, is available there and using the built-in method is preferable:
        /// <list type="bullet">
        ///     <item><description>.NET Core 2.0 or later</description></item>
        ///     <item><description>.NET Standard 2.1 or later</description></item>
        /// </list>       
        /// </remarks>
        /// <param name="str">The string which's last character to check.</param>
        /// <param name="c">The character to compare to the string's last character.</param>
        /// <returns>Returns true if the string has at least one character and the last character matches <paramref name="c"/>.</returns>
        [HiddenFromReferenceAssembly("netcoreapp2.0")]
        [HiddenFromReferenceAssembly("netstandard2.1")]
        public static bool EndsWith(this string str, char c)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));


            return str.Length > 0 && str[str.Length - 1] == c;
        }

#endif
        /// <summary>
        /// Removes leading and trailing empty lines from the string.
        /// </summary>
        public static string TrimEmptyLines(this string value)
        {
            // trim start
            {
                // find end of leading whitespace 
                // band the last index of a new line character within that whitespace
                var endOfWhiteSpace = -1;
                var lastNewLine = -1;
                for (var i = 0; i < value.Length; i++)
                {
                    if (value[i] == '\r' || value[i] == '\n')
                    {
                        lastNewLine = i;
                    }

                    if (!char.IsWhiteSpace(value[i]))
                    {
                        endOfWhiteSpace = i;
                        break;
                    }
                }

                // no leading whitespace => keep original value
                // no newline in whitespace => keep original value
                // otherwise:
                //   remove leading whitespace until the last newline character                 
                if (endOfWhiteSpace >= 0 && lastNewLine >= 0)
                {
                    value = value.Remove(0, lastNewLine + 1);
                }
            }

            // trim end
            {
                // find start of trailing whitespace (search from the end)
                // and the first new line within that whitespace
                var startOfWhiteSpace = -1;
                var firstNewLine = -1;
                for (var i = value.Length - 1; i > 0; i--)
                {
                    if (value[i] == '\r' || value[i] == '\n')
                    {
                        firstNewLine = i;
                    }

                    if (!char.IsWhiteSpace(value[i]))
                    {
                        startOfWhiteSpace = i;
                        break;
                    }
                }

                if (startOfWhiteSpace >= 0 && firstNewLine >= 0)
                {
                    // if the first new line is a '\r' followed by '\n', 
                    // move increment by one character and treat \r\n as the line break
                    if (value[firstNewLine] == '\r' && firstNewLine + 1 < value.Length && value[firstNewLine + 1] == '\n')
                        firstNewLine += 1;

                    // remove all chars after the line break
                    // do nothing if the line break is the last character of the string
                    if (firstNewLine < value.Length - 1)
                    {
                        value = value.Remove(firstNewLine + 1);
                    }
                }
            }

            return value;
        }
    }
}
