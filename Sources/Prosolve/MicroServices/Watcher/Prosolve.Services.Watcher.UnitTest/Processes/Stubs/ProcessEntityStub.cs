using Moq;

using Prosolve.Services.Watcher.Domain.Processes;

using Sharpdev.SDK.Testing;

namespace Prosolve.Services.Watcher.Domain.UnitTest.Processes.Stubs
{
    /// <summary>
    ///     Заглушка для процесса <see cref="IProcessEntity" />.
    /// </summary>
    public class ProcessEntityStub : ITestStub<IProcessEntity>
    {
        /// <summary>
        ///     Заглушка для идентификатора.
        /// </summary>
        private readonly Mock<IProcessEntity> _processMock = new Mock<IProcessEntity>();

        /// <summary>
        ///     Построение объекта <see cref="IProcessEntity" />.
        /// </summary>
        /// <returns>Экземпляр объекта <see cref="IProcessEntity" /></returns>
        public IProcessEntity Please()
        {
            return this._processMock.Object;
        }
    }
}
