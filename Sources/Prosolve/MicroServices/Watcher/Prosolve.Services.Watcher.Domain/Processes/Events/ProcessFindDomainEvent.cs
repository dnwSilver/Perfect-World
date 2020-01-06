using System;

using Sharpdev.SDK.Domain.Events;

namespace Prosolve.Services.Watcher.Domain.Processes.Events
{
    /// <summary>
    ///     Событие описывающие поиск процессов.
    /// </summary>
    public class ProcessFindDomainEvent : IDomainEvent<IProcessAggregate>
    {
        /// <summary>
        ///     Инициализация объекта <see cref="ProcessFindDomainEvent" />.
        /// </summary>
        /// <param name="id">Уникальный идентификатор события.</param>
        /// <param name="creationDate">Дата события (UTC+0).</param>
        /// <param name="data"> Информация о событии. Желательно хранить её в JSON. </param>
        public ProcessFindDomainEvent(Guid id, DateTime creationDate, string data)
        {
            Id = id;
            CreationDate = creationDate;
            Data = data;
        }

        /// <summary>
        ///     Уникальный идентификатор события.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        ///     Дата события (UTC+0).
        /// </summary>
        public DateTime CreationDate { get; }
        
        /// <summary>
        /// Информация о событии. Желательно хранить её в JSON.
        /// </summary>
        public string Data { get; }
    }
}
