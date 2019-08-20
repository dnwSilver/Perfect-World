using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Infrastructure.Statuses;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;

namespace Prosolve.Services.Identification.Entities.Users
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
