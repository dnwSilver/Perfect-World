using System.Collections.Generic;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Domain.Specifications;

namespace Sharpdev.SDK.Domain.Factories
{
    /// <summary>
    ///     Базовый класс для фабрики объектов.
    /// </summary>
    /// <typeparam name="TEntity">Тип объекта, который будем собирать.</typeparam>
    public abstract class EntityFactoryBase<TEntity> : IEntityFactory<TEntity>
        where TEntity : class, IEntity<TEntity>
    {
        /// <summary>
        ///     Набор проверок для создания и восстановления объекта.
        /// </summary>
        protected IEnumerable<ISpecification<TEntity>> Specifications { private get; set; } =
            new List<ISpecification<TEntity>>();

        /// <summary>
        ///     Создание нового объекта.
        /// </summary>
        /// <param name="entityToCreate">Строитель нового объекта.</param>
        /// <returns>Созданный объект.</returns>
        /// <remarks>
        ///     По факту создание сущности отличается от восстановления только генераций  уникальных
        ///     идентификаторов.
        /// </remarks>
        public TEntity Create(IEntityBuilder<TEntity> entityToCreate)
        {
            entityToCreate.Identifier = Identifier<TEntity>.Create();

            return Recovery(entityToCreate);
        }

        /// <summary>
        ///     Восстановление уже созданного объекта.
        /// </summary>
        /// <param name="entityToRecovery">Строитель восстанавливаемого объекта.</param>
        /// <returns>Восстановленный объект.</returns>
        public TEntity Recovery(IEntityBuilder<TEntity> entityToRecovery)
        {
            var entity = AllocateEntity(entityToRecovery);
            SetSpecifications(entity);

            foreach(var specification in Specifications)
                specification.Satisfies(entity);

            return entity;
        }

        /// <summary>
        ///     Создание объекта и размещение его в памяти.
        /// </summary>
        /// <param name="entityBuilder">Строитель для объекта.</param>
        /// <returns>Ссылка на созданный в куче объект.</returns>
        protected abstract TEntity AllocateEntity(IEntityBuilder<TEntity> entityBuilder);

        /// <summary>
        ///     Фиксация набора спецификаций.
        /// </summary>
        /// <param name="entity">Сущность к которой будут применяться спецификации.</param>
        protected abstract void SetSpecifications(TEntity entity);
    }
}
