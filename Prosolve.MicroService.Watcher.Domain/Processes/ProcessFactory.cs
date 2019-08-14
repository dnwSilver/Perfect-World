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
    public sealed class Process : EntityFactoryBase<IProcessEntity>
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

    
}
