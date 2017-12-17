using System.Collections.Generic;

namespace Grynwald.Utilities
{
    public class TupleComparer
    {
        public static TupleComparer<T1, T2> Create<T1, T2>(
            IEqualityComparer<T1> firstItemComparer,
            IEqualityComparer<T2> secondItemComparer) => new TupleComparer<T1, T2>(firstItemComparer, secondItemComparer);

        public static TupleComparer<T1, T2, T3> Create<T1, T2, T3>(
            IEqualityComparer<T1> firstItemComparer,
            IEqualityComparer<T2> secondItemComparer,
            IEqualityComparer<T3> thirdItemComparer) => new TupleComparer<T1, T2, T3>(firstItemComparer, secondItemComparer, thirdItemComparer);
    }
}