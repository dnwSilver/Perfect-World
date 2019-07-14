using Sharpdev.SDK.Layers.Infrastructure.Integrations;

namespace Sharpdev.SDK.Testing
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
        /// <returns>Экземпляр заглушки объекта <see cref="IIntegrateBus" /></returns>
        public IIntegrateBus Please()
        {
            return _integrateBus;
        }
    }
}
