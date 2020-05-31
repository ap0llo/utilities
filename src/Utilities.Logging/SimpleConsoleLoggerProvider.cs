using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Grynwald.Utilities.Logging
{
    internal sealed class SimpleConsoleLoggerProvider : ILoggerProvider
    {
        private static readonly object s_Lock = new object();
        private readonly IDictionary<string, ILogger> m_Loggers = new Dictionary<string, ILogger>();
        private readonly SimpleConsoleLoggerConfiguration m_LoggerOptions;

        public SimpleConsoleLoggerProvider() : this(SimpleConsoleLoggerConfiguration.Default)
        { }

        public SimpleConsoleLoggerProvider(SimpleConsoleLoggerConfiguration loggerOptions)
        {
            m_LoggerOptions = loggerOptions ?? throw new ArgumentNullException(nameof(loggerOptions));
        }


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

        public void Dispose()
        {
            lock (s_Lock)
            {
                m_Loggers.Clear();
            }
        }
    }
}
