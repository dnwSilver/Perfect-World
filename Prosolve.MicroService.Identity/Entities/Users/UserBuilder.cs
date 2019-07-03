using System;

using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Layers.Domain.Factories;
using Sharpdev.SDK.Layers.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;

namespace Prosolve.MicroService.Identity.Entities.Users
{
    public class UserBuilder : EntityBuilder<IUser>, IUserBuilder
    {
        /// <summary>
        ///     Установка адрес электронной почты указанный для получения обратной связи.
        /// </summary>
        /// <param name="contactEmailAddress">Адрес электронной для связи с клиентом.</param>
        /// <returns>Строитель с предыдущими параметрами.</returns>
        public IUserBuilder SetContactEmailAddress(IConfirmed<EmailAddress> contactEmailAddress)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Установка фамилии имени и отчества пользователя.
        /// </summary>
        /// <param name="fullName">Фамилия имя и отчество пользователя.</param>
        /// <returns>Строитель с предыдущими параметрами.</returns>
        public IUserBuilder SetFullName(FullName fullName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Фиксация версии объекта <see cref="IUser" />.
        /// </summary>
        /// <param name="entityVersion">Версия объекта.</param>
        /// <returns>Строитель для объекта <see cref="IUser" />.</returns>
        public new IUserBuilder SetVersion(int entityVersion)
        {
            return base.SetVersion(entityVersion) as IUserBuilder;
        }

        /// <summary>
        ///     Фиксация значения идентификатора объекта <see cref="IUser" />.
        /// </summary>
        /// <param name="userIdentifier">Значение идентификатора.</param>
        /// <returns>Строитель для объекта <see cref="IUser" />.</returns>
        public new IUserBuilder SetIdentifier(IIdentifier<IUser> userIdentifier)
        {
            return base.SetIdentifier(userIdentifier) as IUserBuilder;
        }
    }
}
