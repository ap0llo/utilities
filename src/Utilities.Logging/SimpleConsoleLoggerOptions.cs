using Microsoft.Extensions.Logging;

namespace Grynwald.Utilities.Logging
{
    /// <summary>
    /// Settings for <see cref="SimpleConsoleLogger"/>
    /// </summary>
    public sealed class SimpleConsoleLoggerOptions
    {
        /// <summary>
        /// Gets the default logger settings
        /// </summary>
        public static readonly SimpleConsoleLoggerOptions Default = new SimpleConsoleLoggerOptions(LogLevel.Information, true, true);

        /// <summary>
        /// Gets the minimum log level of log messages that are written to the output
        /// </summary>
        public LogLevel MinimumLogLevel { get; }

        /// <summary>
        /// Gets whether the category name of log messages is included in the output
        /// </summary>
        public bool ShowCategoryName { get; }

        /// <summary>
        /// Gets whether console output uses colors to differentiate between log levels
        /// </summary>
        public bool EnableColoredOutput { get; }


        /// <summary>
        /// Initializes a new instance of <see cref="SimpleConsoleLoggerOptions"/>
        /// </summary>
        /// <param name="minimumLogLevel">The value to use for <see cref="MinimumLogLevel"/></param>
        /// <param name="showCategoryName">The value to use for <see cref="ShowCategoryName"/></param>
        /// <param name="enabledColoredOutput">The value to use for <see cref="EnableColoredOutput"/></param>
        public SimpleConsoleLoggerOptions(LogLevel minimumLogLevel, bool showCategoryName, bool enabledColoredOutput)
        {
            MinimumLogLevel = minimumLogLevel;
            ShowCategoryName = showCategoryName;
            EnableColoredOutput = enabledColoredOutput;
        }
    }
}
