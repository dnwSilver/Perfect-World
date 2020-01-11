using Moq;

using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;

namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Строитель для объекта <see cref="IConfirmed{TConfirmedObject}" />.
    /// </summary>
    public sealed class EmailAddressGenerator : TestObjectGeneratorBase<IConfirmed<EmailAddress>>
    {
        /// <summary>
        ///     Заглушка для адреса электронной почты.
        /// </summary>
        private readonly Mock<IConfirmed<EmailAddress>> _emailAddressMock = new Mock<IConfirmed<EmailAddress>>();

        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="testObjectNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected override IConfirmed<EmailAddress> Allocate(int testObjectNumber)
        {
            _emailAddressMock.Setup(x => x.Value).Returns($"user{testObjectNumber}@email.com");
            _emailAddressMock.Setup(x => x.IsConfirmed).Returns(false);

            return _emailAddressMock.Object;
        }
    }
}
