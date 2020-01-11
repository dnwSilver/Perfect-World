using System;

using Prosolve.Services.Identification.Users;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Testing;
using Sharpdev.SDK.Types.EmailAddresses;

namespace Prosolve.Services.Identity.UnitTest.Users.ObjectGenerators
{
    /// <summary>
    ///     Заглушка для идентификатора <see cref="IUserAggregate" />.
    /// </summary>
    public class UserObjectGenerator : TestObjectGeneratorBase<IUserAggregate>
    {
        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="testObjectNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected override IUserAggregate Allocate(int testObjectNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Заполнение идентификатора пользователя.
        /// </summary>
        /// <param name="userIdentifier">Идентификатор пользователя.</param>
        /// <returns>Строитель для заглушки объекта <see cref="IUserAggregate" />.</returns>
        public UserObjectGenerator With(IIdentifier<IUserAggregate> userIdentifier)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Заполнение контактного адреса электронной почты.
        /// </summary>
        /// <param name="contactEmail">Электронный адрес для контакта.</param>
        /// <returns>Строитель для заглушки объекта <see cref="IUserAggregate" />.</returns>
        public UserObjectGenerator With(IConfirmed<EmailAddress> contactEmail)
        {
            throw new NotImplementedException();
        }
    }
}
