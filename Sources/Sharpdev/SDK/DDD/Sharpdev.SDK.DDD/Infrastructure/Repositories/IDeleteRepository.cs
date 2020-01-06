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
    ///     Данный репозиторий предназначен только для удаления агрегатов.
    /// </summary>
    /// <typeparam name="TAggregate"> Основная сущность для общения с источником данных. </typeparam>
    public interface IDeleteRepository<in TAggregate>
            where TAggregate: IAggregate<TAggregate>, IEntity<TAggregate>
    {
        /// <summary>
        ///     Удаление объектов.
        /// </summary>
        /// <param name="objectsToRemove"> Список бизнес объектов. </param>
        Task DeleteAsync(IEnumerable<TAggregate> objectsToRemove);
    }
}
