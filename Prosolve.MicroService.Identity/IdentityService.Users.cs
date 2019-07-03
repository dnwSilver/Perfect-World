﻿using System.Linq;

using Prosolve.MicroService.Identity.Entities.Users;
using Prosolve.MicroService.Identity.Entities.Users.DomainEvents;
using Prosolve.MicroService.Identity.Entities.Users.IntegrationEvents;
using Prosolve.MicroService.Identity.Entities.Users.Specifications;

using Sharpdev.SDK.Layers.Infrastructure.Repositories;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.MicroService.Identity
{
    /// <summary>
    ///     Сервис по управлению пользователями предоставляемый для бизнеса.
    /// </summary>
    public partial class IdentityService : IIdentityService
    {
        /// <summary>
        ///     Создание пользователей в информационной системе.
        /// </summary>
        /// <param name="newUsers">Список новых пользователей.</param>
        /// <returns>Информация по процессу создания пользователей.</returns>
        public Result CreateUsers(IUserBuilder[] userBuilders)
        {
            var newUsers = new IUser[0];

            #region Проверяем занят ли адрес электронной почты

            var searchParameters = new UserSearchParameters();
            searchParameters.EmailAddresses.Use(newUsers.Select(x => x.ContactEmail.Value));
            var result = _userRepository.Read(searchParameters);

            var specification = new EmailAlreadyInUseSpecification(result.Value);

            foreach(var newUser in newUsers)
                if (!specification.IsSatisfiedBy(newUser))
                    return Result.Fail(
                        $"Электронный адрес {newUser.ContactEmail.Value} уже используется другим пользователем.");

            #endregion

            #region Создаём пользователей

            var createResult = _userRepository.Create(newUsers);

            #endregion

            #region Отправляем заявки на отправку письма с подтверждением

            var registrationEvent = new ToSendMailIntegrationEvent();
            _integrateBus.PublishAsync(registrationEvent);

            #endregion

            #region Фиксируем статус действия в BI системе

            var domainEvent = new UserRegisteredDomainEvent();
            newUsers[0].AddDomainEvent(domainEvent);
            _integrateBus.PublishAsync(domainEvent);

            #endregion

            onRegistered();

            return createResult;
        }

        /// <summary>
        ///     Поиск пользователей в информационной системе.
        /// </summary>
        /// <param name="userSearchParameters">Набор параметров для поиска.</param>
        /// <returns>Список пользователям по заданным параметрам.</returns>
        public Result<IUser[]> FindUser(IUserSearchParameters userSearchParameters)
        {
            if (_userRepository.Status != RepositoryStatus.Up)
                return Result.Fail<IUser[]>("Источник данных для пользователей недоступен.");

            return _userRepository.Read(userSearchParameters);
        }

        private event MethodContainer onRegistered;

        private delegate void MethodContainer();
    }
}
