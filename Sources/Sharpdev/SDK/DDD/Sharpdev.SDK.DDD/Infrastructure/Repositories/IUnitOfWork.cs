using System;
using System.Threading.Tasks;

namespace Sharpdev.SDK.Infrastructure.Repositories
{
    /// <summary>
    ///     Шаблон Unit of Work позволяет упростить работу с репозиториями <see cref="IRepository{TAggregate}"/> и
    ///     дает уверенность, что все репозитории будут использовать один и тот же  контекст данных. При помощи единого
    ///     рабочего мы делаем операции записи данных атомарными.
    /// </summary>
    public interface IUnitOfWork: IAsyncDisposable
    {
        /// <summary>
        ///     Сохранение всех объектов в источник данных.
        /// </summary>
        Task CommitAsync();

        /// <summary>
        ///     Откат данных до первоначального состояния.
        /// </summary>
        Task RollbackAsync();
    }
}
