using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Sharpdev.SDK.Layers.Domain;
using Sharpdev.SDK.Layers.Infrastructure.Repositories;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.MicroService.Identity.Entities.Users
{
    /// <summary>
    ///     Виртуальный репозиторий для тестов.
    /// </summary>
    public class UserRepository : IRepository<IUser>
    {
        /// <summary>
        ///     Хранилище объектов в оперативной памяти.
        /// </summary>
        private readonly IList<IUser> _memoryRepository = new List<IUser>();

        /// <summary>
        ///     Текущий статус объекта.
        /// </summary>
        /// <returns>Статус объекта.</returns>
        public RepositoryStatus Status { get; private set; } = RepositoryStatus.Up;

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
        /// <param name="objectsToCreate">Список объектов для сохранения в хранилище.</param>
        /// <returns>
        ///     True - сохранение выполнено успешно.
        ///     False - сохранение не выполнено.
        /// </returns>
        public async Task<Result> Create(IUser[] objectsToCreate)
        {
            foreach(var entity in objectsToCreate)
            {
                if (_memoryRepository.Any(x => x.Id == entity.Id))
                    return Result.Fail(TextResultError.Create("Объект уже добавляли."));

                _memoryRepository.Add(entity);
            }

            return Result.Ok();
        }

        /// <summary>
        ///     Обновление объектов.
        /// </summary>
        /// <param name="objectsToUpdate">Список бизнес объектов.</param>
        /// <returns>
        ///     True - обновление выполнено успешно.
        ///     False - обновление не выполнено.
        /// </returns>
        public async  Task<Result> Update(IUser[] objectsToUpdate)
        {
            foreach(var entity in objectsToUpdate)
            {
                if (_memoryRepository.All(x => x.Id != entity.Id))
                    return Result.Fail(TextResultError.Create("Объект не найден."));

                _memoryRepository.Remove(_memoryRepository.First(x => x.Id == entity.Id));
                _memoryRepository.Add(entity);
            }

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
        public async Task<Result> Delete(IUser[] objectsToRemove)
        {
            foreach(var entity in objectsToRemove)
            {
                if (_memoryRepository.All(x => x.Id != entity.Id))
                    return Result.Fail(TextResultError.Create("Объект не найден."));

                _memoryRepository.Remove(_memoryRepository.First(x => x.Id == entity.Id));
            }

            return Result.Ok();
        }

        /// <summary>
        ///     Поиск и получение необходимых бизнес объектов в источнике данных.
        /// </summary>
        /// <param name="searchParameters">Набор параметров для поиска.</param>
        /// <returns>Набор бизнес объектов.</returns>
        public async Task<Result<IUser[]>> Read(ISpecification<IUser> searchParameters)
        {
            var output =
                _memoryRepository.ToArray();

            return Result.Ok(output);
        }
    }
}
