using System;

using Moq;

using Prosolve.MicroService.Watcher.DataAccess;

using Sharpdev.SDK.Extensions;
using Sharpdev.SDK.Testing;

namespace Prosolve.MicroService.Watcher.Domain.UnitTest.Processes.Stubs
{
    /// <summary>
    ///     Заглушка для процесса <see cref="ProcessDataModel" />.
    /// </summary>
    public class ProcessDataModelStub : ITestStub<ProcessDataModel>
    {
        /// <summary>
        ///     Заглушка для идентификатора.
        /// </summary>
        private readonly ProcessDataModel _processDataModel =
            new ProcessDataModel();

        /// <summary>
        ///     Построение объекта <see cref="ProcessDataModel" />.
        /// </summary>
        /// <returns>Экземпляр объекта <see cref="ProcessDataModel" /></returns>
        public ProcessDataModel Please()
        {
            this._processDataModel.PrivateId = 1;
            this._processDataModel.PublicId = Guid.Empty;
            this._processDataModel.Name = "Мой первый процесс.";

            return this._processDataModel;
        }
    }
}
