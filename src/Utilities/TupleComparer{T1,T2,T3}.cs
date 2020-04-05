using System;
using System.Collections.Generic;

namespace Grynwald.Utilities
{
    /// <summary>
    /// Implementation of <see cref="IEqualityComparer{T}"/> for tuples with three elements
    /// composed of comparers for the tuple's individual items
    /// </summary>
    /// <example>
    /// Using this class, comparers for <see cref="ValueTuple{T1,T2,T3}"/> can easily be created by composing
    /// comparers for the tuple's individual elements.
    /// <code language="csharp"><![CDATA[
    /// var myIntComparer = EqualityComparer<int>.Default;
    /// var myStringComparer = StringComparer.OrdinalIgnoreCase;
    /// var tupleComparer = new TupleComparer<int, string, string>(myIntComparer, myStringComparer, myStringComparer);
    ///
    /// var equal = tupleComparer.Equals((1, "foo", "bar"), (1, "FOO", "bar"));
    ///
    /// Debug.Assert(equal == true);
    /// ]]>
    /// </code>
    /// </example>
    /// <typeparam name="T1">The type of the tuple's first element.</typeparam>
    /// <typeparam name="T2">The type of the tuple's second element.</typeparam>
    /// <typeparam name="T3">The type of the tuple's third element.</typeparam>
    /// <seealso cref="TupleComparer"/>
    /// <seealso cref="TupleComparer{T1, T2, T3}"/>
    public class TupleComparer<T1, T2, T3> : IEqualityComparer<(T1, T2, T3)>
    {
        readonly IEqualityComparer<T1> m_FirstItemComparer;
        readonly IEqualityComparer<T2> m_SecondItemComparer;
        readonly IEqualityComparer<T3> m_ThirdItemComparer;

        /// <summary>
        /// Initializes a new instance of <see cref="TupleComparer{T1, T2, T3}"/>.
        /// </summary>
        /// <param name="firstItemComparer">The comparer to use to determine equality of the tuple's first item.</param>
        /// <param name="secondItemComparer">The comparer to use to determine equality of the tuple's second item.</param>
        /// <param name="thirdItemComparer">The comparer to use to determine equality of the tuple's third item.</param>
        public TupleComparer(
            IEqualityComparer<T1> firstItemComparer,
            IEqualityComparer<T2> secondItemComparer,
            IEqualityComparer<T3> thirdItemComparer)
        {
            m_FirstItemComparer = firstItemComparer ?? throw new ArgumentNullException(nameof(firstItemComparer));
            m_SecondItemComparer = secondItemComparer ?? throw new ArgumentNullException(nameof(secondItemComparer));
            m_ThirdItemComparer = thirdItemComparer ?? throw new ArgumentNullException(nameof(thirdItemComparer));
        }

        public bool Equals((T1, T2, T3) x, (T1, T2, T3) y) =>
            m_FirstItemComparer.Equals(x.Item1, y.Item1) &&
            m_SecondItemComparer.Equals(x.Item2, y.Item2) &&
            m_ThirdItemComparer.Equals(x.Item3, y.Item3);

        public int GetHashCode((T1, T2, T3) obj)
        {
            unchecked
            {
                var hash = (m_FirstItemComparer.GetHashCode(obj.Item1) * 397);
                hash ^= m_SecondItemComparer.GetHashCode(obj.Item2);
                hash ^= m_ThirdItemComparer.GetHashCode(obj.Item3);
                return hash;
            }
        }

    }
}
