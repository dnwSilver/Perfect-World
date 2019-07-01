using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Layers.Domain.Factories;
using Sharpdev.SDK.Layers.Infrastructure.Repositories;
using Sharpdev.SDK.Types.Results;

namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Виртуальный репозиторий для тестов.
    /// </summary>
    /// <typeparam name="TEntity">Тип хранимого объекта.</typeparam>
    public class RepositoryMock<TEntity> : IRepository<TEntity>
        where TEntity : IEntity<TEntity>
    {
        /// <summary>
        ///     Хранилище объектов в оперативной памяти.
        /// </summary>
        private readonly IList<TEntity> _memoryRepository = new List<TEntity>();

        /// <summary>
        ///     Текущий статус объекта.
        /// </summary>
        /// <returns>Статус объекта.</returns>
        public RepositoryStatus Status { get; private set; } = RepositoryStatus.Up;

        /// <summary>
        ///     Смена статуса.
        /// </summary>
        /// <param name="newState">Новый статус.</param>
        public void ChangeStatus(RepositoryStatus newState)
        {
            Status = newState;
        }

        /// <summary>
        ///     Создание набора бизнес объектов.
        /// </summary>
        /// <param name="objectsToCreate">Список объектов для сохранения в хранилище.</param>
        /// <returns>
        ///     True - сохранение выполнено успешно.
        ///     False - сохранение не выполнено.
        /// </returns>
        public Result Create(IEnumerable<TEntity> objectsToCreate)
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
        ///     Поиск и получение необходимых бизнес объектов в источнике данных.
        /// </summary>
        /// <param name="searchParameters">Набор параметров для поиска.</param>
        /// <returns>Набор бизнес объектов.</returns>
        public Result<IEnumerable<TEntity>> Read(ISearchParameters<TEntity> searchParameters)
        {
            IEnumerable<TEntity> output = _memoryRepository
                                          .Skip(searchParameters.Skip.Value)
                                          .Take(searchParameters.Take.Value);

            return Result.Ok(output);
        }

        /// <summary>
        ///     Обновление объектов.
        /// </summary>
        /// <param name="objectsToUpdate">Список бизнес объектов.</param>
        /// <returns>
        ///     True - обновление выполнено успешно.
        ///     False - обновление не выполнено.
        /// </returns>
        public Result Update(IEnumerable<TEntity> objectsToUpdate)
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
        public Result Delete(IEnumerable<TEntity> objectsToRemove)
        {
            foreach(var entity in objectsToRemove)
            {
                if (_memoryRepository.All(x => x.Id != entity.Id))
                    return Result.Fail(TextResultError.Create("Объект не найден."));

                _memoryRepository.Remove(_memoryRepository.First(x => x.Id == entity.Id));
            }

            return Result.Ok();
        }
    }
}
