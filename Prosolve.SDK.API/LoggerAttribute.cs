using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Sharpdev.SDK.API
{
    /// <summary>
    ///     Механизм для логирования.
    /// </summary>
    public class LoggerAttribute : ActionFilterAttribute
    {
        /// <summary>
        ///     Сервис для работы с логами системы
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// </summary>
        /// <param name="logger"></param>
        public LoggerAttribute(ILogger logger)
        {
            this._logger = logger;
        }

        /// <summary>
        ///     Событие по старту выполнения метода.
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;
            this._logger.LogDebug(
                $"{request.Method,-6} {context.HttpContext.Response.StatusCode} {request.GetDisplayUrl()} {request.ContentType}");
        }

        /// <summary>
        ///     Событие по окончанию выполнения метода.
        /// </summary>
        /// <param name="filterContext">Контекст завершённого события.</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            this._logger.LogDebug(
                $"{request.Method,-6} {filterContext.HttpContext.Response.StatusCode} {request.GetDisplayUrl()} {request.ContentType}");
        }
    }
}
