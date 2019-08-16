namespace Sharpdev.SDK.Infrastructure.Repositories
{
    /// <summary>
    ///     Объект хранимый в источнике данных.
    /// </summary>
    public interface IStored : IVersioned
    {
        /// <summary>
        ///     Признак  безопасного  удаления  объекта.  Информация по объекту не будет стираться,
        ///     у объекта  будет выставлен  признак его  блокировки и он перестанет  участвовать во
        ///     всех  операциях в системе.  Разблокировать  можно  будет  только  ручным  образом в
        ///     источнике данных.
        /// </summary>
        /// <returns>
        ///     <see langword="true" /> - используется безопасное удаление.
        ///     <see langword="false" /> - используется не безопасное удаление.
        /// </returns>
        bool IsSoftDelete { get; }
    }
}
