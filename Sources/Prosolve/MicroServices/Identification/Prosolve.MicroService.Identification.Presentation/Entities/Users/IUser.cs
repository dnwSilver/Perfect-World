using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Layers.Infrastructure.Statuses;
using Sharpdev.SDK.Layers.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;

namespace Prosolve.MicroService.Identity.Entities.Users
{
    /// <summary>
    ///     Пользователь информационной системы.
    /// </summary>
    public interface IUser : IEntity<IUser>, IHasStatus<UserStatus>
    {
        /// <summary>
        ///     Адрес электронной почты указанный для получения обратной связи.
        /// </summary>
        IConfirmed<EmailAddress> ContactEmail { get; }

        /// <summary>
        ///     Фио пользователя.
        /// </summary>
        FullName FullName { get; }
    }
}
