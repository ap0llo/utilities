using System.Collections.Generic;

namespace Grynwald.Utilities
{
    /// <summary>
    /// Utility class to ease instantiation of <see cref="TupleComparer{T1, T2}"/> and <see cref="TupleComparer{T1, T2, T3}"/>
    /// </summary>
    public static class TupleComparer
    {
        /// <summary>
        /// Creates a new comparer for tuples with two elements
        /// </summary>
        public static TupleComparer<T1, T2> Create<T1, T2>(
            IEqualityComparer<T1> firstItemComparer,
            IEqualityComparer<T2> secondItemComparer) => new TupleComparer<T1, T2>(firstItemComparer, secondItemComparer);

        /// <summary>
        /// Creates a new comparer for tuples with two elements
        /// </summary>
        public static TupleComparer<T1, T2, T3> Create<T1, T2, T3>(
            IEqualityComparer<T1> firstItemComparer,
            IEqualityComparer<T2> secondItemComparer,
            IEqualityComparer<T3> thirdItemComparer) => new TupleComparer<T1, T2, T3>(firstItemComparer, secondItemComparer, thirdItemComparer);
    }
}