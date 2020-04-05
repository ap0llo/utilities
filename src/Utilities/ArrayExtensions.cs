using System;
using System.Collections.Generic;
using System.Linq;

namespace Grynwald.Utilities
{
    /// <summary>
    /// Extension methods for arrays.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Divides the array into multiple segments with at most <paramref name="maxSegmentSize"/> elements in each segment.
        /// </summary>
        /// <remarks>
        /// <c>GetSegments</c> divides the array into segments with at most <paramref name="maxSegmentSize"/> elements in each segment.
        /// <list type="bullet">
        ///     <item><description>If <paramref name="maxSegmentSize"/> is greater than the array's size, a single segment is returned.</description></item>
        ///     <item><description>If the array's size is a multiple of <paramref name="maxSegmentSize"/> each segment will have the same number of elements.</description></item>
        ///     <item><description>Otherwise, the last segment will contain fewer elements.</description></item>
        /// </list>
        /// <para>
        /// This method is implemented using deferred execution. The segments are not created until the return value is enumerated.
        /// </para>
        /// </remarks>
        /// <param name="array">The array to split into segments.</param>
        /// <param name="maxSegmentSize">The maximum number of elements allowed in a single segment.</param>
        /// <returns>
        /// Returns an enumerable of (non-overlapping) <see cref="ArraySegment{T}"/> structures
        /// each representing a section of the underlying array.
        /// </returns>
        /// <seealso cref = "ArraySegment{T}" />
        public static IEnumerable<ArraySegment<T>> GetSegments<T>(this T[] array, int maxSegmentSize)
        {
            IEnumerable<ArraySegment<T>> DoGetSegments()
            {
                for (int i = 0; i < array.Length; i += maxSegmentSize)
                {
                    yield return new ArraySegment<T>(array, i, Math.Min(maxSegmentSize, array.Length - i));
                }
            }

            if (maxSegmentSize < 1)
                throw new ArgumentOutOfRangeException(nameof(maxSegmentSize), "Value must not be less than 1");

            if (array.Length == 0)
                return Enumerable.Empty<ArraySegment<T>>();

            return DoGetSegments();
        }
    }
}
