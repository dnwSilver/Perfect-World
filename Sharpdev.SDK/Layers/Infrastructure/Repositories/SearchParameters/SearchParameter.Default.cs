namespace Sharpdev.SDK.Layers.Infrastructure.Repositories.SearchParameters
{
    /// <summary>
    ///     Параметр для поиска.
    /// </summary>
    public static class SearchParameterDefault
    {
        /// <summary>
        ///     Значение по умолчанию для количества элементов в выборке.
        /// </summary>
        public const int Take = 10;

        /// <summary>
        ///     Значение по умолчанию для сортировки элементов в выборке.
        /// </summary>
        public const string OrderBy = "Id";

        /// <summary>
        ///     Значение по умолчанию для пропуска элементов в выборке.
        /// </summary>
        public const int Skip = 0;
    }
}
