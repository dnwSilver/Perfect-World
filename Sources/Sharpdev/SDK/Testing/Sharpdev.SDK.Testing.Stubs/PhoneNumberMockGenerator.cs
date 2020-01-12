using Moq;

using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.PhoneNumbers;

namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Генератор для идентификатора <see cref="IConfirmed{PhoneNumber}" />.
    /// </summary>
    public sealed class PhoneNumberMockGenerator : TestObjectGeneratorBase<IConfirmed<PhoneNumber>>
    {
        /// <summary>
        ///     Заглушка для номера телефона.
        /// </summary>
        private readonly Mock<IConfirmed<PhoneNumber>> _phoneNumberMock = new Mock<IConfirmed<PhoneNumber>>();

        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="testObjectNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected override IConfirmed<PhoneNumber> Allocate(int testObjectNumber)
        {
            _phoneNumberMock.Setup(x => x.Value).Returns($"+7{testObjectNumber:D10}");
            _phoneNumberMock.Setup(x => x.IsConfirmed).Returns(false);
            
            return _phoneNumberMock.Object;
        }
    }
}
