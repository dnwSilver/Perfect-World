using System.Collections.Generic;

using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Layers.Infrastructure.Repositories;

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
        IScalarParameter<IEnumerable<IIdentifier<TEntity>>> ByIdentifiers { get; set; }

        /// <summary>
        ///     Пропуск определенного количества элементов.
        /// </summary>
        IScalarParameter<int> Skip { get; set; }

        /// <summary>
        ///     Поле для сортировки.
        /// </summary>
        IScalarParameter<string> OrderBy { get; set; }

        /// <summary>
        ///     Извлечение определенного числа элементов.
        /// </summary>
        IScalarParameter<int> Take { get; set; }
    }
}
