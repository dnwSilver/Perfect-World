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
    ///     - создание (<see cref="ICreateRepository{TAggregate}.CreateAsync"/>);
    ///     - чтение (<see cref="IReadRepository{TAggregate}.ReadAsync"/>);
    ///     - модификация (<see cref="IUpdateRepository{TAggregate}.UpdateAsync"/>);
    ///     - удаление (<see cref="IDeleteRepository{TAggregate}.DeleteAsync"/>).
    /// </remarks>
    public interface IRepository<TAggregate>: ICreateRepository<TAggregate>, IReadRepository<TAggregate>,
    IUpdateRepository<TAggregate>, IDeleteRepository<TAggregate>
            where TAggregate: IAggregate<TAggregate>, IEntity<TAggregate>
    {
    }
}
