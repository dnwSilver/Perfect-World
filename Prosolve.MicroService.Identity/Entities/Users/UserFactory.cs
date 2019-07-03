using System;

using Sharpdev.SDK.Layers.Domain.Factories;

namespace Prosolve.MicroService.Identity.Entities.Users
{
    internal class UserFactory : IFactory<IUser>
    {
        /// <summary>
        ///     Создание нового объекта.
        /// </summary>
        /// <param name="IUser">Строитель нового объекта.</param>
        /// <returns>Созданный объект.</returns>
        public IUser Create(IEntityBuilder<IUser> objectToCreate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Восстановление уже созданного объекта.
        /// </summary>
        /// <param name="objectToRecovery">Строитель восстанавливаемого объекта.</param>
        /// <returns>Восстановленный объект.</returns>
        public IUser Recovery(IEntityBuilder<IUser> objectToRecovery)
        {
            throw new NotImplementedException();
        }
    }
}
