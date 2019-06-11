namespace Sharpdev.SDK.Layers.Infrastructure.Repositories
{
    /// <summary>
    ///     Статус репозитория.
    /// </summary>
    public enum RepositoryStatus : byte
    {
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
