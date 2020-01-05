using System;

using Sharpdev.SDK.Domain.Events;

namespace Prosolve.Services.Identification.Users.Events
{
    // todo Нужно создать абстрактный класс для событий.
    /// <summary>
    /// Событие информирующее о создании нового пользователя в информационной системе.
    /// </summary>
    public class CreateUserDomainEvent: IDomainEvent<IUserAggregate>
    {
        /// <summary>
        ///     Инициализация нового события предметной области.
        /// </summary>
        /// <param name="id"> Уникальный идентификатор события. </param>
        /// <param name="creationDate"> Дата события (UTC+0). </param>
        /// <param name="data"> Информация о событии. Желательно хранить её в JSON. </param>
        public CreateUserDomainEvent(Guid id, DateTime creationDate, string data)
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
        ///     Информация о событии. Желательно хранить её в JSON.
        /// </summary>
        public string Data { get; }
        
    }
}
