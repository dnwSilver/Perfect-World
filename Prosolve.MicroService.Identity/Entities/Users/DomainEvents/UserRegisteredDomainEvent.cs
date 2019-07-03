﻿using System;

using Sharpdev.SDK.Layers.Domain.Events;

namespace Prosolve.MicroService.Identity.Entities.Users.DomainEvents
{
    public class UserRegisteredDomainEvent : IDomainEvent
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
