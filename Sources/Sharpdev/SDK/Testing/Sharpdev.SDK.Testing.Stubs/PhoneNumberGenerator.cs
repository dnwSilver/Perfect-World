using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.PhoneNumbers;

namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Генератор для идентификатора <see cref="IConfirmed{PhoneNumber}" />.
    /// </summary>
    public class PhoneNumberGenerator : TestObjectGeneratorBase<IConfirmed<PhoneNumber>>
    {
        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="stubNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected override IConfirmed<PhoneNumber> AllocateStub(int stubNumber)
        {
            return new ConfirmedBase<PhoneNumber>($"+7{stubNumber:D10}");
        }
    }
}
