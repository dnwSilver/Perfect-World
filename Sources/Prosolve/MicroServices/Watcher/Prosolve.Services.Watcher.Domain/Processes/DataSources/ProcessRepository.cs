using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Prosolve.Services.Watcher.Domain.Processes.Factories;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Infrastructure.Repositories;

namespace Prosolve.Services.Watcher.Domain.Processes.DataSources
{
    /// <summary>
    ///     Репозиторий для сущности <see cref="IProcessAggregate"/>.
    /// </summary>
    public class ProcessRepository: EntityFrameworkRepositoryBase<IProcessAggregate, ProcessDataModel, IProcessBuilder>
    {
        /// <summary>
        ///     Инициализация репозитория <see cref="ProcessRepository"/>.
        /// </summary>
        /// <param name="processFactory"> Фабрика для создания объектов. </param>
        /// <param name="mapper"> Механизм для трансформации объектов. </param>
        public ProcessRepository(IEntityFactory<IProcessAggregate> processFactory, IMapper mapper)
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
                if (BoundedContext is WatcherContext watcherContext)
                    return watcherContext;

                throw new NotImplementedException();
            }
        }

        public void SetBoundedContext(IBoundedContext boundedContext)
        {
            BoundedContext = boundedContext as WatcherContext;
        }

        /// <summary>
        ///     Обновление набора процессов.
        /// </summary>
        /// <param name="processes"> Список процессов. </param>
        /// <returns>
        ///     True - обновление выполнено успешно.
        ///     False - обновление не выполнено.
        /// </returns>
        public Task UpdateAsync(IEnumerable<IProcessAggregate> processes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Удаление объектов.
        /// </summary>
        /// <param name="objectsToRemove"> Список бизнес объектов. </param>
        /// <returns>
        ///     True - удаление выполнено успешно.
        ///     False - удаление не выполнено.
        /// </returns>
        public Task DeleteAsync(IEnumerable<IProcessAggregate> objectsToRemove)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Контекст для работы с таблицей.
        /// </summary>
        /// <returns> </returns>
        protected override DbSet<ProcessDataModel> DbSetEntity()
        {
            return WatcherContext.Processes;
        }
    }
}
