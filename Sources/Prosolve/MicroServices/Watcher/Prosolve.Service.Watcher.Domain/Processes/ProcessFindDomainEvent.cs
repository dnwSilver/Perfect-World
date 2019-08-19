using System;

using Sharpdev.SDK.Domain.Events;

namespace Prosolve.MicroService.Watcher.Domain.Processes
{
    /// <summary>
    ///     Событие описывающие поиск процессов.
    /// </summary>
    public class ProcessFindDomainEvent : IDomainEvent
    {
        /// <summary>
        ///     Инициализация объекта <see cref="ProcessFindDomainEvent" />.
        /// </summary>
        /// <param name="id">Уникальный идентификатор события.</param>
        /// <param name="creationDate">Дата события (UTC+0).</param>
        public ProcessFindDomainEvent(Guid id, DateTime creationDate)
        {
            this.Id = id;
            this.CreationDate = creationDate;
        }

        /// <summary>
        ///     Уникальный идентификатор события.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        ///     Дата события (UTC+0).
        /// </summary>
        public DateTime CreationDate { get; }
    }
}
