using System;
using System.Threading.Tasks;

using AutoMapper;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Infrastructure.Repositories;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.Services.Identification.Entities.Users
{
    /// <summary>
    ///     Виртуальный репозиторий для тестов.
    /// </summary>
    internal class UserRepository : RepositoryBase<IUserEntity>, IEntityRepository<IUserEntity>
    {
        /// <summary>
        ///     Инициализация репозитория <see cref="RepositoryBase{TEntity}" />.
        /// </summary>
        /// <param name="mapper">Механизм для трансформации объектов.</param>
        /// <param name="entityFactory">Фабрика для создания объектов.</param>
        public UserRepository(IEntityFactory<IUserEntity> entityFactory, IMapper mapper)
            : base(entityFactory, mapper)
        {
        }

        /// <summary>
        ///     Создание набора бизнес объектов.
        /// </summary>
        /// <param name="objectsToCreate">Список объектов для сохранения в хранилище.</param>
        /// <returns>
        ///     True - сохранение выполнено успешно.
        ///     False - сохранение не выполнено.
        /// </returns>
        public Task<Result> Create(IUserEntity[] objectsToCreate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Обновление объектов.
        /// </summary>
        /// <param name="objectsToUpdate">Список бизнес объектов.</param>
        /// <returns>
        ///     True - обновление выполнено успешно.
        ///     False - обновление не выполнено.
        /// </returns>
        public Task<Result> Update(IUserEntity[] objectsToUpdate)
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
        public Task<Result> Delete(IUserEntity[] objectsToRemove)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Поиск и получение необходимых бизнес объектов в источнике данных.
        /// </summary>
        /// <param name="searchParameters">Набор параметров для поиска.</param>
        /// <returns>Набор бизнес объектов.</returns>
        public Task<Result<IUserEntity[]>> Read(ISpecification<IUserEntity> searchParameters)
        {
            throw new NotImplementedException();
        }
    }
}
