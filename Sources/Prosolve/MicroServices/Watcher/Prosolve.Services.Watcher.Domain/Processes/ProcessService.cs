#nullable enable
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Prosolve.Services.Watcher.Domain.Processes.Events;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Infrastructure.Integrations;
using Sharpdev.SDK.Infrastructure.Repositories;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.Services.Watcher.Domain.Processes
{
    /// <summary>
    ///     Сервис по управлению процессами <see cref="IProcessEntity" /> протекающими в системе.
    /// </summary>
    internal class ProcessService
    {
        /// <summary>
        ///     Шина для обмена сообщениями.
        /// </summary>
        private readonly IIntegrateBus _integrateBus;

        /// <summary>
        ///     Репозиторий для работы с <see cref="IProcessEntity" />.
        /// </summary>
        private readonly IEntityRepository<IProcessEntity> _processRepository;

        /// <summary>
        ///     Механизм для работы с репозиториями.
        /// </summary>
        private readonly IUnitOfWork<WatcherContext> _unitOfWork;

        /// <summary>
        ///     Инициализация объекта <see cref="ProcessService" />.
        /// </summary>
        /// <param name="unitOfWork">Механизм для работы с репозиториями.</param>
        /// <param name="integrateBus">Шина для обмена сообщениями.</param>
        /// <param name="processRepository">Репозиторий для работы с <see cref="IProcessEntity" />.</param>
        public ProcessService(IUnitOfWork<WatcherContext> unitOfWork,
                              IIntegrateBus integrateBus,
                              IEntityRepository<IProcessEntity> processRepository)
        {
            this._processRepository = processRepository!;
            this._integrateBus = integrateBus!;
            this._unitOfWork = unitOfWork!;
        }

        /// <summary>
        ///     Поиск процессов.
        /// </summary>
        /// <param name="processSpecification">Набор спецификаций для поиска процессов.</param>
        /// <returns>Список найденных процессов.</returns>
        public async Task<Result<IEnumerable<IProcessEntity>>> Find(
            ISpecification<IProcessEntity> processSpecification)
        {
            using var uow = this._unitOfWork;

            this._processRepository.SetBoundedContext(uow.BoundedContext);

            var foundProcess = await this._processRepository.Read(processSpecification);

            var domainEvent = new ProcessFindDomainEvent(Guid.NewGuid(), DateTime.UtcNow);

            await this._integrateBus.PublishAsync(domainEvent);

            return Result.Ok(foundProcess.Value);
        }
    }
}
