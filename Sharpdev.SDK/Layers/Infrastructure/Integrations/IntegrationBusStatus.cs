namespace Sharpdev.SDK.Layers.Infrastructure.Integrations
{
    /// <summary>
    ///     Статус шины обмена сообщениями <see cref="IIntegrateBus"/>.
    /// </summary>
    public enum IntegrationBusStatus : byte
    {
        /// <summary>
        ///     Статус не указан.
        /// </summary>
        None = 0x00,

        /// <summary>
        ///     Шина работает.
        /// </summary>
        Up = 0x01,

        /// <summary>
        ///     Шина не работает.
        /// </summary>
        Down = 0x02
    }
}
