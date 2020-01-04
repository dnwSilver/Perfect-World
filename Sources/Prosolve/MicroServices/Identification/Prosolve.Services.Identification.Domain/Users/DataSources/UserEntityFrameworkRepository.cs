using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Prosolve.Services.Identification.Users.Factories;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Infrastructure.Repositories;

namespace Prosolve.Services.Identification.Users.DataSources
{
    /// <summary>
    ///     Виртуальный репозиторий для тестов.
    /// </summary>
    internal class UserEntityFrameworkRepository:
            EntityFrameworkRepositoryBase<IUserEntity, UserDataModel, IUserBuilder>,
            IEntityRepository<IUserEntity>
    {
        /// <summary>
        ///     Инициализация репозитория <see cref="EntityFrameworkRepositoryBase{TEntity,TDataModel,TEntityBuilder}"/>.
        /// </summary>
        /// <param name="mapper"> Механизм для трансформации объектов. </param>
        /// <param name="entityFactory"> Фабрика для создания объектов. </param>
        public UserEntityFrameworkRepository(IEntityFactory<IUserEntity> entityFactory, IMapper mapper)
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
                if (BoundedContext is IdentificationContext identificationContext)
                    return identificationContext;

                // todo Тут как-бы надо что-то придумать. Нельзя просто так оставит не имплеминтированный метод.
                throw new NotImplementedException();
            }
        }

        public void SetBoundedContext(IBoundedContext boundedContext)
        {
            BoundedContext = boundedContext as IdentificationContext;
        }

        /// <summary>
        ///     Обновление объектов.
        /// </summary>
        /// <param name="objectsToUpdate"> Список бизнес объектов. </param>
        /// <returns>
        ///     True - обновление выполнено успешно.
        ///     False - обновление не выполнено.
        /// </returns>
        public Task UpdateAsync(IEnumerable<IUserEntity> objectsToUpdate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Удаление объектов.
        /// </summary>
        /// <param name="objectsToRemove"> Список бизнес объектов. </param>
        /// <returns>
        ///     True - удаление выполнено успешно.
        ///     False - удаление не выполнено.
        /// </returns>
        public Task DeleteAsync(IEnumerable<IUserEntity> objectsToRemove)
        {
            throw new NotImplementedException();
        }

        protected override DbSet<UserDataModel> DbSetEntity()
        {
            return IdentificationContext.Users;
        }
    }
}
