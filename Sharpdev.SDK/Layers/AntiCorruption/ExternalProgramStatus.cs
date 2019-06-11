namespace Sharpdev.SDK.Layers.AntiCorruption
{
    /// <summary>
    ///     Статус сервиса.
    /// </summary>
    public enum ExternalProgramStatus : byte
    {
        /// <summary>
        ///     Сервис работает.
        /// </summary>
        Up = 0x01,

        /// <summary>
        ///     Сервис не работает.
        /// </summary>
        Down = 0x02,

        /// <summary>
        ///     Сервис находится на техническом обслуживании.
        /// </summary>
        Maintenance = 0x03
    }
}
