using System.Collections.Generic;
using System.Threading.Tasks;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Infrastructure.Integrations;
using Sharpdev.SDK.Infrastructure.Statuses;
using Sharpdev.SDK.Types.Results;

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
    ///     - создание (<see cref="Create" />);
    ///     - чтение (<see cref="Read" />);
    ///     - модификация (<see cref="Update" />);
    ///     - удаление (<see cref="Delete" />).
    /// </remarks>
    public interface IEntityRepository<TEntity> : IHasStatus<RepositoryStatus>
        where TEntity : class, IEntity<TEntity>
    {
        /// <summary>
        ///     Создание набора бизнес объектов.
        /// </summary>
        /// <param name="objectsToCreate">Список объектов для сохранения в хранилище.</param>
        /// <returns>
        ///     True - сохранение выполнено успешно.
        ///     False - сохранение не выполнено.
        /// </returns>
        Task<Result> Create(IEnumerable<TEntity> objectsToCreate);

        /// <summary>
        ///     Поиск и получение необходимых бизнес объектов в источнике данных.
        /// </summary>
        /// <param name="specification">Набор параметров для поиска.</param>
        /// <returns>Набор бизнес объектов.</returns>
        Task<Result<IEnumerable<TEntity>>> Read(ISpecification<TEntity> specification);

        /// <summary>
        ///     Обновление объектов.
        /// </summary>
        /// <param name="objectsToUpdate">Список бизнес объектов.</param>
        /// <returns>
        ///     True - обновление выполнено успешно.
        ///     False - обновление не выполнено.
        /// </returns>
        Task<Result> Update(IEnumerable<TEntity> objectsToUpdate);

        /// <summary>
        ///     Удаление объектов.
        /// </summary>
        /// <param name="objectsToRemove">Список бизнес объектов.</param>
        /// <returns>
        ///     True - удаление выполнено успешно.
        ///     False - удаление не выполнено.
        /// </returns>
        Task<Result> Delete(IEnumerable<TEntity> objectsToRemove);

        void SetBoundedContext(IBoundedContext boundedContext);
    }
}
