using Prosolve.MicroService.Watcher.DataAccess;

using Sharpdev.SDK.Layers.Infrastructure.Repositories;

namespace Prosolve.MicroService.Watcher.Domain
{
    /// <summary>
    ///     Механизм для работы с набором репозиториями.
    /// </summary>
    public class WatcherUnitOfWork : IUnitOfWork<WatcherContext>
    {
        /// <summary>
        ///     Признак успешного выполнения транзакции.
        /// </summary>
        private bool _isCommitted;

        public WatcherUnitOfWork(WatcherContext watcherContext)
        {
            this.BoundedContext = watcherContext;
        }

        /// <summary>
        ///     Выполняет определенные пользователем задачи, связанные с освобождением, освобождением
        ///     или сбросом неуправляемых ресурсов.
        /// </summary>
        public void Dispose()
        {
            if (!this._isCommitted)
                this.Rollback();
        }

        /// <summary>
        ///     Контекст источника данных.
        /// </summary>
        public WatcherContext BoundedContext { get; }

        /// <summary>
        ///     Сохранение всех объектов в источник данных.
        /// </summary>
        public void Commit()
        {
            this.BoundedContext.SaveChanges();
            this._isCommitted = true;
        }

        /// <summary>
        ///     Откат данных до первоначального состояния.
        /// </summary>
        public void Rollback()
        {
            //todo Обязательно должны быть добавлены логи.
        }
    }
}
