namespace Sharpdev.SDK.Layers.Infrastructure.Repositories
{
    /// <summary>
    ///     Параметр для поиска.
    /// </summary>
    /// <typeparam name="TParameterType">Тип данных.</typeparam>
    public interface IScalarParameter<TParameterType>
    {
        /// <summary>
        ///     Используется ли параметр для поиска?
        /// </summary>
        bool IsUsed { get; set; }

        /// <summary>
        ///     Значение параметра для поиска.
        /// </summary>
        TParameterType Value { get; set; }
    }
}
