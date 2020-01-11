using Moq;

namespace Sharpdev.SDK.Testing.Mocks
{
    /// <summary>
    ///     Генератор Mock объектов.
    /// </summary>
    /// <typeparam name="TMockObject">Тип объект на который делаем пародию.</typeparam>
    /// <remarks>
    ///     Mock-объект (от англ. mock object, буквально: «объект-пародия», «объект-имитация», а также «подставка»).
    ///     В объектно-ориентированном программировании — тип объектов, реализующих заданные аспекты моделируемого
    ///     программного окружения.
    /// </remarks>
    public abstract class MockGeneratorBase<TMockObject> : TestObjectGeneratorBase<TMockObject>
            where TMockObject: class
    {
        /// <summary>
        /// Генератор mock-объекта.
        /// </summary>
        protected readonly Mock<TMockObject> _mockObject = new Mock<TMockObject>();

        /// <summary>
        /// Метод задающий поведения mock-объекта.
        /// </summary>
        /// <param name="mockNumber">Порядковый номер создаваемого объекта.</param>
        protected abstract void SetupBehavior(int mockNumber);

        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="testObjectNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected override TMockObject Allocate(int testObjectNumber)
        {
            SetupBehavior(testObjectNumber);
            return _mockObject.Object;
        }
    }
}
