using System.Collections.Generic;
using System.Threading.Tasks;

using Prosolve.MicroService.Watcher.DataAccess;

using Sharpdev.SDK.Layers.Domain;
using Sharpdev.SDK.Layers.Infrastructure.Repositories;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.MicroService.Watcher.Domain.Processes
{
    /// <summary>
    ///     Репозиторий для сущности <see cref="IProcessEntity"/>.
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
            Status = newStatus;
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
          
            using(var db = new WatcherContext())
            {
                using(var dbTransaction = db.Database.BeginTransaction())
                {
                    await db.Processes.AddRangeAsync(processesSql);
                    var countEntriesWritten = db.SaveChanges();

                    if (countEntriesWritten == processes.Length)
                    {
                        dbTransaction.Commit();
                        return Result.Ok();
                    }
                }
            }

            return Result.Fail("Что-то пошло не так.");
        }

        /// <summary>
        ///     Поиск и получение необходимых бизнес объектов в источнике данных.
        /// </summary>
        /// <param name="specification">Набор параметров для поиска.</param>
        /// <returns>Набор бизнес объектов.</returns>
        public Result<IProcessEntity[]> Read(ISpecification<IProcessEntity> specification)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///     Обновление объектов.
        /// </summary>
        /// <param name="objectsToUpdate">Список бизнес объектов.</param>
        /// <returns>
        ///     True - обновление выполнено успешно.
        ///     False - обновление не выполнено.
        /// </returns>
        public Result Update(IProcessEntity[] objectsToUpdate)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///     Удаление объектов.
        /// </summary>
        /// <param name="objectsToRemove">Список бизнес объектов.</param>
        /// <returns>
        ///     True - удаление выполнено успешно.
        ///     False - удаление не выполнено.
        /// </returns>
        public Result Delete(IProcessEntity[] objectsToRemove)
        {
            throw new System.NotImplementedException();
        }
    }
}
