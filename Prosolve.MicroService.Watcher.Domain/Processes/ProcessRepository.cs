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
        public ProcessRepository(WatcherContext watcherContext, IMapper mapper)
        {
            this.WatcherContext = watcherContext;
            this.Mapper = mapper;
        }

        private WatcherContext WatcherContext { get; }

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
        public async Task<Result> Create(IProcessEntity[] processes)
        {
            var processesSql = new List<ProcessDataModel>();

            foreach(var process in processes)
            {
                var processSql = new ProcessDataModel();
                processSql.PrivateId = process.Id.Private;
                processSql.PublicId = process.Id.Public;
                processSql.Name = process.Name;
                processSql.TypeName = process.TypeName;
                processSql.Version = process.CurrentVersion;
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

            using(var watcherContext = this.WatcherContext)
            {
                var processExpression =
                    this.Mapper.Map<Expression<Func<ProcessDataModel, bool>>>(
                        specification.Expression);

                var processModels =
                    await watcherContext.Processes.Where(processExpression).ToListAsync();

                var processes = new List<IProcessEntity>();

                if (processModels.Any())
                {
                    var processBuilders =
                        this.Mapper.Map<IList<ProcessDataModel>, IList<IProcessBuilder>>(
                            processModels);

                    processes.AddRange(from processBuilder in processBuilders
                                       let processFactory = new ProcessFactory()
                                       select processFactory.Recovery(processBuilder)
                                       into processEntity
                                       select processEntity.Value);
                }

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
                processSql.TypeName = process.TypeName;
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
