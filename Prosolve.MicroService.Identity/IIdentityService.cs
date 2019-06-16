using System.Collections.Generic;

using Sharpdev.SDK.Layers.Application;

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
        IReadOnlyCollection<IUser> FindUserAsync(IUserSearchParameters userSearchParameters);
    }
}
