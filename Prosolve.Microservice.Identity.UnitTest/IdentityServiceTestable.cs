using System.Collections.Generic;

using Moq;

using Sharpdev.SDK.Layers.Application;

namespace Prosolve.MicroService.Identity.UnitTest
{
    public class IdentityServiceTestable : IIdentityService
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;

        /// <summary>
        ///     Текущий статус объекта.
        /// </summary>
        /// <returns>Статус объекта.</returns>
        public ServiceStatus Status { get; private set; } = ServiceStatus.Up;

        /// <summary>
        ///     Смена статуса.
        /// </summary>
        /// <param name="newState">Новый статус.</param>
        public void ChangeStatus(ServiceStatus newState)
        {
            Status = newState;
        }

        /// <summary>
        ///     Поиск пользователей в информационной системе.
        /// </summary>
        /// <param name="userSearchParameters">Набор параметров для поиска.</param>
        /// <returns>Список пользователям по заданным параметрам.</returns>
        public IReadOnlyCollection<IUser> FindUserAsync(IUserSearchParameters userSearchParameters)
        {
            IReadOnlyCollection<IUser> users = _userRepositoryMock.Object.ReadAsync(userSearchParameters).Result;

            return users;
        }
    }
}
