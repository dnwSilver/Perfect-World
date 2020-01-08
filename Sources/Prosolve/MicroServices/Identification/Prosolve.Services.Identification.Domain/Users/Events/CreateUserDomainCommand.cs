using System;

using Sharpdev.SDK.Domain.Events;

namespace Prosolve.Services.Identification.Users.Events
{
    /// <summary>
    /// Команда для старта события по созданию пользователя.
    /// </summary>
    public class CreateUserDomainCommand : DomainEventBase<IUserAggregate>
    {
        /// <summary>
        ///     Инициализация нового события предметной области.
        /// </summary>
        /// <param name="id"> Уникальный идентификатор события. </param>
        /// <param name="creationDate"> Дата события (UTC+0). </param>
        /// <param name="data"> Информация о событии. Желательно хранить её в JSON. </param>
        public CreateUserDomainCommand(Guid id, DateTime creationDate, string data): base(id, creationDate, data)
        {
        }
    }
}
