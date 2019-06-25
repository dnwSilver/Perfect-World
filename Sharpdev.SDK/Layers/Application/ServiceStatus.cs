namespace Sharpdev.SDK.Layers.Application
{
    /// <summary>
    ///     Статус сервиса <see cref="IService" />.
    /// </summary>
    public enum ServiceStatus : byte
    {
        /// <summary>
        ///     Статус не указан.
        /// </summary>
        None = 0x00,

        /// <summary>
        ///     Сервис работает.
        /// </summary>
        Up = 0x01,

        /// <summary>
        ///     Сервис не работает.
        /// </summary>
        Down = 0x02
    }
}
