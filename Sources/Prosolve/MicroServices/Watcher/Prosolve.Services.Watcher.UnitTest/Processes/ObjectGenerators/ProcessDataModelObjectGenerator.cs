using System;

using Prosolve.Services.Watcher.Domain.Processes.DataSources;

using Sharpdev.SDK.Testing;

namespace Prosolve.Services.Watcher.Domain.UnitTest.Processes.ObjectGenerators
{
    /// <summary>
    ///     Заглушка для процесса <see cref="ProcessDataModel" />.
    /// </summary>
    public class ProcessDataModelObjectGenerator : TestObjectGeneratorBase<ProcessDataModel>
    {
        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="stubNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected override ProcessDataModel AllocateStub(int stubNumber)
        {
            var processDataModel = new ProcessDataModel();
            processDataModel.PublicId = Guid.NewGuid();
            processDataModel.Name = $"Процесс №{stubNumber}.";
            processDataModel.TypeName = $"Тип №{stubNumber}.";

            return processDataModel;
        }
    }
}
