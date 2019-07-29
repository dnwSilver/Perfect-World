using System;

using Microsoft.EntityFrameworkCore;

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
        ///     Настройки для виртуального источника данных.
        /// </summary>
        private readonly DbContextOptions<WatcherContext> _options;

        /// <summary>
        ///     Инициализация контекста данных хранимого в памяти.
        /// </summary>
        public VirtualWatcherContextMock()
        {
            this._options = new DbContextOptionsBuilder<WatcherContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .Options;
        }

        /// <summary>
        ///     Построение заглушки <see cref="WatcherContext" />.
        /// </summary>
        /// <returns>Экземпляр заглушки объекта <see cref="WatcherContext" /></returns>
        public WatcherContext Please()
        {
            return new WatcherContext(this._options);
        }

        /// <summary>
        ///     Добавление нового процесса в контекст источника данных.
        /// </summary>
        /// <param name="process">Новый процесс.</param>
        /// <returns>Строитель для контекста данных.</returns>
        public VirtualWatcherContextMock With(ProcessDataModel process)
        {
            using(var watcherContext = new WatcherContext(this._options))
            {
                watcherContext.Processes.Add(process);
                watcherContext.SaveChanges();
            }

            return this;
        }
    }
}
