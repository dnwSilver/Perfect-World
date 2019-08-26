using System;

using Sharpdev.SDK.Infrastructure.Integrations;

namespace Prosolve.Services.Identification.Users.Events
{
    internal class ToSendMailIntegrationEvent : IIntegrationEvent
    {
        public ToSendMailIntegrationEvent(Guid id, DateTime creationDate)
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
