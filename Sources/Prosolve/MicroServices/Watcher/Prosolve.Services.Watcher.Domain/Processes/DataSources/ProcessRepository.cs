using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using AutoMapper;

using Prosolve.Services.Watcher.Domain.Processes.Factories;

using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Infrastructure.Repositories;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.Services.Watcher.Domain.Processes.DataSources
{
    /// <summary>
    ///     Репозиторий для сущности <see cref="IProcessEntity" />.
    /// </summary>
    public class ProcessRepository :
        RepositoryBase<IProcessEntity, ProcessDataModel, IProcessBuilder>,
        IEntityRepository<IProcessEntity>
    {
        /// <summary>
        ///     Инициализация репозитория <see cref="ProcessRepository" />.
        /// </summary>
        /// <param name="processFactory">Фабрика для создания объектов.</param>
        /// <param name="mapper">Механизм для трансформации объектов.</param>
        public ProcessRepository(IEntityFactory<IProcessEntity> processFactory, IMapper mapper)
            : base(processFactory, mapper)
        {
        }

        /// <summary>
        ///     Контекст источника данных.
        /// </summary>
        private WatcherContext WatcherContext
        {
            get
            {
                if (this.BoundedContext is WatcherContext watcherContext)
                    return watcherContext;

                throw new NotImplementedException();
            }
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

        protected override IEnumerable<ProcessDataModel> ReadQuery(
            Expression<Func<ProcessDataModel, bool>> expression)
        {
            return this.WatcherContext.Processes.Where(expression);
        }
    }
}
