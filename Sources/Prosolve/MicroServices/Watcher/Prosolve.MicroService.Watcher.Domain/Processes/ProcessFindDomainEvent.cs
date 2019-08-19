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
        ///     Уникальный идентификатор события.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        ///     Дата события (UTC+0).
        /// </summary>
        public DateTime CreationDate { get; }
    }
}
