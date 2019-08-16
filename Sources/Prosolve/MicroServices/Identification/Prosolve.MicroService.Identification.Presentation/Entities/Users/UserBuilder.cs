using System;

using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;

namespace Prosolve.MicroService.Identity.Entities.Users
{
    public class UserBuilder : EntityBuilderBase<IUser>, IUserBuilder
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
      
    }
}
