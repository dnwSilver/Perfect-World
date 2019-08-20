using System;

using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.Services.Identification.Entities.Users
{
    internal class UserFactory : IEntityFactory<IUserEntity>
    {
        /// <summary>
        ///     Создание нового объекта.
        /// </summary>
        /// <returns>Созданный объект.</returns>
        public Result<IUserEntity> Create(IEntityBuilder<IUserEntity> entityToCreate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Восстановление уже созданного объекта.
        /// </summary>
        /// <param name="entityToRecovery">Строитель восстанавливаемого объекта.</param>
        /// <returns>Восстановленный объект.</returns>
        public Result<IUserEntity> Recovery(IEntityBuilder<IUserEntity> entityToRecovery)
        {
            throw new NotImplementedException();
        }
    }
}
