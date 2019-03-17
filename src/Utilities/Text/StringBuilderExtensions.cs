using System;
using System.Collections.Generic;
using System.Text;

namespace Grynwald.Utilities.Text
{
    /// <summary>
    /// Extension methods for <see cref="StringBuilder"/>.
    /// </summary>
    public static class StringBuilderExtensions
    {

        // Hide AppendJoin() methods from projects targeting .NET Core 2.0 or later as AppendJoin is available as built-in functionality.
#if !(REFERENCE_ASSEMBLY && NETCOREAPP2_0)

        /// <summary>
        /// Appends the members of a collection, separated by the specified separator.
        /// </summary>
        /// <remarks>
        /// AppendJoin() was added to <see cref="StringBuilder"/> in .NET Core 2.0. This
        /// extension method makes it available on earlier versions and to projects
        /// targeting .NET Standard or .NET Framework.
        /// <para>
        /// This method is excluded from the reference assembly for .NET Core 2.0 so
        /// projects targeting this will use the built-in method.
        /// </para>
        /// </remarks>
        /// <typeparam name="T">The type of the members of values.</typeparam>
        /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance to append the value to.</param>
        /// <param name="separator">The separator to insert between the values.</param>
        /// <param name="values">The values to concatenate.</param>
        /// <returns>Returns the specified <see cref="StringBuilder"/>.</returns>
        public static StringBuilder AppendJoin<T>(this StringBuilder stringBuilder, string separator, IEnumerable<T> values)
        {
            stringBuilder.Append(String.Join(separator, values));
            return stringBuilder;
        }

        /// <summary>
        /// Appends the members of a collection, separated by the specified separator.
        /// </summary>
        /// <remarks>
        /// AppendJoin() was added to <see cref="StringBuilder"/> in .NET Core 2.0. This
        /// extension method makes it available on earlier versions and to projects
        /// targeting .NET Standard or .NET Framework.
        /// <para>
        /// This method is excluded from the reference assembly for .NET Core 2.0 so
        /// projects targeting this will use the built-in method.
        /// </para>
        /// </remarks>
        /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance to append the value to.</param>
        /// <param name="separator">The separator to insert between the values.</param>
        /// <param name="values">The values to concatenate.</param>
        /// <returns>Returns the specified <see cref="StringBuilder"/>.</returns>
        public static StringBuilder AppendJoin(this StringBuilder stringBuilder, string separator, params string[] values)
        {
            stringBuilder.Append(String.Join(separator, values));
            return stringBuilder;
        }

        /// <summary>
        /// Appends the members of a collection, separated by the specified separator.
        /// </summary>
        /// <remarks>
        /// AppendJoin() was added to <see cref="StringBuilder"/> in .NET Core 2.0. This
        /// extension method makes it available on earlier versions and to projects
        /// targeting .NET Standard or .NET Framework.
        /// <para>
        /// This method is excluded from the reference assembly for .NET Core 2.0 so
        /// projects targeting this will use the built-in method.
        /// </para>
        /// </remarks>
        /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance to append the value to.</param>
        /// <param name="separator">The separator to insert between the values.</param>
        /// <param name="values">The values to concatenate.</param>
        /// <returns>Returns the specified <see cref="StringBuilder"/>.</returns>
        public static StringBuilder AppendJoin(this StringBuilder stringBuilder, string separator, params object[] values)
        {
            stringBuilder.Append(String.Join(separator, values));
            return stringBuilder;
        }

        /// <summary>
        /// Appends the members of a collection, separated by the specified separator.
        /// </summary>
        /// <remarks>
        /// AppendJoin() was added to <see cref="StringBuilder"/> in .NET Core 2.0. This
        /// extension method makes it available on earlier versions and to projects
        /// targeting .NET Standard or .NET Framework.
        /// <para>
        /// This method is excluded from the reference assembly for .NET Core 2.0 so
        /// projects targeting this will use the built-in method.
        /// </para>
        /// </remarks>
        /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance to append the value to.</param>
        /// <param name="separator">The separator to insert between the values.</param>
        /// <param name="values">The values to concatenate.</param>
        /// <returns>Returns the specified <see cref="StringBuilder"/>.</returns>
        public static StringBuilder AppendJoin(this StringBuilder stringBuilder, char separator, params object[] values)
        {
            stringBuilder.Append(String.Join(separator.ToString(), values));
            return stringBuilder;
        }

        /// <summary>
        /// Appends the members of a collection, separated by the specified separator.
        /// </summary>
        /// <remarks>
        /// AppendJoin() was added to <see cref="StringBuilder"/> in .NET Core 2.0. This
        /// extension method makes it available on earlier versions and to projects
        /// targeting .NET Standard or .NET Framework.
        /// <para>
        /// This method is excluded from the reference assembly for .NET Core 2.0 so
        /// projects targeting this will use the built-in method.
        /// </para>
        /// </remarks>
        /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance to append the value to.</param>
        /// <param name="separator">The separator to insert between the values.</param>
        /// <param name="values">The values to concatenate.</param>
        /// <returns>Returns the specified <see cref="StringBuilder"/>.</returns>
        public static StringBuilder AppendJoin(this StringBuilder stringBuilder, char separator, params string[] values)
        {
            stringBuilder.Append(String.Join(separator.ToString(), values));
            return stringBuilder;
        }

        /// <summary>
        /// Appends the members of a collection, separated by the specified separator.
        /// </summary>
        /// <remarks>
        /// AppendJoin() was added to <see cref="StringBuilder"/> in .NET Core 2.0. This
        /// extension method makes it available on earlier versions and to projects
        /// targeting .NET Standard or .NET Framework.
        /// <para>
        /// This method is excluded from the reference assembly for .NET Core 2.0 so
        /// projects targeting this will use the built-in method.
        /// </para>
        /// </remarks>
        /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance to append the value to.</param>
        /// <param name="separator">The separator to insert between the values.</param>
        /// <param name="values">The values to concatenate.</param>
        /// <returns>Returns the specified <see cref="StringBuilder"/>.</returns>
        public static StringBuilder AppendJoin<T>(this StringBuilder stringBuilder, char separator, IEnumerable<T> values)
        {
            stringBuilder.Append(String.Join(separator.ToString(), values));
            return stringBuilder;
        }

#endif

    }
}
