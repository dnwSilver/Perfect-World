using System.Security.Claims;

using Prosolve.Services.Identification.Entities.Users;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Presentation;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.Services.Identification
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
        Result<IUser[]> FindUser(ISpecification<IUser> userSearchParameters);

        /// <summary>
        ///     Создание пользователей в информационной системе.
        /// </summary>
        /// <param name="newUsers">Список новых пользователей.</param>
        /// <returns>Информация по процессу создания пользователей.</returns>
        Result CreateUsers(IUserBuilder[] newUsers);

        /// <summary>
        ///     Авторизация пользователя.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>
        ///     Коллекция объектов <see cref="Claim" />, описывающих утверждения для пользователя.
        /// </returns>
        Result<ClaimsIdentity> Authorize(string login, string password);
    }
}
