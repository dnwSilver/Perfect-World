using System;
using System.Linq;
using System.Threading.Tasks;

using Prosolve.Services.Identification.Users.Events;
using Prosolve.Services.Identification.Users.Factories;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Infrastructure.Integrations;
using Sharpdev.SDK.Infrastructure.Repositories;
using Sharpdev.SDK.Presentation;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.Services.Identification.Users
{
    /// <summary>
    ///     Сервис по управлению пользователями предоставляемый для бизнеса.
    /// </summary>
    internal class UserService : IService
    {
        /// <summary>
        ///     Шина для миграции данных.
        /// </summary>
        private readonly IIntegrateBus _integrateBus;

        /// <summary>
        ///     Репозиторий для работы с пользователями.
        /// </summary>
        private readonly IEntityRepository<IUserEntity> _userRepository;

        /// <summary>
        ///     Механизм для работы с репозиториями.
        /// </summary>
        private readonly IUnitOfWork<IdentificationContext> _unitOfWork;

        /// <summary>
        ///     Создание объекта <see cref="IdentificationService" />.
        /// </summary>
        /// <param name="userRepository">Репозиторий для работы с пользователями.</param>
        /// <param name="unitOfWork">Механизм для работы с репозиториями.</param>
        /// <param name="integrateBus">Интеграционная шина.</param>
        public UserService(IUnitOfWork<IdentificationContext> unitOfWork,
                                     IIntegrateBus integrateBus,
                                     IEntityRepository<IUserEntity> userRepository)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
            this._integrateBus = integrateBus;
        }
        
        /// <summary>
        ///     Создание пользователей в информационной системе.
        /// </summary>
        /// <param name="userBuilders">Список новых пользователей.</param>
        /// <returns>Информация по процессу создания пользователей.</returns>
        public Result CreateUsers(IUserBuilder[] userBuilders)
        {
            IEntityFactory<IUserEntity> factory = new UserFactory();

            using var uow = this._unitOfWork;
            this._userRepository.SetBoundedContext(uow.BoundedContext);
            var createResult = this._userRepository.Create(
                userBuilders
                    .Select(userBuilder => factory.Create(userBuilder))
                    .Select(userEntity => userEntity.Value)
                    .ToArray());

            if (createResult.Result.Failure)
                return createResult.Result;
            
            var commitResult = uow.Commit();

            if (commitResult.Failure)
                return commitResult;

            var registrationEvent = new ToSendMailIntegrationEvent(Guid.NewGuid(), DateTime.UtcNow);
            this._integrateBus.PublishAsync(registrationEvent);

            var domainEvent = new UserRegisteredDomainEvent(Guid.NewGuid(), DateTime.UtcNow);

            return Result.Ok();
        }

        /// <summary>
        ///     Поиск пользователей.
        /// </summary>
        /// <param name="processSpecification">Набор спецификаций для поиска процессов.</param>
        /// <returns>Список найденных процессов.</returns>
        public async Task<Result<IUserEntity[]>> Find(
            ISpecification<IUserEntity> processSpecification)
        {
            using var uow = this._unitOfWork;

            this._userRepository.SetBoundedContext(uow.BoundedContext);

            var foundProcess = await this._userRepository.Read(processSpecification);

            //var domainEvent = new UserFindDomainEvent(Guid.NewGuid(), DateTime.UtcNow);

            // await this._integrateBus.PublishAsync(domainEvent);

            return Result.Ok<IUserEntity[]>(foundProcess);
        }

        
        /// <summary>
        ///     Текущий статус объекта.
        /// </summary>
        /// <returns>Статус объекта.</returns>
        /// todo Создать абстрактный класс ServiceBase и в нём реализовать работу со статусами и UoW.
        public ServiceStatus Status { get; }

        /// <summary>
        ///     Смена статуса.
        /// </summary>
        /// <param name="newStatus">Новый статус.</param>
        public void ChangeStatus(ServiceStatus newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
