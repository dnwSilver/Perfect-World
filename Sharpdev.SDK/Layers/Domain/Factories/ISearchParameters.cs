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
        ///     Набор параметров заданного типа.
        /// </summary>
        /// <typeparam name="TParameterType">Тип данных.</typeparam>
        /// <returns>Коллекция параметров заданного типа.</returns>
        IReadOnlyCollection<IScalarParameter<TParameterType>> GetParameters<TParameterType>();

        /// <summary>
        ///     Набор идентификаторов для поиска.
        /// </summary>
        /// <param name="identifiers">Набор идентификаторов.</param>
        /// <returns></returns>
        ISearchParameters<TEntity> ByIdentifiers(IReadOnlyCollection<IIdentifier<TEntity>> identifiers);

        /// <summary>
        ///     Пропуск определенного количества элементов.
        /// </summary>
        /// <param name="countItemsToSkip">Количество пропущенных элементов.</param>
        /// <returns>Набор параметров <see cref="ISearchParameters{T}" />.</returns>
        ISearchParameters<TEntity> Skip(int countItemsToSkip);

        /// <summary>
        ///     Поле для сортировки.
        /// </summary>
        /// <param name="fieldName">Имя поля для сортировки.</param>
        /// <returns>Набор параметров <see cref="ISearchParameters{T}" />.</returns>
        ISearchParameters<TEntity> OrderBy(string fieldName);

        /// <summary>
        ///     Извлечение определенного числа элементов.
        /// </summary>
        /// <param name="countItemsToTake">Количество извлекаемых элементов.</param>
        /// <returns>Набор параметров <see cref="ISearchParameters{T}" />.</returns>
        ISearchParameters<TEntity> Take(int countItemsToTake);
    }
}
