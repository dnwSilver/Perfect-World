﻿using System;

using Prosolve.Services.Identification.Entities.Users;
using Prosolve.Services.Identification.Entities.Users.DomainEvents;
using Prosolve.Services.Identification.Entities.Users.IntegrationEvents;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Infrastructure.Repositories;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.Services.Identification
{
    /// <summary>
    ///     Сервис по управлению пользователями предоставляемый для бизнеса.
    /// </summary>
    internal partial class IdentityService : IIdentityService
    {
        /// <summary>
        ///     Создание пользователей в информационной системе.
        /// </summary>
        /// <param name="userBuilders">Список новых пользователей.</param>
        /// <returns>Информация по процессу создания пользователей.</returns>
        public Result CreateUsers(IUserBuilder[] userBuilders)
        {
            var newUsers = new IUserEntity[0];

            #region Проверяем занят ли адрес электронной почты

            #endregion

            #region Создаём пользователей

            var createResult = this._userRepository.Create(newUsers);

            #endregion

            #region Отправляем заявки на отправку письма с подтверждением

            var registrationEvent = new ToSendMailIntegrationEvent(Guid.NewGuid(), DateTime.UtcNow);
            this._integrateBus.PublishAsync(registrationEvent);

            #endregion

            #region Фиксируем статус действия в BI системе

            var domainEvent = new UserRegisteredDomainEvent(Guid.NewGuid(), DateTime.UtcNow);
            newUsers[0].AddDomainEvent(domainEvent);
            this._integrateBus.PublishAsync(domainEvent);

            #endregion

            return createResult.Result;
        }

        /// <summary>
        ///     Поиск пользователей в информационной системе.
        /// </summary>
        /// <param name="userSpecification">Набор параметров для поиска.</param>
        /// <returns>Список пользователям по заданным параметрам.</returns>
        public Result<IUserEntity[]> FindUser(ISpecification<IUserEntity> userSpecification)
        {
            if (this._userRepository.Status != RepositoryStatus.Up)
                return Result.Fail<IUserEntity[]>("Источник данных для пользователей недоступен.");

            return this._userRepository.Read(userSpecification).Result;
        }
    }
}
