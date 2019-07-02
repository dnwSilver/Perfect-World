namespace Sharpdev.SDK.Layers.Infrastructure.Repositories.SearchParameters
{
    /// <summary>
    ///     Параметр для поиска.
    /// </summary>
    /// <typeparam name="TParameterType">Тип данных.</typeparam>
    public interface ISearchParameter<TParameterType>
    {
        /// <summary>
        ///     Используется ли параметр для поиска?
        /// </summary>
        bool IsUsed { get; }

        /// <summary>
        ///     Значение параметра для поиска.
        /// </summary>
        TParameterType Value { get; }

        /// <summary>
        ///     Фиксация значения параметра для поиска. Признак <see cref="IsUsed" /> true.
        /// </summary>
        /// <param name="parameterValue">Искомое значение.</param>
        void Use(TParameterType parameterValue);

        /// <summary>
        ///     Фиксация значения параметра для поиска. Признак <see cref="IsUsed" /> true.
        /// </summary>
        void UseDefault();
    }
}
