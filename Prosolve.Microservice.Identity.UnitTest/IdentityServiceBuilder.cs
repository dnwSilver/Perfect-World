using Sharpdev.SDK.Testing;

namespace Prosolve.MicroService.Identity.UnitTest
{
    /// <summary>
    ///     Строитель для создания сервиса для работы с пользователями.
    /// </summary>
    public class IdentityServiceBuilder : ITestBuilder<IIdentityService>
    {
        /// <summary>
        ///     Построение объекта <see cref="IIdentityService" />.
        /// </summary>
        /// <returns>Экземпляр объекта <see cref="IIdentityService" /></returns>
        public IIdentityService Please()
        {
            return new IdentityServiceTestable();
        }
    }
}
