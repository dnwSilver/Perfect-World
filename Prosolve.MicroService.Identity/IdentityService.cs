using System;
using System.Collections.Generic;
using System.Linq;

using Sharpdev.SDK.Layers.Application;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.MicroService.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRepository _userRepository;

        public IdentityService(IUserRepository userRepository)
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
        public Result CreateUser(IReadOnlyCollection<IUser> newUsers)
        {
            if (newUsers.Any(x => !x.Id.IsTransient()))
                return Result.Fail(TextResultError.Create("Хотя бы один из пользователей уже создан."));

            var createResult = _userRepository.Create(newUsers);

            return createResult;
        }

        /// <summary>
        ///     Поиск пользователей в информационной системе.
        /// </summary>
        /// <param name="userSearchParameters">Набор параметров для поиска.</param>
        /// <returns>Список пользователям по заданным параметрам.</returns>
        public Result<IReadOnlyCollection<IUser>> FindUserAsync(IUserSearchParameters userSearchParameters)
        {
            return _userRepository.Read(userSearchParameters);
        }
    }
}
