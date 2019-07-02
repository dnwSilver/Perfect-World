using System.Collections.Generic;
using System.Linq;

using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Layers.Infrastructure.Repositories.SearchParameters;

namespace Sharpdev.SDK.Layers.Domain.Factories
{
    /// <summary>
    ///     Базовый класс для всех наборов параметров.
    /// </summary>
    public abstract class SearchParametersBase<TEntity> : ISearchParameters<TEntity>
        where TEntity : IEntity<TEntity>
    {
        /// <summary>
        ///     Набор идентификаторов для поиска.
        /// </summary>
        public ISearchParameter<IEnumerable<IIdentifier<TEntity>>> ByIdentifiers { get; set; } =
            new SearchParameter<IEnumerable<IIdentifier<TEntity>>>(Enumerable.Empty<IIdentifier<TEntity>>());

        /// <summary>
        ///     Пропуск определенного количества элементов.
        /// </summary>
        public ISearchParameter<int> Skip { get; set; } = new SearchParameter<int>(SearchParameterDefault.Skip);

        /// <summary>
        ///     Поле для сортировки.
        /// </summary>
        public ISearchParameter<string> OrderBy { get; set; } =
            new SearchParameter<string>(SearchParameterDefault.OrderBy);

        /// <summary>
        ///     Извлечение определенного числа элементов.
        /// </summary>
        public ISearchParameter<int> Take { get; set; } = new SearchParameter<int>(SearchParameterDefault.Take);
    }
}
