using System;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Prosolve.Services.Watcher.Domain.Processes.Factories;

using Sharpdev.SDK.DataSources.Databases;
using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Domain.Factories;

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
        /// <param name="entityMapper"> Механизм для трансформации объектов. </param>
        /// <param name="boundedContext"> Контекст базы данных. </param>
        public ProcessRepository(IEntityFactory<IProcessAggregate> processFactory,
                                 IMapper entityMapper,
                                 IBoundedContext boundedContext)
                : base(processFactory, entityMapper, boundedContext)
        {
        }

        /// <summary>
        ///     Контекст для работы с таблицей.
        /// </summary>
        /// <returns> </returns>
        protected override DbSet<ProcessDataModel> DbSetEntity()
        {
            if (BoundedContext is WatcherContext watcherContext)
                return watcherContext.Processes;
            throw new NotImplementedException();
        }
    }
}
