using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Prosolve.Services.Identification.Users.Events;
using Prosolve.Services.Identification.Users.Factories;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Extensions;
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
        private readonly IEntityFactory<IUserAggregate> _userFactory;

        /// <summary>
        ///     Репозиторий для работы с пользователями.
        /// </summary>
        private readonly IRepository<IUserAggregate> _userRepository;

        /// <summary>
        ///     Создание объекта <see cref="IdentificationService"/>.
        /// </summary>
        /// <param name="userFactory"> Фабрика для работы с пользователями. </param>
        /// <param name="userRepository"> Репозиторий для работы с пользователями. </param>
        /// <param name="unitOfWork"> Механизм для работы с репозиториями. </param>
        /// <param name="integrateBus"> Интеграционная шина. </param>
        public UserService(IUnitOfWork<IdentificationContext> unitOfWork,
                           IIntegrateBus integrateBus,
                           IEntityFactory<IUserAggregate> userFactory,
                           IRepository<IUserAggregate> userRepository)
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
        /// <param name="userBuilder"> Список новых пользователей. </param>
        /// <returns> Информация по процессу создания пользователей. </returns>
        public Result CreateUser(IUserBuilder userBuilder)
        {
            using var uow = _unitOfWork;
            _userRepository.SetBoundedContext(uow.BoundedContext);

            var user = _userFactory.Create(userBuilder).Value;

            // todo Нужно написать реализацию механизма для отправки обращений в шину данных.
            var domainEvent = user.Process(new CreateUserDomainCommand());
            user.Apply(domainEvent);
            _userRepository.CreateAsync(user.Yield());

            var commitResult = uow.Commit();

            if (commitResult.Failure)
                return commitResult;

            // todo Нужен интерфейс IClock для работы с датами. Также нужна реализация для него.
            var registrationEvent = new ToSendMailIntegrationEvent(Guid.NewGuid(), DateTime.UtcNow);
            _integrateBus.PublishAsync(registrationEvent);


            return Result.Done();
        }

        /// <summary>
        ///     Поиск пользователей.
        /// </summary>
        /// <param name="processSpecification"> Набор спецификаций для поиска процессов. </param>
        /// <returns> Список найденных процессов. </returns>
        public async Task<Result<IEnumerable<IUserAggregate>>> Find(ISpecification<IUserAggregate> processSpecification)
        {
            using var uow = _unitOfWork;

            _userRepository.SetBoundedContext(uow.BoundedContext);

            var foundProcess = await _userRepository.ReadAsync(processSpecification);

            //var domainEvent = new UserFindDomainEvent(Guid.NewGuid(), DateTime.UtcNow);

            // await this._integrateBus.PublishAsync(domainEvent);

            return Result.Done(foundProcess);
        }
    }
}
