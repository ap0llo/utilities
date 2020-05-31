using System;
using Microsoft.Extensions.Logging;

namespace Grynwald.Utilities.Logging
{
    /// <summary>
    /// A simple console logger that implements <see cref="ILogger"/>
    /// </summary>
    /// <remarks>
    /// <see cref="SimpleConsoleLogger"/> is a implementation of <see cref="ILogger"/> that writes log messages to the console.
    /// The behavior of the logger can be customized using <see cref="SimpleConsoleLoggerConfiguration"/>.
    /// </remarks>
    public sealed class SimpleConsoleLogger : ILogger
    {
        private static readonly object s_ConsoleLock = new object();

        private readonly SimpleConsoleLoggerConfiguration m_LoggerOptions;
        private readonly string? m_CategoryName;

        private class LoggerScope : IDisposable
        {
            public void Dispose()
            { }
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SimpleConsoleLogger"/>
        /// </summary>
        public SimpleConsoleLogger(SimpleConsoleLoggerConfiguration loggerOptions, string? categoryName)
        {
            m_CategoryName = String.IsNullOrEmpty(categoryName) ? null : categoryName;
            m_LoggerOptions = loggerOptions ?? throw new ArgumentNullException(nameof(loggerOptions));
        }

        /// <inheritdoc />
        public IDisposable BeginScope<TState>(TState state) => new LoggerScope();

        /// <inheritdoc />
        public bool IsEnabled(LogLevel logLevel) => logLevel >= m_LoggerOptions.MinimumLogLevel;

        /// <inheritdoc />
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            var color = GetConsoleColor(logLevel);

            var message = (!m_LoggerOptions.ShowCategoryName || m_CategoryName == null)
                ? $"{logLevel.ToString().ToUpper()} - {formatter(state, exception)}"
                : $"{logLevel.ToString().ToUpper()} - {m_CategoryName} - {formatter(state, exception)}";

            lock (s_ConsoleLock)
            {
                if (color.HasValue)
                {
                    var previousColor = Console.ForegroundColor;
                    Console.ForegroundColor = color.Value;
                    Console.WriteLine(message);
                    Console.ForegroundColor = previousColor;
                }
                else
                {
                    Console.WriteLine(message);
                }
            }
        }


        private ConsoleColor? GetConsoleColor(LogLevel logLevel)
        {
            if (!m_LoggerOptions.EnableColoredOutput)
                return null;

            switch (logLevel)
            {
                case LogLevel.Information:
                    return ConsoleColor.White;

                case LogLevel.Warning:
                    return ConsoleColor.Yellow;

                case LogLevel.Error:
                case LogLevel.Critical:
                    return ConsoleColor.Red;

                default:
                    return null;
            }
        }
    }
}
