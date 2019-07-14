using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;

namespace Sharpdev.SDK.API
{
    public static partial class Configuration
    {
        /// <summary>
        ///     Настройка системы логирования информации.
        /// </summary>
        /// <param name="hostingContext">Контекст для хостинга.</param>
        /// <param name="logging">Строитель для логера.</param>
        public static void ConfigurationLogging(WebHostBuilderContext hostingContext, ILoggingBuilder logging)
        {
            logging.ClearProviders();

            var config = new LoggingConfiguration();
            string consoleLayout = @"${date:format=[HH\:mm\:ss]} ${level:padding=5} ${message} ${exception}";
            var consoleTarget =
                new ColoredConsoleTarget("console-target")
                {
                    UseDefaultRowHighlightingRules = true, Layout = consoleLayout
                };

            config.AddTarget(consoleTarget);
            string fileName = @"${basedir}/logs/ServiceBroker_ClientAPI_${date:format=yyyy-MM-dd}.log";
            string fileLayout =
                @"${date:format=[yyyy-MM-dd HH\:mm\:ss]} ${level:uppercase=true} ${logger:shortname=true} ${message} ${exception}";
            var fileTarget = new FileTarget("file-target") { FileName = fileName, Layout = fileLayout };
            var asyncWrapper =
                new AsyncTargetWrapper(fileTarget) { OverflowAction = AsyncTargetWrapperOverflowAction.Discard };
            fileTarget.KeepFileOpen = false;
            config.AddTarget("async", asyncWrapper);
            config.AddRuleForAllLevels(fileTarget);
            config.AddRuleForAllLevels(consoleTarget);
            LogManager.Configuration = config;
        }
    }
}
