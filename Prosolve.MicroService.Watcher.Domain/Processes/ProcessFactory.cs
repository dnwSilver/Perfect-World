using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Prosolve.MicroService.Watcher.Domain.Processes.Specifications;

using Sharpdev.SDK.Layers.Domain;
using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Layers.Domain.Factories;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.MicroService.Watcher.Domain.Processes
{
    /// <summary>
    ///     Фабрика для объекта <see cref="IProcessEntity" />.
    /// </summary>
    public sealed class ProcessFactory : BaseFactory<IProcessEntity>
    {
        protected override void SetSpecifications(IProcessEntity processEntity)
        {
            var specifications = new Collection<ISpecification<IProcessEntity>>
            {
                new ProcessNameLengthSpecification(),
                new ProcessPublicIdSpecification(processEntity.Id.Public)
            };
            this.Specifications = specifications;
        }

        /// <summary>
        ///     Создание объекта и размещение его в памяти.
        /// </summary>
        /// <param name="entityBuilder">Строитель для объекта <see cref="Entity{TEntity}" />.</param>
        /// <returns>Ссылка на созданный в куче объект.</returns>
        protected override IProcessEntity AllocateEntity(
            IEntityBuilder<IProcessEntity> entityBuilder)
        {
            return new ProcessEntity(entityBuilder as IProcessBuilder);
        }
    }

    /// <summary>
    ///     Базовый класс для фабрики объектов.
    /// </summary>
    /// <typeparam name="TEntity">Тип объекта, который будем собирать.</typeparam>
    public abstract class BaseFactory<TEntity> : IFactory<TEntity>
        where TEntity : IEntity<TEntity>
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
        public Result<TEntity> Create(IEntityBuilder<TEntity> entityToCreate)
        {
            var processIdentifier = new Identifier<TEntity>(Identifier<TEntity>.Undefined,
                                                            Guid.NewGuid(),
                                                            entityToCreate.Identifier.Externals);
            entityToCreate.Identifier = processIdentifier;

            var entity = this.AllocateEntity(entityToCreate);

            foreach(var specification in this.Specifications)
                specification.IsSatisfiedBy(entity);

            return Result.Ok(entity);
        }

        /// <summary>
        ///     Восстановление уже созданного объекта.
        /// </summary>
        /// <param name="entityToRecovery">Строитель восстанавливаемого объекта.</param>
        /// <returns>Восстановленный объект.</returns>
        public Result<TEntity> Recovery(IEntityBuilder<TEntity> entityToRecovery)
        {
            var entity = this.AllocateEntity(entityToRecovery);
            this.SetSpecifications(entity);
            foreach(var specification in this.Specifications)
                specification.IsSatisfiedBy(entity);

            return Result.Ok(entity);
        }

        /// <summary>
        ///     Создание объекта и размещение его в памяти.
        /// </summary>
        /// <param name="entityBuilder">Строитель для объекта.</param>
        /// <returns>Ссылка на созданный в куче объект.</returns>
        protected abstract TEntity AllocateEntity(IEntityBuilder<TEntity> entityBuilder);

        protected abstract void SetSpecifications(TEntity entity);
    }
}
