using System.Collections.Generic;
using System.Threading.Tasks;

using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Layers.Domain.Factories;
using Sharpdev.SDK.Layers.Infrastructure.Statuses;
using Sharpdev.SDK.Types.Results;

namespace Sharpdev.SDK.Layers.Infrastructure.Repositories
{
    /// <summary>
    ///     Репозиторий позволяет абстрагироваться от конкретных подключений к источникам данных, с
    ///     которыми  работает  программа,   и   является  промежуточным  звеном  между   классами,
    ///     непосредственно взаимодействующими с данными, и остальной программой.
    /// </summary>
    /// <typeparam name="TEntity">Корневой объект.</typeparam>
    /// <typeparam name="TSearchParameters">Набор параметров для поиска объекта.</typeparam>
    /// <remarks>
    ///     Все репозитории должны соответствовать модели CRUD. CRUD — акроним, обозначающий четыре
    ///     базовые функции, используемые при работе с источниками данных:
    ///     - создание (<see cref="CreateAsync" />);
    ///     - чтение (<see cref="ReadAsync" />);
    ///     - модификация (<see cref="UpdateAsync" />);
    ///     - удаление (<see cref="DeleteAsync" />).
    /// </remarks>
    public interface IRepository<TEntity, in TSearchParameters> : IHasStatus<RepositoryStatus>
        where TEntity : IEntity<TEntity>
        where TSearchParameters : ISearchParameters<TEntity>
    {
        /// <summary>
        ///     Создание набора бизнес объектов.
        /// </summary>
        /// <param name="objectsToCreate">Список объектов для сохранения в хранилище.</param>
        /// <returns>
        ///     True - сохранение выполнено успешно.
        ///     False - сохранение не выполнено.
        /// </returns>
        Result Create(IReadOnlyCollection<TEntity> objectsToCreate);

        /// <summary>
        ///     Поиск и получение необходимых бизнес объектов в источнике данных.
        /// </summary>
        /// <param name="searchParameters">Набор параметров для поиска.</param>
        /// <returns>Набор бизнес объектов.</returns>
        Result<IReadOnlyCollection<TEntity>> Read(TSearchParameters searchParameters);

        /// <summary>
        ///     Обновление объектов.
        /// </summary>
        /// <param name="objectsToUpdate">Список бизнес объектов.</param>
        /// <returns>
        ///     True - обновление выполнено успешно.
        ///     False - обновление не выполнено.
        /// </returns>
        Result Update(IReadOnlyCollection<TEntity> objectsToUpdate);

        /// <summary>
        ///     Удаление объектов.
        /// </summary>
        /// <param name="objectsToRemove">Список бизнес объектов.</param>
        /// <returns>
        ///     True - удаление выполнено успешно.
        ///     False - удаление не выполнено.
        /// </returns>
        Result Delete(IReadOnlyCollection<TEntity> objectsToRemove);
    }
}
