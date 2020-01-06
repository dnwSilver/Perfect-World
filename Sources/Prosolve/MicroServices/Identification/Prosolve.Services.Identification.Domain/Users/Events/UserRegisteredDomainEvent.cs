using System;

using Sharpdev.SDK.Domain.Events;

namespace Prosolve.Services.Identification.Users.Events
{
    /// <summary>
    ///     Событие предметной области, реакция на  событие.
    ///     Регистрация нового пользователя.
    /// </summary>
    internal class UserRegisteredDomainEvent:DomainEventBase<IUserAggregate>
    {
        /// <summary>
        ///     Инициализация нового события предметной области.
        /// </summary>
        /// <param name="id"> Уникальный идентификатор события. </param>
        /// <param name="creationDate"> Дата события (UTC+0). </param>
        /// <param name="data"> Информация о событии. Желательно хранить её в JSON. </param>
        public UserRegisteredDomainEvent(Guid id, DateTime creationDate, string data):base(id, creationDate, data)
        {
        }
    }
}
