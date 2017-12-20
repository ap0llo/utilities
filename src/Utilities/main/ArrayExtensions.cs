using System;
using System.Collections.Generic;
using System.Linq;

namespace Grynwald.Utilities
{
    /// <summary>
    /// Extension methods for arrays
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Divides the array into multiple parts (segments) with at most <paramref name="maxSegmentSize"/> element in each part
        /// (see <seealso cref="ArraySegment{T}"/>)
        /// </summary>
        /// <param name="array">The array to divide into segments</param>
        /// <param name="maxSegmentSize">The maximum number of elements allowed in a single segement</param>
        /// <remarks>Lazy evaluation</remarks>
        /// <returns>
        /// Returns an enumberale of (non-overlapping) <see cref="ArraySegment{T}"/> structures
        /// each representing a section of the underlying array
        /// </returns>
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
