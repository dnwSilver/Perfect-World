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
    ///     Сервис по управлению процессами <see cref="IProcessAggregate" /> протекающими в системе.
    /// </summary>
    internal class ProcessService
    {
        /// <summary>
        ///     Шина для обмена сообщениями.
        /// </summary>
        private readonly IIntegrateBus _integrateBus;

        /// <summary>
        ///     Репозиторий для работы с <see cref="IProcessAggregate" />.
        /// </summary>
        private readonly IRepository<IProcessAggregate> _processRepository;

        /// <summary>
        ///     Механизм для работы с репозиториями.
        /// </summary>
        private readonly IUnitOfWork<WatcherContext> _unitOfWork;

        /// <summary>
        ///     Инициализация объекта <see cref="ProcessService" />.
        /// </summary>
        /// <param name="unitOfWork">Механизм для работы с репозиториями.</param>
        /// <param name="integrateBus">Шина для обмена сообщениями.</param>
        /// <param name="processRepository">Репозиторий для работы с <see cref="IProcessAggregate" />.</param>
        public ProcessService(IUnitOfWork<WatcherContext> unitOfWork,
                              IIntegrateBus integrateBus,
                              IRepository<IProcessAggregate> processRepository)
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
        public async Task<Result<IEnumerable<IProcessAggregate>>> Find(
            ISpecification<IProcessAggregate> processSpecification)
        {
            using var uow = this._unitOfWork;

            this._processRepository.SetBoundedContext(uow.BoundedContext);

            var foundProcess = await this._processRepository.ReadAsync(processSpecification);

            var domainEvent = new ProcessFindDomainEvent(Guid.NewGuid(), DateTime.UtcNow, string.Empty);

            await this._integrateBus.PublishAsync(domainEvent);

            return Result.Done(foundProcess);
        }
    }
}
