using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Moq;

using Prosolve.MicroService.Watcher.DataAccess;

using Sharpdev.SDK.Testing;

namespace Prosolve.MicroService.Watcher.Domain.UnitTest.Processes.Mocks
{
    /// <summary>
    ///     Виртуальный контекст для базы данных. Данные будем хранить в памяти.
    /// </summary>
    public class VirtualWatcherContextMock : ITestStub<WatcherContext>
    {
        /// <summary>
        ///     Фальшивая шина данных для обмена сообщений.
        /// </summary>
        private readonly Mock<WatcherContext> _watcherContext = new Mock<WatcherContext>();

        /// <summary>
        ///     Построение заглушки <see cref="WatcherContext" />.
        /// </summary>
        /// <returns>Экземпляр заглушки объекта <see cref="WatcherContext" /></returns>
        public WatcherContext Please()
        {
            return this._watcherContext.Object;
        }


        public VirtualWatcherContextMock With(ProcessDataModel process)
        {
            var data = new List<ProcessDataModel>
            {
                process
            }.AsQueryable();

            var mockSet = new Mock<DbSet<ProcessDataModel>>();
            mockSet.As<IQueryable<ProcessDataModel>>()
                   .Setup(m => m.Provider)
                   .Returns(data.Provider);

            this._watcherContext.Setup(x => x.Processes).Returns(mockSet.Object);

            return this;
        }
    }
}
