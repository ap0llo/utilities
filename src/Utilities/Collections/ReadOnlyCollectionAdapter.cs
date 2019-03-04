using System;
using System.Collections;
using System.Collections.Generic;

namespace Grynwald.Utilities.Collections
{
    public static class ReadOnlyCollectionAdapter
    {
        /// <summary>
        /// Creates a new read-only wrapper from the specified collection
        /// </summary>
        /// <typeparam name="T">The collection's element type.</typeparam>
        /// <param name="collection">The collection to wrap in a read-only adapter</param>
        /// <returns>Returns a new instance of <see cref="ReadOnlyCollectionAdapter{T}"/> wrapping the specified instance</returns>
        public static ReadOnlyCollectionAdapter<T> Create<T>(ICollection<T> collection) =>
            new ReadOnlyCollectionAdapter<T>(collection);
    }

    /// <summary>
    /// Wraps an instance of <see cref="ICollection{T}"/> as an <see cref="IReadOnlyCollection{T}"/>
    /// </summary>
    public class ReadOnlyCollectionAdapter<T> : IReadOnlyCollection<T>
    {
        private readonly ICollection<T> m_Collection;


        public int Count => m_Collection.Count;


        public ReadOnlyCollectionAdapter(ICollection<T> collection)
        {
            m_Collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }


        public IEnumerator<T> GetEnumerator() => m_Collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => m_Collection.GetEnumerator();
    }
}
