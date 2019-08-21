using System.Collections.ObjectModel;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Domain.Factories;

namespace Prosolve.Services.Identification.Entities.Users
{
    internal class UserFactory : EntityFactoryBase<IUserEntity>
    {
        /// <summary>
        ///     Фиксация набора спецификаций.
        /// </summary>
        /// <param name="processEntity">Сущность к которой будут применяться спецификации.</param>
        protected override void SetSpecifications(IUserEntity processEntity)
        {
            var specifications = new Collection<ISpecification<IUserEntity>>();
            this.Specifications = specifications;
        }

        /// <summary>
        ///     Создание объекта и размещение его в памяти.
        /// </summary>
        /// <param name="entityBuilder">Строитель для объекта <see cref="Entity{TEntity}" />.</param>
        /// <returns>Ссылка на созданный в куче объект.</returns>
        protected override IUserEntity AllocateEntity(
            IEntityBuilder<IUserEntity> entityBuilder)
        {
            return new UserEntity(entityBuilder as IUserBuilder);
        }
    }
}
