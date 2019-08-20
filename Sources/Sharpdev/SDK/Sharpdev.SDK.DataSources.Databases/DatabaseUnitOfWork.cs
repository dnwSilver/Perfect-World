using Microsoft.EntityFrameworkCore;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Infrastructure.Repositories;

namespace Prosolve.Services.Watcher.Domain
{
    /// <summary>
    ///     Механизм для работы с набором репозиториями.
    /// </summary>
    public sealed class DatabaseUnitOfWork<TBoundedContext> : IUnitOfWork<TBoundedContext>
        where TBoundedContext : DbContext, IBoundedContext
    {
        /// <summary>
        ///     Признак успешного выполнения транзакции.
        /// </summary>
        private bool _isCommitted;

        public DatabaseUnitOfWork(TBoundedContext boundedContext)
        {
            this.BoundedContext = boundedContext;
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
        public TBoundedContext BoundedContext { get; }

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
