namespace Sharpdev.SDK.Layers.Infrastructure.Integrations
{
    /// <summary>
    ///     Статус шины обмена сообщениями.
    /// </summary>
    public enum IntegrationBusStatus : byte
    {
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
