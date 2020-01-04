using System;
using System.Collections.Generic;
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
    internal class UserService: IService
    {
        /// <summary>
        ///     Шина для миграции данных.
        /// </summary>
        private readonly IIntegrateBus _integrateBus;

        /// <summary>
        ///     Механизм для работы с репозиториями.
        /// </summary>
        private readonly IUnitOfWork<IdentificationContext> _unitOfWork;

        /// <summary>
        ///     Фабрика для работы с пользователями.
        /// </summary>
        private readonly IEntityFactory<IUserEntity> _userFactory;

        /// <summary>
        ///     Репозиторий для работы с пользователями.
        /// </summary>
        private readonly IEntityRepository<IUserEntity> _userRepository;

        /// <summary>
        ///     Создание объекта <see cref="IdentificationService"/>.
        /// </summary>
        /// <param name="userFactory"> Фабрика для работы с пользователями. </param>
        /// <param name="userRepository"> Репозиторий для работы с пользователями. </param>
        /// <param name="unitOfWork"> Механизм для работы с репозиториями. </param>
        /// <param name="integrateBus"> Интеграционная шина. </param>
        public UserService(IUnitOfWork<IdentificationContext> unitOfWork,
                           IIntegrateBus integrateBus,
                           IEntityFactory<IUserEntity> userFactory,
                           IEntityRepository<IUserEntity> userRepository)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _integrateBus = integrateBus;
        }

        /// <summary>
        ///     Текущий статус объекта.
        /// </summary>
        /// <returns> Статус объекта. </returns>
        /// todo Создать абстрактный класс ServiceBase и в нём реализовать работу со статусами и UoW.
        public ServiceStatus Status { get; }

        /// <summary>
        ///     Смена статуса.
        /// </summary>
        /// <param name="newStatus"> Новый статус. </param>
        public void ChangeStatus(ServiceStatus newStatus)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Создание пользователей в информационной системе.
        /// </summary>
        /// <param name="userBuilders"> Список новых пользователей. </param>
        /// <returns> Информация по процессу создания пользователей. </returns>
        public Result CreateUsers(IEnumerable<IUserBuilder> userBuilders)
        {
            using var uow = _unitOfWork;
            _userRepository.SetBoundedContext(uow.BoundedContext);

            var createResult = _userRepository.Create(userBuilders
                                                     .Select(userBuilder => _userFactory.Create(userBuilder))
                                                     .Select(userEntity => userEntity.Value));

            var commitResult = uow.Commit();

            if (commitResult.Failure)
                return commitResult;

            // todo Нужен интерфейс IClock для работы с датами. Также нужна реализация для него.
            var registrationEvent = new ToSendMailIntegrationEvent(Guid.NewGuid(), DateTime.UtcNow);
            _integrateBus.PublishAsync(registrationEvent);

            // todo Нужно написать реализацию механизма для отправки обращений в шину данных.
            var domainEvent = new UserRegisteredDomainEvent(Guid.NewGuid(), DateTime.UtcNow, string.Empty);

            return Result.Ok();
        }

        /// <summary>
        ///     Поиск пользователей.
        /// </summary>
        /// <param name="processSpecification"> Набор спецификаций для поиска процессов. </param>
        /// <returns> Список найденных процессов. </returns>
        public async Task<Result<IEnumerable<IUserEntity>>> Find(ISpecification<IUserEntity> processSpecification)
        {
            using var uow = _unitOfWork;

            _userRepository.SetBoundedContext(uow.BoundedContext);

            var foundProcess = await _userRepository.Read(processSpecification);

            //var domainEvent = new UserFindDomainEvent(Guid.NewGuid(), DateTime.UtcNow);

            // await this._integrateBus.PublishAsync(domainEvent);

            return Result.Ok(foundProcess);
        }
    }
}
