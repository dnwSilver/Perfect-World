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
        private readonly Mock<ISpecification<IProcessEntity>> _processNameLengthSpecification =
            new Mock<ISpecification<IProcessEntity>>();

        /// <summary>
        ///     Построение объекта <see cref="IProcessEntity" />.
        /// </summary>
        /// <returns>Экземпляр объекта <see cref="IProcessEntity" /></returns>
        public ISpecification<IProcessEntity> Please()
        {
            return this._processNameLengthSpecification.Object;
        }

        public ProcessNameLengthSpecificationStub WithCriteria(int privateIdentifier)
        {
            this._processNameLengthSpecification.Setup(x => x.Expression)
                .Returns(x => x.Name.Length < privateIdentifier);

            return this;
        }
    }
}
