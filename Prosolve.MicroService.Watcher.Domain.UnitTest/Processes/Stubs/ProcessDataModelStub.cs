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
        private readonly Mock<ProcessDataModel> _processDataModelMock =
            new Mock<ProcessDataModel>();

        /// <summary>
        ///     Построение объекта <see cref="ProcessDataModel" />.
        /// </summary>
        /// <returns>Экземпляр объекта <see cref="ProcessDataModel" /></returns>
        public ProcessDataModel Please()
        {
            var processDataModel = new ProcessDataModel()
            {
                
            };
            this._processDataModelMock.Setup(x => x.PrivateId).Returns(1);
            this._processDataModelMock.Setup(x => x.PublicId).Returns(Guid.Empty);
            this._processDataModelMock.Setup(x => x.Name).Returns("Мой первый процесс.");

            return this._processDataModelMock.Object;
        }
    }
}
