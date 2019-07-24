using System;

using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Layers.Domain.Factories;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.MicroService.Watcher.Domain.Processes
{
    /// <summary>
    ///     Фабрика для объекта <see cref="IProcessEntity" />.
    /// </summary>
    public class ProcessFactory : IFactory<IProcessEntity>
    {
        /// <summary>
        ///     Создание нового объекта.
        /// </summary>
        /// <param name="processBuilder">Строитель нового объекта.</param>
        /// <returns>Созданный объект.</returns>
        public Result<IProcessEntity> Create(IEntityBuilder<IProcessEntity> processBuilder)
        {
            Identifier<IProcessEntity> processIdentifier = new Identifier<IProcessEntity>(
                Identifier<IProcessEntity>.Undefined,
                Guid.NewGuid(),
                processBuilder.Identifier.Externals);
            processBuilder.SetIdentifier(processIdentifier);

            IProcessEntity process = this.AllocateProcess(processBuilder);

            this.CheckSpecification(process);

            return Result.Ok(process);
        }

        /// <summary>
        ///     Восстановление уже созданного объекта.
        /// </summary>
        /// <param name="processBuilder">Строитель восстанавливаемого объекта.</param>
        /// <returns>Восстановленный объект.</returns>
        public Result<IProcessEntity> Recovery(IEntityBuilder<IProcessEntity> processBuilder)
        {
            IProcessEntity process = this.AllocateProcess(processBuilder);

            Result specificationResult = this.CheckSpecification(process);

            if (specificationResult.Failure)
                return Result.Fail<IProcessEntity>(specificationResult.Errors);
            
            return Result.Ok(process);
        }

        /// <summary>
        ///     Создание объекта и размещение его в памяти.
        /// </summary>
        /// <param name="processBuilder">Строитель для объекта <see cref="IProcessEntity" />.</param>
        /// <returns>Ссылка на созданный в куче объект.</returns>
        private IProcessEntity AllocateProcess(IEntityBuilder<IProcessEntity> processBuilder)
        {
            ProcessEntity process = new ProcessEntity(processBuilder as IProcessBuilder);

            this.CheckSpecification(process);

            return process;
        }

        /// <summary>
        ///     Проверяем объект на соответствие всем спецификациям.
        /// </summary>
        /// <param name="process">Проверяемый объект.</param>
        /// <returns></returns>
        private Result CheckSpecification(IProcessEntity process)
        {
            ProcessNameLengthSpecification spec = new ProcessNameLengthSpecification();

            return spec.IsSatisfiedBy(process);
        }
    }
}
