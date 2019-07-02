namespace Sharpdev.SDK.Layers.Infrastructure.Repositories.SearchParameters
{
    /// <summary>
    ///     Параметр для поиска.
    /// </summary>
    /// <typeparam name="TParameter">Тип данных.</typeparam>
    public class SearchParameter<TParameter> : ISearchParameter<TParameter>
    {
        /// <summary>
        ///     Значение параметра по умолчанию.
        /// </summary>
        private readonly TParameter _defaultValue;

        /// <summary>
        ///     Инициализация объекта <see cref="SearchParameter{TParameter}"/>
        /// </summary>
        /// <param name="defaultParameterValue">Значение параметра по умолчанию.</param>
        public SearchParameter(TParameter defaultParameterValue)
        {
            _defaultValue = defaultParameterValue;
        }

        /// <summary>
        ///     Используется ли параметр для поиска?
        /// </summary>
        public bool IsUsed { get; private set; }

        /// <summary>
        ///     Значение параметра для поиска.
        /// </summary>
        public TParameter Value { get; private set; }

        /// <summary>
        ///     Фиксация значения параметра для поиска. При этом признак <see cref="ISearchParameter{TParameterType}.IsUsed" />=
        ///     true.
        /// </summary>
        /// <param name="parameterValue">Искомое значение.</param>
        public void Use(TParameter parameterValue)
        {
            IsUsed = true;
            Value = parameterValue;
        }

        /// <summary>
        ///     Фиксация значения по умолчанию. Признак <see cref="ISearchParameter{TParameterType}.IsUsed" /> true.
        /// </summary>
        public void UseDefault()
        {
            IsUsed = true;
            Value = _defaultValue;
        }
    }
}
