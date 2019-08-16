using System.Security.Claims;

using Prosolve.MicroService.Identity.Entities.Users;

using Sharpdev.SDK.Infrastructure.Integrations;
using Sharpdev.SDK.Infrastructure.Repositories;
using Sharpdev.SDK.Presentation;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.MicroService.Identity
{
    /// <summary>
    ///     Сервис по управлению пользователями предоставляемый для бизнеса.
    /// </summary>
    public partial class IdentityService
    {
        /// <summary>
        ///     Шина для миграции данных.
        /// </summary>
        private readonly IIntegrateBus _integrateBus;

        /// <summary>
        ///     Репозиторий для работы с пользователями.
        /// </summary>
        private readonly IEntityRepository<IUser> _userEntityRepository;

        /// <summary>
        ///     Создание объекта <see cref="IdentityService" />.
        /// </summary>
        /// <param name="userEntityRepository">Репозиторий для работы с пользователями.</param>
        /// <param name="integrateBus">Интеграционная шина.</param>
        public IdentityService(IEntityRepository<IUser> userEntityRepository,
                               IIntegrateBus integrateBus)
        {
            this._userEntityRepository = userEntityRepository;
            _integrateBus = integrateBus;
        }

        /// <summary>
        ///     Текущий статус объекта.
        /// </summary>
        /// <returns>Статус объекта.</returns>
        public ServiceStatus Status { get; private set; }

        /// <summary>
        ///     Смена статуса.
        /// </summary>
        /// <param name="newStatus">Новый статус.</param>
        public void ChangeStatus(ServiceStatus newStatus)
        {
            Status = newStatus;
        }

        /// <summary>
        ///     Авторизация пользователя.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>
        ///     Коллекция объектов <see cref="Claim" />, описывающих утверждения для пользователя.
        /// </returns>
        public Result<ClaimsIdentity> Authorize(string login, string password)
        {
            var claims = new []
                         {
                             new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                             new Claim(ClaimsIdentity.DefaultRoleClaimType, "Member")
                         };
            var claimsIdentity = new ClaimsIdentity(claims,
                                                    "Token",
                                                    ClaimsIdentity.DefaultNameClaimType,
                                                    ClaimsIdentity.DefaultRoleClaimType);

            //_logger.LogInformation($"Авторизация пользователя {login}");

            return Result.Ok(claimsIdentity);
        }
    }
}
