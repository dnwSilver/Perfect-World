namespace Sharpdev.SDK.Layers.Application
{
    /// <summary>
    ///     Статус сервиса.
    /// </summary>
    public enum ServiceStatus : byte
    {
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
