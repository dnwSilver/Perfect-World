using System;

using Moq;

using Sharpdev.SDK.Layers.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;

namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Строитель для объекта <see cref="IConfirmed{TConfirmedObject}" />.
    /// </summary>
    public class EmailAddressStub : ITestStub<IConfirmed<EmailAddress>>
    {
        /// <summary>
        ///     Адрес электронной почты.
        /// </summary>
        private readonly Mock<IConfirmed<EmailAddress>> _emailAddress = new Mock<IConfirmed<EmailAddress>>();

        public EmailAddressStub(string emailAddress)
        {
            _emailAddress.Setup(x => x.Value).Returns(emailAddress);
        }

        /// <summary>
        ///     Построение объекта <see cref="IConfirmed{EmailAddress}" />.
        /// </summary>
        /// <returns>Экземпляр объекта <see cref="IConfirmed{EmailAddress}" />.</returns>
        public IConfirmed<EmailAddress> Please()
        {
            return _emailAddress.Object;
        }

        public EmailAddressStub Confirmed(DateTime confirmedDate)
        {
            _emailAddress.Setup(x => x.ConfirmedDate).Returns(confirmedDate);
            _emailAddress.Setup(x => x.IsConfirmed).Returns(true);

            return this;
        }
    }
}
