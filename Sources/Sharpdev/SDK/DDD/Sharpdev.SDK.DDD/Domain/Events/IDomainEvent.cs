using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Infrastructure.Integrations;

namespace Sharpdev.SDK.Domain.Events
{
    /// <summary>
    ///     Событие предметной области, реакция на  событие.
    /// </summary>
    /// <remarks>
    ///     Если говорить единым языком предметной области,  поскольку  событием является  то,  что
    ///     произошло в прошлом, имя класса события должно быть представлено с глаголом в прошедшем
    ///     времени, например OrderStartedDomainEvent или OrderShippedDomainEvent.
    ///     Используем  механизм  отложенного выполнения <see cref="IEventHandler{TDomainEvent}" />.
    ///     Найти объекты с событиями можно при  помощи  интерфейса  <see cref="IHasDomainEvent" />.
    /// </remarks>
    public interface IDomainEvent<TEntity> : IIntegrationEvent
        where TEntity:class, IEntity<TEntity>
    {
        /// <summary>
        /// Информация о событии. Желательно хранить её в JSON.
        /// </summary>
        string Data { get; }
    }
}
