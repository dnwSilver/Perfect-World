using System;
using System.Collections.Generic;
using System.Linq;

using Prosolve.MicroService.Watcher.DataAccess;

using Sharpdev.SDK.Testing.Stubs;

namespace Prosolve.MicroService.Watcher.Domain.UnitTest.Processes.Stubs
{
    /// <summary>
    ///     Заглушка для процесса <see cref="ProcessDataModel" />.
    /// </summary>
    public class ProcessDataModelStub : ITestStub<IList<ProcessDataModel>>
    {
        /// <summary>
        ///     Заглушка для идентификатора.
        /// </summary>
        private readonly IList<ProcessDataModel> _processDataModels =
            new List<ProcessDataModel>();

        /// <summary>
        ///     Построение объекта <see cref="ProcessDataModel" />.
        /// </summary>
        /// <returns>Экземпляр объекта <see cref="ProcessDataModel" /></returns>
        public IList<ProcessDataModel> Please()
        {
            if (!this._processDataModels.Any())
                this.CountOf(1);
            return this._processDataModels;
        }
        
        /// <summary>
        /// Создание набора процессов.
        /// </summary>
        /// <param name="countProcess"></param>
        /// <returns></returns>
        public ProcessDataModelStub CountOf(int countProcess)
        {
            for(var id = 1; id <= countProcess; id++)
            {
                var processDataModel = new ProcessDataModel();
                processDataModel.PrivateId = id;
                processDataModel.PublicId = Guid.NewGuid();
                processDataModel.Name = $"Процесс №{id}.";
                this._processDataModels.Add(processDataModel);
            }
            return this;
        }
    }
}
