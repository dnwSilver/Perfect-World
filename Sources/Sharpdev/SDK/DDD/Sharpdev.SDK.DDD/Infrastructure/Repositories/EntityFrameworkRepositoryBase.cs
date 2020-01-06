using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Domain.Factories;

namespace Sharpdev.SDK.Infrastructure.Repositories
{
    /// <summary>
    ///     Базовая реализация для любых потомков интерфейса <see cref="IRepository{TAggregate}"/>.
    /// </summary>
    /// <typeparam name="TEntity"> Сущность для которой предназначено хранилище. </typeparam>
    /// <typeparam name="TDataModel"> Модель данных в источнике данных. </typeparam>
    /// <typeparam name="TEntityBuilder"> Строитель для объекта. </typeparam>
    public abstract class EntityFrameworkRepositoryBase<TEntity, TDataModel, TEntityBuilder>: IRepository<TEntity>
            where TEntity: IEntity<TEntity>, IAggregate<TEntity>
            where TEntityBuilder: IEntityBuilder<TEntity>
            where TDataModel: class
    {
        /// <summary>
        /// </summary>
        protected DbContext? BoundedContext;

        /// <summary>
        ///     Инициализация репозитория <see cref="EntityFrameworkRepositoryBase{TEntity,TDataModel,TEntityBuilder}"/>.
        /// </summary>
        /// <param name="mapper"> Механизм для трансформации объектов. </param>
        /// <param name="entityFactory"> Фабрика для создания объектов. </param>
        protected EntityFrameworkRepositoryBase(IEntityFactory<TEntity> entityFactory, IMapper mapper)
        {
            Mapper = mapper;
            EntityFactory = entityFactory;
        }

        /// <summary>
        ///     Фабрика для сборки объектов.
        /// </summary>
        private IEntityFactory<TEntity> EntityFactory { get; }

        /// <summary>
        ///     Механизм для трансформации объектов.
        /// </summary>
        private IMapper Mapper { get; }

        public Task DeleteAsync(IEnumerable<TEntity> objectsToRemove)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="boundedContext"> </param>
        public void SetBoundedContext(IBoundedContext boundedContext)
        {
            //todo Добавить выбрасывание ошибки.
            BoundedContext = boundedContext as DbContext;
        }

        /// <summary>
        ///     Контекст для работы с таблицей.
        /// </summary>
        /// <returns> </returns>
        protected abstract DbSet<TDataModel> DbSetEntity();

        /// <summary>
        ///     Поиск и получение необходимых бизнес объектов в источнике данных.
        /// </summary>
        /// <param name="specification"> Набор параметров для поиска. </param>
        /// <returns> Набор бизнес объектов. </returns>
        public async Task<IEnumerable<TEntity>> ReadAsync(ISpecification<TEntity> specification)
        {
            var userExpression =
                    Mapper.Map<Expression<Func<TDataModel, bool>>>(specification.Expression);

            var dataModels = await DbSetEntity()
                                  .Where(userExpression)
                                  .ToListAsync();

            if (!dataModels.Any())
                return Enumerable.Empty<TEntity>();

            var builders = Mapper.Map<IList<TDataModel>, IList<TEntityBuilder>>(dataModels);

            var entities = new List<TEntity>();

            entities.AddRange(
                    from builder in builders
                    let factory = EntityFactory
                    select factory.Recovery(builder)
                    into entity
                    select entity.Value);

            return entities;
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
            var userDataModels = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDataModel>>(objectsToCreate);

            await DbSetEntity().AddRangeAsync(userDataModels);

            try
            {
                await BoundedContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                // todo Обязательно сюда добавить лог и Debug.Assert
                throw new Exception("Вот так беда. Ничего не получилось.", exception);
            }
        }
    }
}
