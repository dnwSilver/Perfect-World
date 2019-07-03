using System;

using Sharpdev.SDK.Layers.Infrastructure.Integrations;

namespace Prosolve.MicroService.Identity.Entities.Users.IntegrationEvents
{
    public class ToSendMailIntegrationEvent : IIntegrationEvent
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
