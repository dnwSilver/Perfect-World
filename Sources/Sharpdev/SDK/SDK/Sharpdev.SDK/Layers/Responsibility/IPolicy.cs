namespace Sharpdev.SDK.Layers.Responsibility
{
    /// <summary>
    ///     Регламент.  Правила  и  цели в основном  носят  пассивный   характер,  но   накладывают
    ///     ограничения на работу других уровней.
    /// </summary>
    public interface IPolicy
    {
        /// <summary>
        ///     Название регламентного правила.
        /// </summary>
        string Name { get; }
    }
}
