using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Domain.Specifications;
using Sharpdev.SDK.Infrastructure.Repositories;

namespace Sharpdev.SDK.DataSources.Databases
{
    /// <summary>
    ///     Базовая реализация для любых потомков интерфейса <see cref="IRepository{TAggregate}"/>.
    /// </summary>
    /// <typeparam name="TEntity"> Сущность для которой предназначено хранилище. </typeparam>
    /// <typeparam name="TDataModel"> Модель данных в источнике данных. </typeparam>
    /// <typeparam name="TEntityBuilder"> Строитель для объекта. </typeparam>
    public abstract class EntityFrameworkRepositoryBase<TEntity, TDataModel, TEntityBuilder>: IRepository<TEntity>
            where TEntity: IAggregate<TEntity>
            where TEntityBuilder: IEntityBuilder<TEntity>
            where TDataModel: class
    {
        /// <summary>
        ///     Контекст базы данных.
        /// </summary>
        protected readonly DbContext BoundedContext;

        /// <summary>
        ///     Инициализация репозитория <see cref="EntityFrameworkRepositoryBase{TEntity,TDataModel,TEntityBuilder}"/>.
        /// </summary>
        /// <param name="entityMapper"> Механизм для трансформации объектов. </param>
        /// <param name="entityFactory"> Фабрика для создания объектов. </param>
        /// <param name="boundedContext"> Контекст базы данных. </param>
        protected EntityFrameworkRepositoryBase(IEntityFactory<TEntity> entityFactory,
                                                IMapper entityMapper,
                                                IBoundedContext boundedContext)
        {
            EntityMapper = entityMapper;
            EntityFactory = entityFactory;
            BoundedContext = boundedContext as DbContext;
        }

        /// <summary>
        ///     Фабрика для сборки объектов.
        /// </summary>
        private IEntityFactory<TEntity> EntityFactory { get; }

        /// <summary>
        ///     Механизм для трансформации объектов.
        /// </summary>
        private IMapper EntityMapper { get; }

        public Task DeleteAsync(IEnumerable<TEntity> objectsToRemove)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Поиск и получение необходимых бизнес объектов в источнике данных.
        /// </summary>
        /// <param name="specification"> Набор параметров для поиска. </param>
        /// <returns> Набор бизнес объектов. </returns>
        public async Task<IEnumerable<TEntity>> ReadAsync(ISpecification<TEntity> specification)
        {
            var specificationCriteria = EntityMapper.Map<Expression<Func<TDataModel, bool>>>(specification.Criteria);
            var dataModels = await DbSetEntity()
                                  .Where(specificationCriteria)
                                  .ToArrayAsync();

            if (!dataModels.Any())
                return Enumerable.Empty<TEntity>();

            var builders = EntityMapper.Map<TDataModel[], TEntityBuilder[]>(dataModels);

            return  from builder in builders
                    let factory = EntityFactory
                    select factory.Recovery(builder)
                    into entity
                    select entity;
        }

        public Task UpdateAsync(IEnumerable<TEntity> objectsToUpdate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Создание набора бизнес объектов.
        /// </summary>
        /// <param name="objectsToCreate"> Список объектов для сохранения в хранилище. </param>
        /// <returns>
        ///     True - сохранение выполнено успешно.
        ///     False - сохранение не выполнено.
        /// </returns>
        public async Task CreateAsync(IEnumerable<TEntity> objectsToCreate)
        {
            var userDataModels = EntityMapper.Map<IEnumerable<TEntity>, IEnumerable<TDataModel>>(objectsToCreate);

            await DbSetEntity()
                   .AddRangeAsync(userDataModels);

        }

        /// <summary>
        ///     Контекст для работы с таблицей.
        /// </summary>
        /// <returns> </returns>
        protected abstract DbSet<TDataModel> DbSetEntity();
    }
}
