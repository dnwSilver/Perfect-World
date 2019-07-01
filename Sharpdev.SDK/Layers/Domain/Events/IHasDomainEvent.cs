using System.Collections;
using System.Collections.Generic;

namespace Sharpdev.SDK.Layers.Domain.Events
{
    /// <summary>
    ///     Контракт для управления событиями на уровне предметной области.
    /// </summary>
    public interface IHasDomainEvent
    {
        /// <summary>
        ///     Список всех событий предметной области.
        /// </summary>
        /// <returns>Список всех событий предметной области.</returns>
        IEnumerable DomainEvents();

        /// <summary>
        ///     Добавление нового события предметной области.
        /// </summary>
        /// <param name="domainEvent">Событие предметной области.</param>
        void AddDomainEvent(IDomainEvent domainEvent);

        /// <summary>
        ///     Удаление события.
        /// </summary>
        /// <param name="domainEvent">Событие предметной области.</param>
        void RemoveDomainEvent(IDomainEvent domainEvent);

        /// <summary>
        ///     Удаление всех событий предметной области.
        /// </summary>
        void ClearDomainEvents();
    }
}
