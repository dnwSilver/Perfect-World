using System;

using Moq;

using Sharpdev.SDK.Layers.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;

namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Строитель для объекта <see cref="IConfirmed{TConfirmedObject}" />.
    /// </summary>
    public sealed class EmailAddressStub : ITestStub<IConfirmed<EmailAddress>>
    {
        /// <summary>
        ///     Заглушка для адреса электронной почты.
        /// </summary>
        private readonly Mock<IConfirmed<EmailAddress>> _emailAddressMock = new Mock<IConfirmed<EmailAddress>>();

        /// <summary>
        ///     Заполнение адреса электронной почты.
        /// </summary>
        /// <param name="emailAddress">Адрес электронной почты <see cref="EmailAddress"/>.</param>
        /// <returns>Строитель для объекта <see cref="IConfirmed{TConfirmedObject}" />.</returns>
        public EmailAddressStub(EmailAddress emailAddress)
        {
            _emailAddressMock.Setup(x => x.Value).Returns(emailAddress);
        }

        /// <summary>
        ///     Построение заглушки для объекта <see cref="IConfirmed{TConfirmedObject}" />.
        /// </summary>
        /// <returns>Заглушка для объекта <see cref="IConfirmed{TConfirmedObject}" />.</returns>
        public IConfirmed<EmailAddress> Please()
        {
            return _emailAddressMock.Object;
        }

        /// <summary>
        ///     Заполнение признака подтверждения адреса электронной почты.
        /// </summary>
        /// <param name="confirmedDate">Дата подтверждения электронной почты.</param>
        /// <returns>Строитель для объекта <see cref="IConfirmed{TConfirmedObject}" />.</returns>
        public EmailAddressStub Confirmed(DateTime confirmedDate)
        {
            _emailAddressMock.Setup(x => x.ConfirmedDate).Returns(confirmedDate);
            _emailAddressMock.Setup(x => x.IsConfirmed).Returns(true);
            return this;
        }
    }
}
