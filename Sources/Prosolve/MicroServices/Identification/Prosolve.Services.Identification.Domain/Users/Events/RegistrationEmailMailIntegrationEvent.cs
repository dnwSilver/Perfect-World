using System;

using Sharpdev.SDK.Infrastructure.Integrations;

namespace Prosolve.Services.Identification.Users.Events
{

    /// <summary>
    ///     Событие миграции данных. Отправка электронного письма.
    /// </summary>
    internal class ToSendMailIntegrationEvent : IIntegrationEvent
    {
        /// <summary>
        /// Создание события отправки эл. письма.
        /// </summary>
        /// <param name="id">Уникальный идентификатор события.</param>
        /// <param name="creationDate">Время создания события.</param>
        public ToSendMailIntegrationEvent(Guid id, DateTime creationDate)
        {
            Id = id;
            CreationDate = creationDate;
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
