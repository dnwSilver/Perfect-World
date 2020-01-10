using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Infrastructure.Repositories;

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
            _transaction = _boundedContext.Database.BeginTransaction();
        }

        /// <summary>
        ///     Выполняет определенные пользователем задачи, связанные с освобождением, освобождением
        ///     или сбросом неуправляемых ресурсов.
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            if (!_isCommitted)
                await RollbackAsync();

            _transaction.Dispose();
            _boundedContext.Dispose();
        }

        /// <summary>
        ///     Контекст источника данных.
        /// </summary>
        private readonly TBoundedContext _boundedContext;

        /// <summary>
        ///     Сохранение всех объектов в источник данных.
        /// </summary>
        public async Task CommitAsync()
        {
            try
            {
                await _boundedContext.SaveChangesAsync();
                _isCommitted = true;
            }
            catch (Exception exception)
            {
                throw new DataSourceInnerException("Вот так беда. Ничего не получилось.", exception);
            }
        }

        /// <summary>
        ///     Откат данных до первоначального состояния.
        /// </summary>
        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
        }
    }
}
