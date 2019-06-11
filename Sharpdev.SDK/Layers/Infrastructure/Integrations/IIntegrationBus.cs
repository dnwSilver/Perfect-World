using System.Threading.Tasks;

using Sharpdev.SDK.Layers.Infrastructure.Statuses;

namespace Sharpdev.SDK.Layers.Infrastructure.Integrations
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
        /// <typeparam name="T">Событие миграции данных.</typeparam>
        /// <typeparam name="TH">Обработчик события.</typeparam>
        Task SubscribeAsync<T, TH>()
            where T : IIntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        /// <summary>
        ///     Отписка от получения событий.
        /// </summary>
        /// <typeparam name="T">Событие миграции данных.</typeparam>
        /// <typeparam name="TH">Обработчик события.</typeparam>
        Task UnsubscribeAsync<T, TH>()
            where TH : IIntegrationEventHandler<T>
            where T : IIntegrationEvent;
    }
}
