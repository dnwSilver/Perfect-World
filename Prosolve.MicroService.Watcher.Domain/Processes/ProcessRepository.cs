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
        private bool _disposed;

        public ProcessRepository(WatcherContext watcherContext)
        {
            this.WatcherContext = watcherContext;
        }

        private WatcherContext WatcherContext { get; }

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
        public async Task<Result> Create(IProcessEntity[] processes)
        {
            var processesSql = new List<ProcessDataModel>();

            foreach(var process in processes)
            {
                var processSql = new ProcessDataModel();
                processSql.PrivateId = process.Id.Private;
                processSql.PublicId = process.Id.Public;
                processSql.Name = process.Name;
                processSql.Type = process.Type.Id.Private;
                processesSql.Add(processSql);
            }

            using(var watcherContext = this.WatcherContext)
            {
                using(var contextTransaction = watcherContext.Database.BeginTransaction())
                {
                    await watcherContext.Processes.AddRangeAsync(processesSql);
                    var countEntriesWritten = await watcherContext.SaveChangesAsync();

                    if (countEntriesWritten != processes.Length)
                        return Result.Fail("Что-то пошло не так.");

                    contextTransaction.Commit();
                }

                return Result.Ok();
            }
        }

        /// <summary>
        ///     Поиск и получение необходимых бизнес объектов в источнике данных.
        /// </summary>
        /// <param name="specification">Набор параметров для поиска.</param>
        /// <returns>Набор бизнес объектов.</returns>
        public async Task<Result<IProcessEntity[]>> Read(
            ISpecification<IProcessEntity> specification)
        {
            var resultErrors = new List<IResultError>();

            if (resultErrors.Any())
                return Result.Fail<IProcessEntity[]>(resultErrors);
            
            //or
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IProcessEntity, ProcessDataModel>()
                                                           .ForMember(dto => dto.Name, conf => conf.MapFrom(ol => ol.Name)));
            var mapper = config.CreateMapper();
            /*
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<IProcessEntity, ProcessDataModel>()
                   .ForMember(dto => dto.Name, conf => conf.MapFrom(ol => ol.Name));
                cfg.CreateMap<ProcessEntity, ProcessDataModel>()
                   .ForMember(dto => dto.Name, conf => conf.MapFrom(ol => ol.Name));
                cfg.CreateMap<ProcessDataModel, IProcessEntity>()
                   .ForMember(dto => dto.Name, conf => conf.MapFrom(ol => ol.Name));
                cfg.CreateMap<ProcessDataModel, ProcessEntity>()
                   .ForMember(dto => dto.Name, conf => conf.MapFrom(ol => ol.Name));
            });
            */

            using(var watcherContext = this.WatcherContext)
            {
                var expression =
                    mapper.Map<Expression<Func<ProcessDataModel, bool>>>(specification.Expression);
                var processes1 = await watcherContext.Processes.Where(expression).ToListAsync();
                processes1.Clear();
                var processes = new List<IProcessEntity>();

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
        public async Task<Result> Update(IProcessEntity[] processes)
        {
            var processesSql = new List<ProcessDataModel>();

            foreach(var process in processes)
            {
                var processSql = new ProcessDataModel();
                processSql.PrivateId = process.Id.Private;
                processSql.PublicId = process.Id.Public;
                processSql.Name = process.Name;
                processSql.Type = process.Type.Id.Private;
                processesSql.Add(processSql);
            }

            using(var watcherContext = this.WatcherContext)
            {
                using(var contextTransaction = watcherContext.Database.BeginTransaction())
                {
                    await watcherContext.Processes.AddRangeAsync(processesSql);
                    var countEntriesWritten = watcherContext.SaveChanges();

                    if (countEntriesWritten != processes.Length)
                        return Result.Fail("Что-то пошло не так.");

                    contextTransaction.Commit();

                    return Result.Ok();
                }
            }
        }

        /// <summary>
        ///     Удаление объектов.
        /// </summary>
        /// <param name="objectsToRemove">Список бизнес объектов.</param>
        /// <returns>
        ///     True - удаление выполнено успешно.
        ///     False - удаление не выполнено.
        /// </returns>
        public async Task<Result> Delete(IProcessEntity[] objectsToRemove)
        {
            throw new NotImplementedException();
        }
    }
}
