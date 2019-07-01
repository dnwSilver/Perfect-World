using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Prosolve.MicroService.Identity.Entities.Users;

using Sharpdev.SDK.Layers.Application;
using Sharpdev.SDK.Layers.Infrastructure.Repositories;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.MicroService.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IRepository<IUser> _userRepository;

        public IdentityService(IRepository<IUser> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        ///     Текущий статус объекта.
        /// </summary>
        /// <returns>Статус объекта.</returns>
        public ServiceStatus Status { get; }

        /// <summary>
        ///     Смена статуса.
        /// </summary>
        /// <param name="newState">Новый статус.</param>
        public void ChangeStatus(ServiceStatus newState)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Создание пользователей в информационной системе.
        /// </summary>
        /// <param name="newUsers">Список новых пользователей.</param>
        /// <returns>Информация по процессу создания пользователей.</returns>
        public Result CreateUser(IEnumerable<IUser> newUsers)
        {
            var createResult = _userRepository.Create(newUsers);
            return createResult;
        }

        /// <summary>
        ///     Поиск пользователей в информационной системе.
        /// </summary>
        /// <param name="userSearchParameters">Набор параметров для поиска.</param>
        /// <returns>Список пользователям по заданным параметрам.</returns>
        public Result<IEnumerable<IUser>> FindUser(IUserSearchParameters userSearchParameters)
        {
            return _userRepository.Read(userSearchParameters);
        }
    }
}
