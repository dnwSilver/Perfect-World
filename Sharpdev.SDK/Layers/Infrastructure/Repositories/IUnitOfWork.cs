using System;
using System.Threading;
using System.Threading.Tasks;

using Sharpdev.SDK.Layers.Domain.Entities;

namespace Sharpdev.SDK.Layers.Infrastructure.Repositories
{
    /// <summary>
    ///     Шаблон  Unit  of  Work  позволяет   упростить   работу   с   различными   репозиториями
    ///     (<seealso cref="IRepository{TEntity}" />)  и  дает  уверенность,
    ///     что все репозитории будут использовать один и тот же контекст данных.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        ///     Добавление репозитория.
        /// </summary>
        /// <typeparam name="TEntity">Доменный объект.</typeparam>
        /// <param name="repository">Добавляемый репозиторий.</param>
        void AddRepository<TEntity>(IRepository<TEntity> repository)
            where TEntity : IEntity<TEntity>;

        /// <summary>
        ///     Сохранение всех объектов в источник данных.
        /// </summary>
        /// <param name="cancellationToken">Знак для отмены действия.</param>
        /// <returns>
        ///     True - сохранение выполнено успешно.
        ///     False - сохранение не выполнено.
        /// </returns>
        Task<bool> SaveAsync(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Откат данных до первоначального состояния.
        /// </summary>
        /// <param name="cancellationToken">Знак для отмены действия.</param>
        /// <returns>
        ///     True - откат операций выполнен успешно.
        ///     False - откат операций не выполнен.
        /// </returns>
        Task<bool> RollbackAsync(CancellationToken cancellationToken = default);
    }
}
