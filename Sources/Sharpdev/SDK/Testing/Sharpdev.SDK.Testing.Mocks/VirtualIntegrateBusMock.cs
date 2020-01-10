using Sharpdev.SDK.Infrastructure.Integrations;

namespace Sharpdev.SDK.Testing.Mocks
{
    /// <summary>
    ///     Фальшивка для интеграционной шины. Данные будем хранить в памяти.
    /// </summary>
    public class VirtualIntegrateBusMock : TestObjectGeneratorBase<IIntegrateBus>
    {
        /// <summary>
        ///     Фальшивая шина данных для обмена сообщений.
        /// </summary>
        private readonly IIntegrateBus _integrateBus = new IntegrateBusMock();

        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="stubNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected override IIntegrateBus AllocateStub(int stubNumber)
        {
            return _integrateBus;
        }
    }
}
