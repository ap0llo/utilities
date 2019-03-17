using System.Collections.Generic;

namespace Grynwald.Utilities.Collections
{
    /// <summary>
    /// Extension methods for <see cref="List{T}"/>
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Returns the list as <see cref="IReadOnlyList{T}"/>.
        /// </summary>
        /// <remarks>
        /// Converts the specified list to a <see cref="IReadOnlyList{T}"/>.
        /// As <see cref="List{T}"/> already implements this interface, no new instance
        /// is created and the original instance is returned. Thus this method is equivalent to a cast,
        /// but might be easier to write and read in some situations as the generic type parameters
        /// are inferred automatically.
        /// </remarks>
        /// <example>
        /// Calling <c>AsReadOnlyList</c> is equivalent to using a cast but the type parameter
        /// is inferred by the compiler as illustrated by the sample below.
        /// <code language="csharp">
        /// <![CDATA[
        /// public void Example(List<string> list)
        /// {
        ///     var readonly1 = (IReadOnlyList<string>)list;
        ///
        ///     var readonly2 = list.AsReadOnlyList();
        /// }
        /// ]]>
        /// </code>
        /// </example>
        /// <typeparam name="T">The type of the elements in the list.</typeparam>
        /// <param name="list">The list to cast to <see cref="IReadOnlyList{T}"/>.</param>
        /// <returns>Returns <paramref name="list"/> cast to <see cref="IReadOnlyList{T}"/>.</returns>
        public static IReadOnlyList<T> AsReadOnlyList<T>(this List<T> list) => list;
    }
}
