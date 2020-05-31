using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Grynwald.Utilities.Logging
{
    /// <summary>
    /// Logger provider for <see cref="SimpleConsoleLogger"/>
    /// </summary>
    public sealed class SimpleConsoleLoggerProvider : ILoggerProvider
    {
        private static readonly object s_Lock = new object();
        private readonly IDictionary<string, ILogger> m_Loggers = new Dictionary<string, ILogger>();
        private readonly SimpleConsoleLoggerConfiguration m_LoggerOptions;

        /// <summary>
        /// Initializes a new instance of <see cref="SimpleConsoleLoggerProvider"/>
        /// </summary>
        public SimpleConsoleLoggerProvider() : this(SimpleConsoleLoggerConfiguration.Default)
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="SimpleConsoleLoggerProvider"/>
        /// </summary>
        public SimpleConsoleLoggerProvider(SimpleConsoleLoggerConfiguration loggerOptions)
        {
            m_LoggerOptions = loggerOptions ?? throw new ArgumentNullException(nameof(loggerOptions));
        }

        /// <inheritdoc />
        public ILogger CreateLogger(string categoryName)
        {
            lock (s_Lock)
            {
                if (m_Loggers.TryGetValue(categoryName, out var logger))
                {
                    return logger;
                }
                else
                {
                    logger = new SimpleConsoleLogger(m_LoggerOptions, categoryName);
                    m_Loggers.Add(categoryName, logger);
                    return logger;
                }
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            lock (s_Lock)
            {
                m_Loggers.Clear();
            }
        }
    }
}
