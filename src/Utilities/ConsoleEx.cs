using System;

namespace Grynwald.Utilities
{
    /// <summary>
    /// Provides helper functions for writing to the console, supplementing the functionality of <c>System.Console</c>.
    /// </summary>
    public static class ConsoleEx
    {
        private static readonly object s_SyncRoot = new object();

        /// <summary>
        /// Writes an empty line to the console output.
        /// </summary>
        public static void WriteLine()
        {
            lock (s_SyncRoot)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Writes the specified string to the output using the console's current color.
        /// </summary>
        /// <param name="value">The value to write to the console output stream.</param>
        public static void WriteLine(string value) => WriteLine(default, value);

        /// <summary>
        /// Writes the specified string to the output in the specified color.
        /// </summary>
        /// <param name="color">
        /// The color to use for writing to the console.
        /// If parameter is <c>null</c> the console's current foreground color will be used.
        /// </param>
        /// <param name="value">
        /// The value to write to the console output stream.
        /// </param>
        public static void WriteLine(ConsoleColor? color, string value)
        {
            lock (s_SyncRoot)
            {
                if (color.HasValue)
                {
                    var previousColor = Console.ForegroundColor;

                    Console.ForegroundColor = color.Value;
                    Console.WriteLine(value);
                    Console.ForegroundColor = previousColor;
                }
                else
                {
                    Console.WriteLine(value);
                }
            }
        }
    }
}
