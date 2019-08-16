using Sharpdev.SDK.Layers.Infrastructure.Integrations;
using Sharpdev.SDK.Testing.Stubs;

namespace Sharpdev.SDK.Testing.Mocks
{
    /// <summary>
    ///     Фальшивка для интеграционной шины. Данные будем хранить в памяти.
    /// </summary>
    public class VirtualIntegrateBusMock : ITestStub<IIntegrateBus>
    {
        /// <summary>
        ///     Фальшивая шина данных для обмена сообщений.
        /// </summary>
        private readonly IIntegrateBus _integrateBus = new IntegrateBusMock();

        /// <summary>
        ///     Построение заглушки <see cref="IIntegrateBus" />.
        /// </summary>
        /// <returns>Экземпляр заглушки объекта <see cref="IIntegrateBus" />.</returns>
        public IIntegrateBus Please()
        {
            return this._integrateBus;
        }
    }
}
