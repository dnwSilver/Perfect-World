using System;

using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.MicroService.Identity.Entities.Users
{
    internal class UserEntityFactory : IEntityFactory<IUser>
    {
        /// <summary>
        ///     Создание нового объекта.
        /// </summary>
        /// <returns>Созданный объект.</returns>
        public Result<IUser> Create(IEntityBuilder<IUser> entityToCreate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Восстановление уже созданного объекта.
        /// </summary>
        /// <param name="entityToRecovery">Строитель восстанавливаемого объекта.</param>
        /// <returns>Восстановленный объект.</returns>
        public Result<IUser> Recovery(IEntityBuilder<IUser> entityToRecovery)
        {
            throw new NotImplementedException();
        }
    }
}
