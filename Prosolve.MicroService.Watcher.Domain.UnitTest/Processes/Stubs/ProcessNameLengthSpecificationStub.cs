using Moq;

using Prosolve.MicroService.Watcher.Domain.Processes;

using Sharpdev.SDK.Layers.Domain;
using Sharpdev.SDK.Testing;

namespace Prosolve.MicroService.Watcher.Domain.UnitTest.Processes.Stubs
{
    /// <summary>
    ///     Заглушка для процесса <see cref="ProcessNameLengthSpecification" />.
    /// </summary>
    public class ProcessNameLengthSpecificationStub : ITestStub<ISpecification<IProcessEntity>>
    {
        /// <summary>
        ///     Заглушка для идентификатора.
        /// </summary>
        private readonly ISpecification<IProcessEntity> _processNameLengthSpecification =
            new ProcessNameLengthSpecification();

        /// <summary>
        ///     Построение объекта <see cref="IProcessEntity" />.
        /// </summary>
        /// <returns>Экземпляр объекта <see cref="IProcessEntity" /></returns>
        public ISpecification<IProcessEntity> Please()
        {
            return this._processNameLengthSpecification;
        }
    }
}
