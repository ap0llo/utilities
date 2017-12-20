using System;
using System.Collections.Generic;

namespace Grynwald.Utilities
{
    /// <summary>
    /// Implementation of <see cref="IEqualityComparer{T}"/> for tuples with two elements
    /// composed of comparers for the tuple's individual items
    /// </summary>
    public class TupleComparer<T1, T2> : IEqualityComparer<(T1, T2)>
    {
        readonly IEqualityComparer<T1> m_FirstItemComparer;
        readonly IEqualityComparer<T2> m_SecondItemComparer;

        /// <summary>
        /// Initializes a new instance of <see cref="TupleComparer{T1, T2}"/>
        /// </summary>
        /// <param name="firstItemComparer">The comparer to use to determine equality of the tuple's first item</param>
        /// <param name="secondItemComparer">The comparer to use to determine equality of the tuple's second item</param>
        public TupleComparer(
            IEqualityComparer<T1> firstItemComparer,
            IEqualityComparer<T2> secondItemComparer)
        {
            m_FirstItemComparer = firstItemComparer ?? throw new ArgumentNullException(nameof(firstItemComparer));
            m_SecondItemComparer = secondItemComparer ?? throw new ArgumentNullException(nameof(secondItemComparer));
        }

        public bool Equals((T1, T2) x, (T1, T2) y) =>
            m_FirstItemComparer.Equals(x.Item1, y.Item1) &&
            m_SecondItemComparer.Equals(x.Item2, y.Item2);

        public int GetHashCode((T1, T2) obj)
        {
            unchecked
            {
                var hash = (m_FirstItemComparer.GetHashCode(obj.Item1) * 397);
                hash ^= m_SecondItemComparer.GetHashCode(obj.Item2);
                return hash;
            }
        }
    }
}
