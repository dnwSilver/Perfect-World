using System;

using Sharpdev.SDK.Types.Results;

namespace Sharpdev.SDK.Infrastructure.Repositories
{
    /// <summary>
    ///     Шаблон Unit of Work позволяет упростить работу с репозиториями <see cref="IRepository{TAggregate}"/> и
    ///     дает уверенность, что все репозитории будут использовать один и тот же  контекст данных.
    /// </summary>
    public interface IUnitOfWork: IDisposable
    {
        /// <summary>
        ///     Сохранение всех объектов в источник данных.
        /// </summary>
        Result Commit();

        /// <summary>
        ///     Откат данных до первоначального состояния.
        /// </summary>
        void Rollback();
    }
}
