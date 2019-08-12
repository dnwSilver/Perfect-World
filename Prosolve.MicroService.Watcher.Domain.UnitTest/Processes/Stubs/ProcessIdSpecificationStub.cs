using System;

using Prosolve.MicroService.Watcher.Domain.Processes;

using Sharpdev.SDK.Layers.Domain;
using Sharpdev.SDK.Testing;

namespace Prosolve.MicroService.Watcher.Domain.UnitTest.Processes.Stubs
{
    /// <summary>
    ///     Заглушка для процесса <see cref="ProcessNameLengthSpecification" />.
    /// </summary>
    public class ProcessIdSpecificationStub : ITestStub<ISpecification<IProcessEntity>>
    {
        /// <summary>
        ///     Заглушка для идентификатора.
        /// </summary>
        private ISpecification<IProcessEntity> _processNameLengthSpecification =
            new ProcessIdSpecification(Guid.Empty);

        /// <summary>
        /// Создание спецификации с конкретным идентификатором.
        /// </summary>
        /// <param name="publicId">Публичный идентификатор объекта.</param>
        /// <returns>Строитель для спецификации.</returns>
        public ProcessIdSpecificationStub WithId(Guid publicId)
        {
            _processNameLengthSpecification = new ProcessIdSpecification(publicId);

            return this;
        }
        
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
