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
using Sharpdev.SDK.Types.Results;

namespace Sharpdev.SDK.Infrastructure.Repositories
{
    /// <summary>
    ///     Базовая реализация для любых потомков интерфейса <see cref="IEntityRepository{TEntity}" />.
    /// </summary>
    /// <typeparam name="TEntity">Сущность для которой предназначено хранилище.</typeparam>
    /// <typeparam name="TDataModel">Модель данных в источнике данных.</typeparam>
    /// <typeparam name="TEntityBuilder">Строитель для объекта.</typeparam>
    public abstract class EntityFrameworkRepositoryBase<TEntity, TDataModel, TEntityBuilder>
        where TEntity : IEntity<TEntity>
        where TEntityBuilder : IEntityBuilder<TEntity>
        where TDataModel : class
    {
        /// <summary>
        /// </summary>
        protected DbContext? BoundedContext;

        /// <summary>
        ///     Инициализация репозитория <see cref="EntityFrameworkEntityFrameworkRepositoryBase{TEntity,TDataModel,TEntityBuilder}" />.
        /// </summary>
        /// <param name="mapper">Механизм для трансформации объектов.</param>
        /// <param name="entityFactory">Фабрика для создания объектов.</param>
        protected EntityFrameworkRepositoryBase(IEntityFactory<TEntity> entityFactory, IMapper mapper)
        {
            this.Mapper = mapper;
            this.EntityFactory = entityFactory;
        }

        /// <summary>
        ///     Фабрика для сборки объектов.
        /// </summary>
        protected IEntityFactory<TEntity> EntityFactory { get; }

        /// <summary>
        ///     Текущий статус объекта.
        /// </summary>
        /// <returns>Статус объекта.</returns>
        public RepositoryStatus Status { get; private set; }

        /// <summary>
        ///     Механизм для трансформации объектов.
        /// </summary>
        protected IMapper Mapper { get; }

        /// <summary>
        /// </summary>
        /// <param name="boundedContext"></param>
        public void SetBoundedContext(DbContext boundedContext)
        {
            this.BoundedContext = boundedContext;
        }

        /// <summary>
        ///     Смена статуса.
        /// </summary>
        /// <param name="newStatus">Новый статус.</param>
        public void ChangeStatus(RepositoryStatus newStatus)
        {
            this.Status = newStatus;
        }
        
        /// <summary>
        /// Контекст для работы с таблицей.
        /// </summary>
        /// <returns></returns>
        protected abstract DbSet<TDataModel> DbSetEntity();
        
        /// <summary>
        ///     Поиск и получение необходимых бизнес объектов в источнике данных.
        /// </summary>
        /// <param name="specification">Набор параметров для поиска.</param>
        /// <returns>Набор бизнес объектов.</returns>
        public Task<Result<TEntity[]>> Read(ISpecification<TEntity> specification)
        {
            var userExpression =
                this.Mapper.Map<Expression<Func<TDataModel, bool>>>(specification.Expression);

            var dataModels = this.DbSetEntity().Where(userExpression).ToList();

            if (!dataModels.Any())
                return Task.Run(()=>Result.Ok(Array.Empty<TEntity>()));

            var builders = this.Mapper.Map<IList<TDataModel>, IList<TEntityBuilder>>(dataModels);

            var entities = new List<TEntity>();
            entities.AddRange(from builder in builders
                              let factory = this.EntityFactory
                              select factory.Recovery(builder)
                              into entity
                              select entity.Value);

            return Task.Run(()=>Result.Ok(entities.ToArray()));
        }
        
        
        /// <summary>
        ///     Создание набора бизнес объектов.
        /// </summary>
        /// <param name="objectsToCreate">Список объектов для сохранения в хранилище.</param>
        /// <returns>
        ///     True - сохранение выполнено успешно.
        ///     False - сохранение не выполнено.
        /// </returns>
        public async Task<Result> Create(TEntity[] objectsToCreate)
        {
            var userDataModels =
                this.Mapper.Map<IList<TEntity>, IList<TDataModel>>(objectsToCreate);
            
            await this.DbSetEntity().AddRangeAsync(userDataModels);

            try
            {
                await this.BoundedContext.SaveChangesAsync();
            }
            catch(Exception exception)
            {
                // todo Обязательно сюда добавить лог и Debug.Assert
                return Result.Fail(exception.Message);
            }
            return Result.Ok();
        }
    }
}
