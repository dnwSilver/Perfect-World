namespace Sharpdev.SDK.Infrastructure.Repositories
{
    /// <summary>
    ///     Статус репозитория <see cref="IRepository{TAggregate,TRootEntity}" />.
    /// </summary>
    public enum RepositoryStatus : byte
    {
        /// <summary>
        ///     Статус не указан.
        /// </summary>
        None = 0x00,

        /// <summary>
        ///     Репозиторий работает.
        /// </summary>
        Up = 0x01,

        /// <summary>
        ///     Репозиторий не работает.
        /// </summary>
        Down = 0x02
    }
}
