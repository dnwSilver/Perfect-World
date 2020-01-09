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
    public sealed class DatabaseUnitOfWork<TBoundedContext> : IUnitOfWork
        where TBoundedContext : DbContext, IBoundedContext
    {
        /// <summary>
        ///     Признак успешного выполнения транзакции.
        /// </summary>
        private bool _isCommitted;

        private readonly IDbContextTransaction _transaction;

        public DatabaseUnitOfWork(TBoundedContext boundedContext)
        {
            _boundedContext = boundedContext;
            _transaction = boundedContext.Database.BeginTransaction();
        }

        /// <summary>
        ///     Выполняет определенные пользователем задачи, связанные с освобождением, освобождением
        ///     или сбросом неуправляемых ресурсов.
        /// </summary>
        public void Dispose()
        {
            if (!_isCommitted)
                Rollback();

            _transaction.Dispose();
        }

        /// <summary>
        ///     Контекст источника данных.
        /// </summary>
        private readonly TBoundedContext _boundedContext;

        /// <summary>
        ///     Сохранение всех объектов в источник данных.
        /// </summary>
        public Result Commit()
        {
            _transaction.Commit();

            _boundedContext.Database.CommitTransaction();
            // if (result == 0)
            //     return Result.Fail("Не удалось сохранить данные в источнике данных.");

            _isCommitted = true;

            return Result.Done();
        }

        /// <summary>
        ///     Откат данных до первоначального состояния.
        /// </summary>
        public void Rollback()
        {
            _transaction.Rollback();

            //todo Обязательно должны быть добавлены логи.
        }
    }
}
