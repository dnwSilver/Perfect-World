using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Prosolve.Services.Identification.Users.Factories;

using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Infrastructure.Repositories;

namespace Prosolve.Services.Identification.Users.DataSources
{
    /// <summary>
    ///     Виртуальный репозиторий для тестов.
    /// </summary>
    internal class UserFrameworkRepository:
            EntityFrameworkRepositoryBase<IUserAggregate, UserDataModel, IUserBuilder>
    {
        /// <summary>
        ///     Инициализация репозитория <see cref="EntityFrameworkRepositoryBase{TEntity,TDataModel,TEntityBuilder}"/>.
        /// </summary>
        /// <param name="mapper"> Механизм для трансформации объектов. </param>
        /// <param name="entityFactory"> Фабрика для создания объектов. </param>
        public UserFrameworkRepository(IEntityFactory<IUserAggregate> entityFactory, IMapper mapper)
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

        /// <summary>
        ///     Обновление объектов.
        /// </summary>
        /// <param name="objectsToUpdate"> Список бизнес объектов. </param>
        /// <returns>
        ///     True - обновление выполнено успешно.
        ///     False - обновление не выполнено.
        /// </returns>
        public Task UpdateAsync(IEnumerable<IUserAggregate> objectsToUpdate)
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
        public Task DeleteAsync(IEnumerable<IUserAggregate> objectsToRemove)
        {
            throw new NotImplementedException();
        }

        protected override DbSet<UserDataModel> DbSetEntity()
        {
            return IdentificationContext.Users;
        }
    }
}
