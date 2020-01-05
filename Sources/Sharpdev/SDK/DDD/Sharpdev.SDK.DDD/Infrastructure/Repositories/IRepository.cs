using System.Collections.Generic;
using System.Threading.Tasks;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Domain.Entities;

namespace Sharpdev.SDK.Infrastructure.Repositories
{
    /// <summary>
    ///     Репозиторий позволяет абстрагироваться от конкретных подключений к источникам данных, с
    ///     которыми  работает  программа,   и   является  промежуточным  звеном  между   классами,
    ///     непосредственно взаимодействующими с данными, и остальной программой.
    /// </summary>
    /// <typeparam name="TAggregate"> Основная сущность для общения с источником данных. </typeparam>
    /// <remarks>
    ///     Все репозитории должны соответствовать модели CRUD. CRUD — акроним, обозначающий четыре
    ///     базовые функции, используемые при работе с источниками данных:
    ///     - создание (<see cref="CreateAsync"/>);
    ///     - чтение (<see cref="ReadAsync"/>);
    ///     - модификация (<see cref="UpdateAsync"/>);
    ///     - удаление (<see cref="DeleteAsync"/>).
    /// </remarks>
    public interface IRepository<TAggregate>
            where TAggregate: IAggregate<TAggregate>, IEntity<TAggregate>
    {
        /// <summary>
        ///     Создание набора бизнес объектов.
        /// </summary>
        /// <param name="objectsToCreate"> Список объектов для сохранения в хранилище. </param>
        Task CreateAsync(IEnumerable<TAggregate> objectsToCreate);

        /// <summary>
        ///     Поиск и получение необходимых бизнес объектов в источнике данных.
        /// </summary>
        /// <param name="specification"> Набор параметров для поиска. </param>
        /// <returns> Набор бизнес объектов. </returns>
        Task<IEnumerable<TAggregate>> ReadAsync(ISpecification<TAggregate> specification);

        /// <summary>
        ///     Обновление объектов.
        /// </summary>
        /// <param name="objectsToUpdate"> Список бизнес объектов. </param>
        Task UpdateAsync(IEnumerable<TAggregate> objectsToUpdate);

        /// <summary>
        ///     Удаление объектов.
        /// </summary>
        /// <param name="objectsToRemove"> Список бизнес объектов. </param>
        Task DeleteAsync(IEnumerable<TAggregate> objectsToRemove);

        void SetBoundedContext(IBoundedContext boundedContext);
    }
}
