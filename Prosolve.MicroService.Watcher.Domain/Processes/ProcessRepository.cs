using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Prosolve.MicroService.Watcher.DataAccess;

using Sharpdev.SDK.Layers.Domain;
using Sharpdev.SDK.Layers.Infrastructure.Repositories;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.MicroService.Watcher.Domain.Processes
{
    /// <summary>
    ///     Репозиторий для сущности <see cref="IProcessEntity" />.
    /// </summary>
    public class ProcessRepository : IRepository<IProcessEntity>
    {
        /// <summary>
        ///     Инициализация репозитория <see cref="ProcessRepository" />.
        /// </summary>
        /// <param name="watcherContext">Контекст источника данных.</param>
        /// <param name="mapper">Механизм для трансформации объектов.</param>
        public ProcessRepository(WatcherContext watcherContext, IMapper mapper)
        {
            this.WatcherContext = watcherContext;
            this.Mapper = mapper;
        }

        /// <summary>
        ///     Контекст источника данных.
        /// </summary>
        private WatcherContext WatcherContext { get; }

        /// <summary>
        ///     Механизм для трансформации объектов.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        ///     Текущий статус объекта.
        /// </summary>
        /// <returns>Статус объекта.</returns>
        public RepositoryStatus Status { get; private set; }

        /// <summary>
        ///     Смена статуса.
        /// </summary>
        /// <param name="newStatus">Новый статус.</param>
        public void ChangeStatus(RepositoryStatus newStatus)
        {
            this.Status = newStatus;
        }

        /// <summary>
        ///     Создание набора бизнес объектов.
        /// </summary>
        /// <param name="processes">Список объектов для сохранения в хранилище.</param>
        /// <returns>
        ///     True - сохранение выполнено успешно.
        ///     False - сохранение не выполнено.
        /// </returns>
        public Task<Result> Create(IProcessEntity[] processes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Поиск и получение необходимых бизнес объектов в источнике данных.
        /// </summary>
        /// <param name="specification">Набор параметров для поиска.</param>
        /// <returns>Набор бизнес объектов.</returns>
        public async Task<Result<IProcessEntity[]>> Read(
            ISpecification<IProcessEntity> specification)
        {
            using(var watcherContext = this.WatcherContext)
            {
                var processExpression =
                    this.Mapper.Map<Expression<Func<ProcessDataModel, bool>>>(
                        specification.Expression);

                var processModels =
                    await watcherContext.Processes.Where(processExpression).ToListAsync();

                if (!processModels.Any())
                    return Result.Ok(Array.Empty<IProcessEntity>());

                var processBuilders =
                    this.Mapper.Map<IList<ProcessDataModel>, IList<IProcessBuilder>>(processModels);

                var processes = new List<IProcessEntity>();
                processes.AddRange(from processBuilder in processBuilders
                                   let processFactory = new ProcessFactory()
                                   select processFactory.Recovery(processBuilder)
                                   into processEntity
                                   select processEntity.Value);

                return Result.Ok(processes.ToArray());
            }
        }

        /// <summary>
        ///     Обновление набора процессов.
        /// </summary>
        /// <param name="processes">Список процессов.</param>
        /// <returns>
        ///     True - обновление выполнено успешно.
        ///     False - обновление не выполнено.
        /// </returns>
        public Task<Result> Update(IProcessEntity[] processes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Удаление объектов.
        /// </summary>
        /// <param name="objectsToRemove">Список бизнес объектов.</param>
        /// <returns>
        ///     True - удаление выполнено успешно.
        ///     False - удаление не выполнено.
        /// </returns>
        public Task<Result> Delete(IProcessEntity[] objectsToRemove)
        {
            throw new NotImplementedException();
        }
    }
}
