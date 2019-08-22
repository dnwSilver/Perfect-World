using System;
using System.Collections.ObjectModel;

using Prosolve.Services.Watcher.Domain.Processes.Specifications;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Domain.Factories;

namespace Prosolve.Services.Watcher.Domain.Processes.Factories
{
    /// <summary>
    ///     Фабрика для объекта <see cref="IProcessEntity" />.
    /// </summary>
    public sealed class ProcessFactory : EntityFactoryBase<IProcessEntity>
    {
        /// <summary>
        ///     Фиксация набора спецификаций.
        /// </summary>
        /// <param name="processEntity">Сущность к которой будут применяться спецификации.</param>
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
            if (entityBuilder is IProcessBuilder processBuilder)
                return new ProcessEntity(processBuilder);

            throw new NotImplementedException();
        }
    }
}
