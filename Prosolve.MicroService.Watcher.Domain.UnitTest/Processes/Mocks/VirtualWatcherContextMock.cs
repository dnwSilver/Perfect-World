using System;
using System.Collections.Generic;

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
        /// <param name="processDataModel">Новый процесс.</param>
        /// <returns>Строитель для контекста данных.</returns>
        public VirtualWatcherContextMock With(ProcessDataModel processDataModel)
        {
            using(var watcherContext = new WatcherContext(this._options))
            {
                watcherContext.Processes.Add(processDataModel);
                watcherContext.SaveChanges();
            }

            return this;
        }

        /// <summary>
        ///     Добавление новых процессов в контекст источника данных.
        /// </summary>
        /// <param name="processDataModels">Список новых процессов.</param>
        /// <returns>Строитель для контекста данных.</returns>
        public VirtualWatcherContextMock With(IEnumerable<ProcessDataModel> processDataModels)
        {
            foreach(var processDataModel in processDataModels)
                this.With(processDataModel);

            return this;
        }
    }
}
