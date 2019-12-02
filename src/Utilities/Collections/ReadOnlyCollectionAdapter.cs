using System;
using System.Collections;
using System.Collections.Generic;

namespace Grynwald.Utilities.Collections
{
    /// <summary>
    /// Utility class to ease instantiation of <see cref="ReadOnlyCollectionAdapter{T}"/>
    /// </summary>
    /// <example>
    /// To wrap a collection as readonly collection use
    /// <code language="csharp">
    /// <![CDATA[
    /// ICollection<string> myCollection = new [] { "a", "b" };
    /// IReadOnlyCollection<string> readonlyCollection = ReadOnlyCollectionAdapter.Create(myCollection);
    /// ]]>
    /// </code>
    /// </example>
    public static class ReadOnlyCollectionAdapter
    {
        /// <summary>
        /// Creates a new read-only wrapper from the specified collection.
        /// </summary>
        /// <typeparam name="T">The collection's element type.</typeparam>
        /// <param name="collection">The collection to wrap in a read-only adapter.</param>
        /// <returns>Returns a new instance of <see cref="ReadOnlyCollectionAdapter{T}"/> wrapping the specified instance.</returns>
        public static ReadOnlyCollectionAdapter<T> Create<T>(ICollection<T> collection) =>
            new ReadOnlyCollectionAdapter<T>(collection);
    }

    /// <summary>
    /// Wraps an instance of <see cref="ICollection{T}"/> as an <see cref="IReadOnlyCollection{T}"/>
    /// </summary>
    /// <typeparam name="T">The collection's element type.</typeparam>
    public class ReadOnlyCollectionAdapter<T> : IReadOnlyCollection<T>
    {
        private readonly ICollection<T> m_Collection;

        /// <inheritDoc />
        public int Count => m_Collection.Count;

        /// <summary>
        /// Initializes a new instance of <see cref="ReadOnlyCollectionAdapter{T}"/>.
        /// </summary>        
        /// <param name="collection">The collection to wrap in a read-only adapter.</param>
        public ReadOnlyCollectionAdapter(ICollection<T> collection)
        {
            m_Collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }


        /// <inheritDoc />
        public IEnumerator<T> GetEnumerator() => m_Collection.GetEnumerator();
        /// <inheritDoc />
        IEnumerator IEnumerable.GetEnumerator() => m_Collection.GetEnumerator();
    }
}
