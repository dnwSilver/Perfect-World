using System.Threading.Tasks;

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
        ///     Репозиторий для работы с процессами <see cref="IProcessEntity" />.
        /// </summary>
        private readonly IRepository<IProcessEntity> _processRepository;

        /// <summary>
        ///     Инициализация сервиса для работы с процессами.
        /// </summary>
        /// <param name="processRepository"></param>
        public ProcessService(IRepository<IProcessEntity> processRepository)
        {
            this._processRepository = processRepository;
        }

        /// <summary>
        ///     Поиск процессов.
        /// </summary>
        /// <param name="processSpecification">Набор спецификаций для поиска процессов.</param>
        /// <returns>Список найденных процессов.</returns>
        public async Task<Result<IProcessEntity[]>> Find(
            ISpecification<IProcessEntity> processSpecification)
        {
            var foundProcess = await this._processRepository.Read(processSpecification);

            return Result.Ok<IProcessEntity[]>(foundProcess);
        }
    }
}
