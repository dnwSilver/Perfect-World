using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Prosolve.Services.Watcher.Domain.Processes.Factories;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Infrastructure.Repositories;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.Services.Watcher.Domain.Processes.DataSources
{
    /// <summary>
    ///     Репозиторий для сущности <see cref="IProcessEntity" />.
    /// </summary>
    public class ProcessRepository : RepositoryBase<IProcessEntity>,
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
            // todo Я точно уверен что всё это можно вынести в базовый абстрактный класс. Нужно потратить на это часок другой. 
            var processExpression =
                this.Mapper.Map<Expression<Func<ProcessDataModel, bool>>>(specification.Expression);

            var processModels =
                await this.WatcherContext.Processes.Where(processExpression).ToListAsync();

            if (!processModels.Any())
                return Result.Ok(Array.Empty<IProcessEntity>());
            
            var processBuilders =
                this.Mapper.Map<IList<ProcessDataModel>, IList<IProcessBuilder>>(processModels);

            var processes = new List<IProcessEntity>();
            processes.AddRange(from processBuilder in processBuilders
                               let processFactory = this.EntityFactory
                               select processFactory.Recovery(processBuilder)
                               into processEntity
                               select processEntity.Value);

            return Result.Ok(processes.ToArray());
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
    }
}
