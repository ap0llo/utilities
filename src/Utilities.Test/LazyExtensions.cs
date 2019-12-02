using System;

namespace Grynwald.Utilities.Test
{
    internal static class LazyExtensions
    {
        public static void DisposeIfCreated<T>(this Lazy<T> lazy) where T : IDisposable
        {
            if (lazy.IsValueCreated)
            {
                lazy.Value?.Dispose();
            }
        }
    }
}
