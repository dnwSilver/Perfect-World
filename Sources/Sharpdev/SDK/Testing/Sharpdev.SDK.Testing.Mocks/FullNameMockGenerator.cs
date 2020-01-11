using Sharpdev.SDK.Types.FullNames;

namespace Sharpdev.SDK.Testing.Mocks
{
    /// <summary>
    /// Генератор имён.
    /// </summary>
    public sealed class FullNameMockGenerator: MockGeneratorBase<IFullName>
    {
        /// <summary>
        /// Генерация имени.
        /// </summary>
        /// <param name="mockNumber">Номер генерируемого имени.</param>
        /// <returns>Новое имя.</returns>
        protected override void SetupBehavior(int mockNumber)
        {
            _mockObject.Setup(x => x.FirstName).Returns($"Имя{mockNumber}");
            _mockObject.Setup(x => x.Surname).Returns($"Фамилия{mockNumber}");
            _mockObject.Setup(x => x.Patronymic).Returns($"Отчество{mockNumber}");
        }
    }
}
