using AutoMapper;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Domain.Factories;

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
        /// 
        /// </summary>
        protected IBoundedContext BoundedContext;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="boundedContext"></param>
        public void SetBoundedContext(IBoundedContext boundedContext)
        {
            this.BoundedContext = boundedContext;
        }
        
        /// <summary>
        ///     Инициализация репозитория <see cref="RepositoryBase{TEntity}" />.
        /// </summary>
        /// <param name="mapper">Механизм для трансформации объектов.</param>
        /// <param name="entityFactory">Фабрика для создания объектов.</param>
        protected RepositoryBase(IMapper mapper, IEntityFactory<TEntity> entityFactory)
        {
            this.EntityFactory = entityFactory;
            this.Mapper = mapper;
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
        ///     Смена статуса.
        /// </summary>
        /// <param name="newStatus">Новый статус.</param>
        public void ChangeStatus(RepositoryStatus newStatus)
        {
            this.Status = newStatus;
        }
    }
}
