using System;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Prosolve.Services.Identification.Users.Factories;

using Sharpdev.SDK.DataSources.Databases;
using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Domain.Factories;

namespace Prosolve.Services.Identification.Users.DataSources
{
    /// <summary>
    ///     Виртуальный репозиторий для тестов.
    /// </summary>
    internal class UserFrameworkRepository: EntityFrameworkRepositoryBase<IUserAggregate, UserDataModel, IUserBuilder>
    {
        /// <summary>
        ///     Инициализация репозитория <see cref="EntityFrameworkRepositoryBase{TEntity,TDataModel,TEntityBuilder}"/>.
        /// </summary>
        /// <param name="entityMapper"> Механизм для трансформации объектов. </param>
        /// <param name="entityFactory"> Фабрика для создания объектов. </param>
        /// <param name="boundedContext"> Контекст базы данных. </param>
        public UserFrameworkRepository(IEntityFactory<IUserAggregate> entityFactory, IMapper entityMapper,
                                       IBoundedContext boundedContext)
                : base(entityFactory, entityMapper, boundedContext)
        {
        }

        /// <summary>
        ///     Контекст источника данных.
        /// </summary>
        protected override DbSet<UserDataModel> DbSetEntity()
        {
            if (BoundedContext is IdentificationContext identificationContext)
                return identificationContext.Users;

            // todo Тут как-бы надо что-то придумать. Нельзя просто так оставит не имплеминтированный метод.
            throw new NotImplementedException();
        }
    }
}
