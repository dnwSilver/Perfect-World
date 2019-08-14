using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

using NLog;
using NLog.Config;
using NLog.Targets;

namespace Sharpdev.SDK.API
{
    public static partial class Configuration
    {
        /// <summary>
        ///     Настройка системы логирования информации.
        /// </summary>
        /// <param name="hostingContext">Контекст для хостинга.</param>
        /// <param name="logging">Строитель для логера.</param>
        public static void ConfigurationLogging(WebHostBuilderContext hostingContext,
                                                ILoggingBuilder logging)
        {
            logging.ClearProviders();

            var config = new LoggingConfiguration();
            var consoleTarget = new ColoredConsoleTarget
            {
                UseDefaultRowHighlightingRules = true,
                Layout = @"${date:format=[HH\:mm\:ss]} ${level:padding=5} ${message} ${exception}"
            };

            config.AddTarget(consoleTarget);
            config.AddRuleForAllLevels(consoleTarget);
            LogManager.Configuration = config;
        }
    }
}
