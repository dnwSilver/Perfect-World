using System;

using Sharpdev.SDK.Domain.Events;

namespace Prosolve.Services.Identification.Users.Events
{
    /// <summary>
    /// Событие информирующее о создании нового пользователя в информационной системе.
    /// </summary>
    public class CreateUserDomainEvent: DomainEventBase<IUserAggregate>
    {
        /// <summary>
        ///     Инициализация нового события предметной области.
        /// </summary>
        /// <param name="id"> Уникальный идентификатор события. </param>
        /// <param name="creationDate"> Дата события (UTC+0). </param>
        /// <param name="data"> Информация о событии. Желательно хранить её в JSON. </param>
        public CreateUserDomainEvent(Guid id, DateTime creationDate, string data) :base(id, creationDate, data)
        {
        }
    }
}
