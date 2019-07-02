﻿using System.Collections.Generic;

using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Layers.Infrastructure.Repositories.SearchParameters;

namespace Sharpdev.SDK.Layers.Domain.Factories
{
    /// <summary>
    ///     Набор параметров для поиска.
    /// </summary>
    public interface ISearchParameters<TEntity>
        where TEntity : IEntity<TEntity>
    {
        /// <summary>
        ///     Набор идентификаторов для поиска.
        /// </summary>
        ISearchParameter<IEnumerable<IIdentifier<TEntity>>> ByIdentifiers { get; set; }

        /// <summary>
        ///     Пропуск определенного количества элементов.
        /// </summary>
        ISearchParameter<int> Skip { get; set; }

        /// <summary>
        ///     Поле для сортировки.
        /// </summary>
        ISearchParameter<string> OrderBy { get; set; }

        /// <summary>
        ///     Извлечение определенного числа элементов.
        /// </summary>
        ISearchParameter<int> Take { get; set; }
    }
}
