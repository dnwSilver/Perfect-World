using System.Threading.Tasks;

using Prosolve.MicroService.Watcher.DataAccess;

using Sharpdev.SDK.Layers.Domain;
using Sharpdev.SDK.Layers.Infrastructure.Repositories;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.MicroService.Watcher.Domain.Processes
{
    /// <summary>
    ///     Сервис по управлению процессами <see cref="IProcessEntity" /> протекающими в системе.
    /// </summary>
    public class ProcessService
    {
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
        /// <param name="processRepository">Репозиторий для работы с <see cref="IProcessEntity" />.</param>
        public ProcessService(IUnitOfWork<WatcherContext> unitOfWork,
                              IEntityRepository<IProcessEntity> processRepository)
        {
            this._processRepository = processRepository;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     Поиск процессов.
        /// </summary>
        /// <param name="processSpecification">Набор спецификаций для поиска процессов.</param>
        /// <returns>Список найденных процессов.</returns>
        public async Task<Result<IProcessEntity[]>> Find(
            ISpecification<IProcessEntity> processSpecification)
        {
            using(var uow = this._unitOfWork)
            {
                this._processRepository.SetBoundedContext(uow.BoundedContext);

                var foundProcess = await this._processRepository.Read(processSpecification);

                return Result.Ok<IProcessEntity[]>(foundProcess);
            }
        }
    }
}
