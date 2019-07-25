using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using Prosolve.MicroService.Watcher.DataAccess;

using Sharpdev.SDK.Extensions;
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
            List<ProcessDataModel> processesSql = new List<ProcessDataModel>();

            foreach(IProcessEntity process in processes)
            {
                ProcessDataModel processSql = new ProcessDataModel();
                processSql.PrivateId = process.Id.Private;
                processSql.PublicId = process.Id.Public;
                processSql.Name = process.Name;
                processSql.Type = process.Type.Id.Private;
                processesSql.Add(processSql);
            }

            using WatcherContext watcherContext = new WatcherContext();

            using IDbContextTransaction contextTransaction =
                watcherContext.Database.BeginTransaction();

            await watcherContext.Processes.AddRangeAsync(processesSql);
            int countEntriesWritten = await watcherContext.SaveChangesAsync();

            if (countEntriesWritten != processes.Length)
                return Result.Fail("Что-то пошло не так.");

            contextTransaction.Commit();

            return Result.Ok();
        }

        /// <summary>
        ///     Поиск и получение необходимых бизнес объектов в источнике данных.
        /// </summary>
        /// <param name="specification">Набор параметров для поиска.</param>
        /// <returns>Набор бизнес объектов.</returns>
        public async Task<Result<IProcessEntity[]>> Read(
            ISpecification<IProcessEntity> specification)
        {
            WatcherContext watcherContext = new WatcherContext();
            Expression<Func<ProcessDataModel, bool>> expression = specification
                                                                  .Expression
                                                                  .RemapForType<IProcessEntity,
                                                                      ProcessDataModel, bool>();
            var processes =
                await watcherContext.Processes.Where(expression).ProjectTo<IProcessEntity>().ToListAsync();

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
        public async Task<Result> Update(IProcessEntity[] processes)
        {
            List<ProcessDataModel> processesSql = new List<ProcessDataModel>();

            foreach(IProcessEntity process in processes)
            {
                ProcessDataModel processSql = new ProcessDataModel();
                processSql.PrivateId = process.Id.Private;
                processSql.PublicId = process.Id.Public;
                processSql.Name = process.Name;
                processSql.Type = process.Type.Id.Private;
                processesSql.Add(processSql);
            }

            using WatcherContext watcherContext = new WatcherContext();

            using IDbContextTransaction contextTransaction =
                watcherContext.Database.BeginTransaction();

            await watcherContext.Processes.AddRangeAsync(processesSql);
            int countEntriesWritten = watcherContext.SaveChanges();

            if (countEntriesWritten != processes.Length)
                return Result.Fail("Что-то пошло не так.");

            contextTransaction.Commit();

            return Result.Ok();
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
