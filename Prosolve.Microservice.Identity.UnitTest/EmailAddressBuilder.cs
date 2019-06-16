using System;
using Sharpdev.SDK.Layers.Kernel;
using Sharpdev.SDK.Testing;
using Sharpdev.SDK.Types.EmailAddresses;

namespace Prosolve.MicroService.Identity.UnitTest
{
    /// <summary>
    ///     Строитель для объекта <see cref="IConfirmed{TConfirmedObject}" />.
    /// </summary>
    public class EmailAddressBuilder : ITestBuilder<IConfirmed<EmailAddress>>
    {
        /// <summary>
        ///     Адрес электронной почты.
        /// </summary>
        private IConfirmed<EmailAddress> _emailAddress;

        /// <summary>
        ///     Построение объекта <see cref="IConfirmed{EmailAddress}" />.
        /// </summary>
        /// <returns>Экземпляр объекта <see cref="IConfirmed{EmailAddress}" />.</returns>
        public IConfirmed<EmailAddress> Please()
        {
            return _emailAddress;
        }

        public EmailAddressBuilder ConfirmedAt(DateTime utcNow)
        {
            return this;
        }
    }
}
