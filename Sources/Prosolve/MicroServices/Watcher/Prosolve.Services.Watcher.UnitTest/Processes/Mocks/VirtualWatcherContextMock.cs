using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using Prosolve.Services.Watcher.Domain.Processes.DataSources;

using Sharpdev.SDK.Testing;

namespace Prosolve.Services.Watcher.Domain.UnitTest.Processes.Mocks
{
    /// <summary>
    ///     Виртуальный контекст для базы данных. Данные будем хранить в памяти.
    /// </summary>
    public class VirtualWatcherContextMock : TestStubBase<WatcherContext>
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
        ///     Создание объекта.
        /// </summary>
        /// <param name="stubNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected override WatcherContext AllocateStub(int stubNumber)
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
