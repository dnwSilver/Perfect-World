using System;
using System.Collections.ObjectModel;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Domain.Specifications;

namespace Prosolve.Services.Identification.Users.Factories
{
    internal sealed class UserFactory : EntityFactoryBase<IUserAggregate>
    {
        /// <summary>
        ///     Фиксация набора спецификаций.
        /// </summary>
        /// <param name="processEntity">Сущность к которой будут применяться спецификации.</param>
        protected override void SetSpecifications(IUserAggregate processEntity)
        {
            var specifications = new Collection<ISpecification<IUserAggregate>>();
            Specifications = specifications;
        }

        /// <summary>
        ///     Создание объекта и размещение его в памяти.
        /// </summary>
        /// <param name="entityBuilder">Строитель для объекта <see cref="Entity{TEntity}" />.</param>
        /// <returns>Ссылка на созданный в куче объект.</returns>
        protected override IUserAggregate AllocateEntity(IEntityBuilder<IUserAggregate> entityBuilder)
        {
            if (entityBuilder is IUserBuilder userBuilder)
                return new UserAggregate(userBuilder);

            throw new Exception();
        }
    }
}
