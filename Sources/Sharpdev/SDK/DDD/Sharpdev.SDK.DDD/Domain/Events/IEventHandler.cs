using System.Threading;
using System.Threading.Tasks;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Infrastructure.Integrations;

namespace Sharpdev.SDK.Domain.Events
{
    /// <summary>
    ///     Обработчик событий предметной области.
    /// </summary>
    /// <typeparam name="TEvent">Событие предметной области <see cref="IDomainEvent{TEntity}" />.</typeparam>
    /// <typeparam name="TEntity">Тип доменного объекта для отправки сообщений. </typeparam>
    public interface IEventHandler<in TEvent, in TEntity> : IIntegrationEventHandler<TEvent>
        where TEvent : IDomainEvent<TEntity>
    where TEntity: class, IEntity<TEntity>
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
