using System;

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

        public new void SetBoundedContext(IBoundedContext boundedContext)
        {
            BoundedContext = boundedContext as WatcherContext;
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
