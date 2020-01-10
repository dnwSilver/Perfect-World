using Moq;

using Sharpdev.SDK.Types.FullNames;

namespace Sharpdev.SDK.Testing.Mocks
{
    /// <summary>
    /// Генератор имён.
    /// </summary>
    public class FullNameMockGenerator: TestObjectGeneratorBase<FullName>
    {
        /// <summary>
        ///     Имитация номера телефона.
        /// </summary>
        private readonly Mock<FullName> _fullName = new Mock<FullName>();

        /// <summary>
        /// Генерация имени.
        /// </summary>
        /// <param name="stubNumber">Номер генерируемого имени.</param>
        /// <returns>Новое имя.</returns>
        protected override FullName AllocateStub(int stubNumber)
        {
            var firstName = $"Имя{stubNumber}";
            var surname = $"Фамилия{stubNumber}";
            var patronymic = $"Отчество{stubNumber}";
            _fullName.Setup(x => x.FirstName).Returns(firstName);
            _fullName.Setup(x => x.Surname).Returns(surname);
            _fullName.Setup(x => x.Patronymic).Returns(patronymic);
            _fullName.Setup(x => x.GetFullName).Returns($"{surname}{firstName}{patronymic}");
            return _fullName.Object;
        }
    }
}
