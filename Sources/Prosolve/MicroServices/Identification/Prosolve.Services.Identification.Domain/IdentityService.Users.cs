using System;
using System.Collections.Generic;

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
            var factory = new UserFactory();
            var newUsers = new List<IUserEntity>();

            foreach(var userBuilder in userBuilders)
            {
                var userEntity = factory.Create(userBuilder);
                newUsers.Add(userEntity.Value);
            }
       
            using var uow = this._unitOfWork;
            this._userRepository.SetBoundedContext(uow.BoundedContext);
            var createResult = this._userRepository.Create(newUsers.ToArray());
            var commitResult = uow.Commit();

            if (commitResult.Failure)
                return commitResult;
            
            var registrationEvent = new ToSendMailIntegrationEvent(Guid.NewGuid(), DateTime.UtcNow);
            this._integrateBus.PublishAsync(registrationEvent);

            var domainEvent = new UserRegisteredDomainEvent(Guid.NewGuid(), DateTime.UtcNow);
            return Result.Ok();
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
