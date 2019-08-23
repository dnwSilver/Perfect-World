using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using AutoMapper;

using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Infrastructure.Repositories;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.Services.Identification.Entities.Users.DataSources
{
    /// <summary>
    ///     Виртуальный репозиторий для тестов.
    /// </summary>
    internal class UserRepository : RepositoryBase<IUserEntity, UserDataModel, IUserBuilder>,
                                    IEntityRepository<IUserEntity>
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
        ///     Контекст источника данных.
        /// </summary>
        private IdentificationContext IdentificationContext
        {
            get
            {
                if (this.BoundedContext is IdentificationContext identificationContext)
                    return identificationContext;

                throw new NotImplementedException();
            }
        }

        /// <summary>
        ///     Создание набора бизнес объектов.
        /// </summary>
        /// <param name="objectsToCreate">Список объектов для сохранения в хранилище.</param>
        /// <returns>
        ///     True - сохранение выполнено успешно.
        ///     False - сохранение не выполнено.
        /// </returns>
        public async Task<Result> Create(IUserEntity[] objectsToCreate)
        {
            var userDataModels =
                this.Mapper.Map<IList<IUserEntity>, IList<UserDataModel>>(objectsToCreate);
            this.IdentificationContext.Users.Add(userDataModels[0]);
            await this.IdentificationContext.SaveChangesAsync();

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

        protected override IEnumerable<UserDataModel> ReadQuery(
            Expression<Func<UserDataModel, bool>> specification)
        {
            return this.IdentificationContext.Users.Where(specification);
        }
    }
}
