using Microsoft.Extensions.Logging;

namespace Grynwald.Utilities.Logging
{
    /// <summary>
    /// Extension methods for <see cref="ILoggerFactory"/> to ease usage o <see cref="SimpleConsoleLogger"/>.
    /// </summary>
    public static class LoggerFactoryExtensions
    {
        /// <summary>
        /// Adds a <see cref="SimpleConsoleLoggerProvider"/> logging provider to the logger factory
        /// </summary>
        public static ILoggerFactory AddSimpleConsoleLogger(this ILoggerFactory loggerFactory, SimpleConsoleLoggerConfiguration configurtation)
        {
            loggerFactory.AddProvider(new SimpleConsoleLoggerProvider(configurtation));
            return loggerFactory;
        }

        /// <summary>
        /// Adds a <see cref="SimpleConsoleLoggerProvider"/> logging provider to the logger factory
        /// </summary>
        public static ILoggerFactory AddSimpleConsoleLogger(this ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new SimpleConsoleLoggerProvider());
            return loggerFactory;
        }
    }
}
