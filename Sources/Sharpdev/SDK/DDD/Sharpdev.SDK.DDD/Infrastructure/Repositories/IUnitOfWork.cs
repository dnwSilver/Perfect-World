using System;

using Sharpdev.SDK.Domain;

namespace Sharpdev.SDK.Infrastructure.Repositories
{
    /// <summary>
    ///     Шаблон  Unit  of  Work  позволяет   упростить   работу   с   различными   репозиториями
    ///     (<seealso cref="IEntityRepository{TEntity}" />)  и  дает  уверенность, что все
    ///     репозитории будут использовать один и тот же контекст данных.
    /// </summary>
    public interface IUnitOfWork<out TBoundedContext> : IDisposable
        where TBoundedContext : IBoundedContext
    {
        /// <summary>
        ///     Контекст источника данных.
        /// </summary>
        TBoundedContext BoundedContext { get; }

        /// <summary>
        ///     Сохранение всех объектов в источник данных.
        /// </summary>
        void Commit();

        /// <summary>
        ///     Откат данных до первоначального состояния.
        /// </summary>
        void Rollback();
    }
}
