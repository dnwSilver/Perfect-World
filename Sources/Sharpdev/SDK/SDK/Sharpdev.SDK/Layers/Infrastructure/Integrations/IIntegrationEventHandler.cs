using System.Threading.Tasks;

namespace Sharpdev.SDK.Layers.Infrastructure.Integrations
{
    /// <summary>
    ///     Обработчик события интеграции.
    /// </summary>
    /// <typeparam name="TIntegrationEvent">Событие миграции данных.</typeparam>
    /// <remarks>
    ///     Обработчик события интеграции  (или метод обратного вызова),  который  будет  выполнен,
    ///     когда микрослужба-получатель получит сообщение об этом событии интеграции.
    /// </remarks>
    public interface IIntegrationEventHandler<in TIntegrationEvent>
        where TIntegrationEvent : IIntegrationEvent
    {
        /// <summary>
        ///     Обработчик события интеграции (или метод обратного вызова), который будет выполнен,
        ///     когда микрослужба-получатель получит сообщение об этом событии интеграции.
        /// </summary>
        /// <param name="event">Событие миграции данных.</param>
        /// <returns></returns>
        Task HandleAsync(TIntegrationEvent @event);
    }
}
