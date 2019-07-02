namespace Sharpdev.SDK.Layers.Infrastructure.Repositories.SearchParameters
{
    public class SearchParameterString : SearchParameter<string>, ISearchParameter<string>
    {
        /// <summary>
        ///     Инициализация объекта <see cref="SearchParameter{TParameter}" />
        /// </summary>
        /// <param name="defaultParameterValue">Значение параметра по умолчанию.</param>
        public SearchParameterString(string defaultParameterValue)
            : base(defaultParameterValue)
        {
        }
    }
}
