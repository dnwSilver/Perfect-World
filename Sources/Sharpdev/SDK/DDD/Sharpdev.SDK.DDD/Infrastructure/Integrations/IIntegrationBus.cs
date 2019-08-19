using System.Threading.Tasks;

using Sharpdev.SDK.Infrastructure.Statuses;

namespace Sharpdev.SDK.Infrastructure.Integrations
{
    /// <summary>
    ///     Шина данных.
    /// </summary>
    /// <remarks>
    ///     Сервисная шина предприятия (англ. enterprise service bus, ESB) — связующее  программное
    ///     обеспечение,обеспечивающее централизованный и унифицированный событийно-ориентированный
    ///     обмен   сообщениями   между   различными   информационными   системами   на   принципах
    ///     сервис-ориентированной архитектуры.
    /// </remarks>
    public interface IIntegrateBus : IHasStatus<IntegrationBusStatus>
    {
        /// <summary>
        ///     Публикация нового события.
        /// </summary>
        /// <param name="event">Событие миграции данных.</param>
        /// <remarks>
        ///     Шина событий передает  полученное  событие  интеграции  всем  микрослужбам  и  даже
        ///     внешним приложениям, которые подписаны на  это  событие.  Этот  метод  используется
        ///     микрослужбой, которая публикует событие.
        /// </remarks>
        Task PublishAsync(IIntegrationEvent @event);

        /// <summary>
        ///     Подписка на событие.
        /// </summary>
        /// <typeparam name="TIntegrationEvent">Событие миграции данных.</typeparam>
        /// <typeparam name="TIntegrationEventHandler">Обработчик события.</typeparam>
        Task SubscribeAsync<TIntegrationEvent, TIntegrationEventHandler>()
            where TIntegrationEvent : IIntegrationEvent
            where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>;

        /// <summary>
        ///     Отписка от получения событий.
        /// </summary>
        /// <typeparam name="TIntegrationEvent">Событие миграции данных.</typeparam>
        /// <typeparam name="TIntegrationEventHandler">Обработчик события.</typeparam>
        Task UnsubscribeAsync<TIntegrationEvent, TIntegrationEventHandler>()
            where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
            where TIntegrationEvent : IIntegrationEvent;
    }
}
