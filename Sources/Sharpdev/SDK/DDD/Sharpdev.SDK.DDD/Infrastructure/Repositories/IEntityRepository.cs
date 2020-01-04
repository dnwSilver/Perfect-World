using System.Collections.Generic;
using System.Threading.Tasks;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Infrastructure.Statuses;

namespace Sharpdev.SDK.Infrastructure.Repositories
{
    /// <summary>
    ///     Репозиторий позволяет абстрагироваться от конкретных подключений к источникам данных, с
    ///     которыми  работает  программа,   и   является  промежуточным  звеном  между   классами,
    ///     непосредственно взаимодействующими с данными, и остальной программой.
    /// </summary>
    /// <typeparam name="TEntity">Корневой объект.</typeparam>
    /// <remarks>
    ///     Все репозитории должны соответствовать модели CRUD. CRUD — акроним, обозначающий четыре
    ///     базовые функции, используемые при работе с источниками данных:
    ///     - создание (<see cref="CreateAsync" />);
    ///     - чтение (<see cref="ReadAsync" />);
    ///     - модификация (<see cref="UpdateAsync" />);
    ///     - удаление (<see cref="DeleteAsync" />).
    /// </remarks>
    public interface IEntityRepository<TEntity> : IHasStatus<RepositoryStatus>
        where TEntity : class, IEntity<TEntity>
    {
        /// <summary>
        ///     Создание набора бизнес объектов.
        /// </summary>
        /// <param name="objectsToCreate">Список объектов для сохранения в хранилище.</param>
        Task CreateAsync(IEnumerable<TEntity> objectsToCreate);

        /// <summary>
        ///     Поиск и получение необходимых бизнес объектов в источнике данных.
        /// </summary>
        /// <param name="specification">Набор параметров для поиска.</param>
        /// <returns>Набор бизнес объектов.</returns>
        Task<IEnumerable<TEntity>> ReadAsync(ISpecification<TEntity> specification);

        /// <summary>
        ///     Обновление объектов.
        /// </summary>
        /// <param name="objectsToUpdate">Список бизнес объектов.</param>
        Task UpdateAsync(IEnumerable<TEntity> objectsToUpdate);

        /// <summary>
        ///     Удаление объектов.
        /// </summary>
        /// <param name="objectsToRemove">Список бизнес объектов.</param>
        Task DeleteAsync(IEnumerable<TEntity> objectsToRemove);

        void SetBoundedContext(IBoundedContext boundedContext);
    }
}
