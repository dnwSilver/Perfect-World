using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using AutoMapper;

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
    public abstract class RepositoryBase<TEntity>
        where TEntity : IEntity<TEntity>
    {
        /// <summary>
        /// </summary>
        protected IBoundedContext? BoundedContext;

        /// <summary>
        ///     Инициализация репозитория <see cref="RepositoryBase{TEntity}" />.
        /// </summary>
        /// <param name="mapper">Механизм для трансформации объектов.</param>
        /// <param name="entityFactory">Фабрика для создания объектов.</param>
        protected RepositoryBase(IEntityFactory<TEntity> entityFactory, IMapper mapper)
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
        public void SetBoundedContext(IBoundedContext boundedContext)
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
        
        protected async Task<Result<TEntity[]>> Read<TEntityBuilder, TDataModel>(ISpecification<TEntity> specification)
            where TEntityBuilder: IEntityBuilder<TEntity>
        {
            var userExpression =
                this.Mapper.Map<Expression<Func<TDataModel, bool>>>(specification.Expression);

            var dataModels =
                await this.BoundedContext.Users.Where(userExpression).ToListAsync();

            if (!dataModels.Any())
                return Result.Ok(Array.Empty<TEntity>());
            
            var builders =
                this.Mapper.Map<IList<TDataModel>, IList<TEntityBuilder>>(dataModels);

            var entities = new List<TEntity>();
            entities.AddRange(from builder in builders
                              let factory = this.EntityFactory
                              select factory.Recovery(builder)
                              into entity
                              select entity.Value);

            return Result.Ok(entities.ToArray());
        }
    }
}
