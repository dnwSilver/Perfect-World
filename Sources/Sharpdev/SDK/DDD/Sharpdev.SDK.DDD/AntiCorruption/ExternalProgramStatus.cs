namespace Sharpdev.SDK.AntiCorruption
{
    /// <summary>
    ///     Статус сервиса.
    /// </summary>
    public enum ExternalProgramStatus
    {
        /// <summary>
        ///     Статус не указан.
        /// </summary>
        None,

        /// <summary>
        ///     Сервис работает.
        /// </summary>
        Up,

        /// <summary>
        ///     Сервис не работает.
        /// </summary>
        Down,

        /// <summary>
        ///     Сервис находится на техническом обслуживании.
        /// </summary>
        Maintenance
    }
}
