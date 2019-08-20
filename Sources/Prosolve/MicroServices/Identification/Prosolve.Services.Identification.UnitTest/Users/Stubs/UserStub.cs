using System;

using Prosolve.Services.Identification.Entities.Users;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Testing;
using Sharpdev.SDK.Types.EmailAddresses;

namespace Prosolve.Services.Identity.UnitTest.Users.Stubs
{
    /// <summary>
    ///     Заглушка для идентификатора <see cref="IUser" />.
    /// </summary>
    public class UserStub : TestStubBase<IUser>
    {
        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="stubNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected override IUser AllocateStub(int stubNumber)
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
