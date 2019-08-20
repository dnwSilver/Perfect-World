using System;

using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;

namespace Prosolve.Services.Identification.Entities.Users
{
    public class UserBuilder : EntityBuilderBase<IUserEntity>, IUserBuilder
    {
        /// <summary>
        ///     Установка адрес электронной почты указанный для получения обратной связи.
        /// </summary>
        /// <returns>Адрес электронной для связи с клиентом.</returns>
        public IConfirmed<EmailAddress> ContactEmailAddress { get; set; }
        
        /// <summary>
        ///     Установка номера телефона указанного для получения обратной связи.
        /// </summary>
        /// <returns>Номер телефона для связи с клиентом.</returns>
        public IConfirmed<EmailAddress> ContactPhoneNumber { get; set; }

        /// <summary>
        ///     Установка фамилии имени и отчества пользователя.
        /// </summary>
        /// <returns>Фамилия имя и отчество пользователя.</returns>
        public FullName FullName { get; set; }
    }
}
