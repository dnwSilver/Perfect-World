using System;

using Moq;

using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;

namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Строитель для объекта <see cref="IConfirmed{TConfirmedObject}" />.
    /// </summary>
    public sealed class EmailAddressStub : TestStubBase<IConfirmed<EmailAddress>>
    {
        /// <summary>
        ///     Заглушка для адреса электронной почты.
        /// </summary>
        private readonly Mock<IConfirmed<EmailAddress>> _emailAddressMock =
            new Mock<IConfirmed<EmailAddress>>();

        /// <summary>
        ///     Заполнение адреса электронной почты.
        /// </summary>
        /// <param name="emailAddress">Адрес электронной почты <see cref="EmailAddress" />.</param>
        /// <returns>Строитель для объекта <see cref="IConfirmed{TConfirmedObject}" />.</returns>
        public EmailAddressStub(EmailAddress emailAddress)
        {
            this._emailAddressMock.Setup(x => x.Value).Returns(emailAddress);
            this._emailAddressMock.Setup(x => x.IsConfirmed).Returns(false);
        }

        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="stubNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected override IConfirmed<EmailAddress> AllocateStub(int stubNumber)
        {
            return this._emailAddressMock.Object;
        }

        /// <summary>
        ///     Заполнение признака подтверждения адреса электронной почты.
        /// </summary>
        /// <param name="confirmedDate">Дата подтверждения электронной почты.</param>
        /// <returns>Строитель для объекта <see cref="IConfirmed{TConfirmedObject}" />.</returns>
        public EmailAddressStub Confirmed(DateTime confirmedDate)
        {
            this._emailAddressMock.Setup(x => x.ConfirmedDate).Returns(confirmedDate);
            this._emailAddressMock.Setup(x => x.IsConfirmed).Returns(true);

            return this;
        }
    }
}
