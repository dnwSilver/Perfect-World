using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Infrastructure.Repositories;
using Sharpdev.SDK.Types.Results;

namespace Sharpdev.SDK.DataSources.Databases
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

        private readonly IDbContextTransaction _transaction;

        public DatabaseUnitOfWork(TBoundedContext boundedContext)
        {
            this.BoundedContext = boundedContext;
            this._transaction = boundedContext.Database.BeginTransaction();
        }

        /// <summary>
        ///     Выполняет определенные пользователем задачи, связанные с освобождением, освобождением
        ///     или сбросом неуправляемых ресурсов.
        /// </summary>
        public void Dispose()
        {
            if (!this._isCommitted)
                this.Rollback();

            this._transaction.Dispose();
        }

        /// <summary>
        ///     Контекст источника данных.
        /// </summary>
        public TBoundedContext BoundedContext { get; }

        /// <summary>
        ///     Сохранение всех объектов в источник данных.
        /// </summary>
        public Result Commit()
        {
            this._transaction.Commit();

            // if (result == 0)
            //     return Result.Fail("Не удалось сохранить данные в источнике данных.");

            this._isCommitted = true;

            return Result.Ok();
        }

        /// <summary>
        ///     Откат данных до первоначального состояния.
        /// </summary>
        public void Rollback()
        {
            this._transaction.Rollback();

            //todo Обязательно должны быть добавлены логи.
        }
    }
}
