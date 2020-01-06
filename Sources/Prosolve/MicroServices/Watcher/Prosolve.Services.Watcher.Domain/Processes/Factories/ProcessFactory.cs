using System;
using System.Collections.ObjectModel;

using Prosolve.Services.Watcher.Domain.Processes.Specifications;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Domain.Factories;

namespace Prosolve.Services.Watcher.Domain.Processes.Factories
{
    /// <summary>
    ///     Фабрика для объекта <see cref="IProcessAggregate" />.
    /// </summary>
    public sealed class ProcessFactory : EntityFactoryBase<IProcessAggregate>
    {
        /// <summary>
        ///     Фиксация набора спецификаций.
        /// </summary>
        /// <param name="processAggregate">Сущность к которой будут применяться спецификации.</param>
        protected override void SetSpecifications(IProcessAggregate processAggregate)
        {
            var specifications = new Collection<ISpecification<IProcessAggregate>>
            {
                new ProcessNameLengthSpecification(),
                new ProcessPublicIdSpecification(processAggregate.Id.Public)
            };
            Specifications = specifications;
        }

        /// <summary>
        ///     Создание объекта и размещение его в памяти.
        /// </summary>
        /// <param name="entityBuilder">Строитель для объекта <see cref="Entity{TEntity}" />.</param>
        /// <returns>Ссылка на созданный в куче объект.</returns>
        protected override IProcessAggregate AllocateEntity(
            IEntityBuilder<IProcessAggregate> entityBuilder)
        {
            if (entityBuilder is IProcessBuilder processBuilder)
                return new ProcessAggregate(processBuilder);

            throw new NotImplementedException();
        }
    }
}
