using System.Collections;
using System.Collections.Generic;

using Prosolve.MicroService.Identity.Entities.Users;

using Sharpdev.SDK.Layers.Application;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.MicroService.Identity
{
    /// <summary>
    ///     Сервис по управлению пользователями предоставляемый для бизнеса.
    /// </summary>
    public interface IIdentityService : IService
    {
        /// <summary>
        ///     Поиск пользователей в информационной системе.
        /// </summary>
        /// <param name="userSearchParameters">Набор параметров для поиска.</param>
        /// <returns>Список пользователям по заданным параметрам.</returns>
        Result<IEnumerable<IUser>> FindUser(IUserSearchParameters userSearchParameters);

        /// <summary>
        ///     Создание пользователей в информационной системе.
        /// </summary>
        /// <param name="newUsers">Список новых пользователей.</param>
        /// <returns>Информация по процессу создания пользователей.</returns>
        Result CreateUser(IEnumerable<IUser> newUsers);
    }
}
