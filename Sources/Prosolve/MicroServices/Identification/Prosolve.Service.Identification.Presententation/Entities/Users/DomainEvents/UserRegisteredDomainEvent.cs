using System;

using Sharpdev.SDK.Domain.Events;

namespace Prosolve.MicroService.Identification.Entities.Users.DomainEvents
{
    /// <summary>
    ///     Событие предметной области, реакция на  событие.
    ///     Регистрация нового пользователя.
    /// </summary>
    public class UserRegisteredDomainEvent : IDomainEvent
    {
        /// <summary>
        ///     Инициализация нового события предметной области.
        /// </summary>
        /// <param name="id">Уникальный идентификатор события.</param>
        /// <param name="creationDate">Дата события (UTC+0).</param>
        public UserRegisteredDomainEvent(Guid id, DateTime creationDate)
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
