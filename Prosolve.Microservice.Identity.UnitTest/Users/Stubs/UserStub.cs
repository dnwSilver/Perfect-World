using System;

using Prosolve.MicroService.Identity.Entities.Users;

using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Layers.Kernel;
using Sharpdev.SDK.Testing.Stubs;
using Sharpdev.SDK.Types.EmailAddresses;

namespace Prosolve.MicroService.Identity.UnitTest.Users.Stubs
{
    /// <summary>
    ///     Заглушка для идентификатора <see cref="IUser" />.
    /// </summary>
    public class UserStub : ITestStub<IUser>
    {
        /// <summary>
        ///     Построение объекта <see cref="IUser" />.
        /// </summary>
        /// <returns>Экземпляр объекта <see cref="IUser" /></returns>
        public IUser Please()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Заполнение идентификатора пользователя.
        /// </summary>
        /// <param name="userIdentifier">Идентификатор пользователя.</param>
        /// <returns>Строитель для заглушки объекта <see cref="IUser" />.</returns>
        public UserStub With(IIdentifier<IUser> userIdentifier)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Заполнение контактного адреса электронной почты.
        /// </summary>
        /// <param name="contactEmail">Электронный адрес для контакта.</param>
        /// <returns>Строитель для заглушки объекта <see cref="IUser" />.</returns>
        public UserStub With(IConfirmed<EmailAddress> contactEmail)
        {
            throw new NotImplementedException();
        }
    }
}
