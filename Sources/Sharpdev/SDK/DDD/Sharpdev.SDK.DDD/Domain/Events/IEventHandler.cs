using System.Threading;
using System.Threading.Tasks;

using Sharpdev.SDK.Infrastructure.Integrations;

namespace Sharpdev.SDK.Domain.Events
{
    /// <summary>
    ///     Обработчик событий предметной области.
    /// </summary>
    /// <typeparam name="TEvent">Событие предметной области <see cref="IDomainEvent" />.</typeparam>
    public interface IEventHandler<in TEvent> : IIntegrationEventHandler<TEvent>
        where TEvent : IDomainEvent
    {
        /// <summary>
        ///     Обработчик событий предметной области.
        /// </summary>
        /// <param name="event">Событие предметной области.</param>
        /// <param name="cancellationToken">Отмена события.</param>
        /// <returns></returns>
        Task Handle(TEvent @event, CancellationToken cancellationToken);
    }
}
