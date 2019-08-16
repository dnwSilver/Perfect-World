using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;

namespace Prosolve.MicroService.Identity.Entities.Users
{
    /// <summary>
    ///     Строитель для объекта <see cref="IUser" />.
    /// </summary>
    public interface IUserBuilder : IEntityBuilder<IUser>
    {
        /// <summary>
        ///     Установка адрес электронной почты указанный для получения обратной связи.
        /// </summary>
        /// <param name="contactEmailAddress">Адрес электронной для связи с клиентом.</param>
        /// <returns>Строитель с предыдущими параметрами.</returns>
        IUserBuilder SetContactEmailAddress(IConfirmed<EmailAddress> contactEmailAddress);

        /// <summary>
        ///     Установка фамилии имени и отчества пользователя.
        /// </summary>
        /// <param name="fullName">Фамилия имя и отчество пользователя.</param>
        /// <returns>Строитель с предыдущими параметрами.</returns>
        IUserBuilder SetFullName(FullName fullName);
    }
}
