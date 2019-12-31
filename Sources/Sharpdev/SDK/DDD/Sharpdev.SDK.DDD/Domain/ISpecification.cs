using System;
using System.Linq.Expressions;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Types.Results;

namespace Sharpdev.SDK.Domain
{
    /// <summary>
    ///     Спецификация  -  это  предикат,  который  определяет,  удовлетворяет  объект  некоторым
    ///     критериям или нет.
    /// </summary>
    /// <typeparam name="TEntity">Тип объекта для которого предназначена проверка.</typeparam>
    /// <remarks>
    ///     Ценность спецификаций в значительной мере состоит в том,  что они сводят воедино  такие
    ///     прикладные  функции,  которые  могут  показаться   совершенно  различными.   Нам  может
    ///     понадобиться определить состояние некоторого объекта для одной или нескольких следующих
    ///     целей.
    ///     1.  Проверить пригодность объекта для   удовлетворения потребности или достижения цели.
    ///     2.  Выбрать объект из коллекции ему подобных.
    ///     3.  Заказать создание нового объекта для определенных потребностей.
    /// </remarks>
    public interface ISpecification<TEntity>
        where TEntity : class, IEntity<TEntity>
    {
        /// <summary>
        ///     Проверка пригодности объекта для удовлетворения потребности или достижения цели.
        /// </summary>
        /// <param name="candidate">Проверяемый объект.</param>
        /// <returns>
        ///     <see langword="true" /> - Объект <see cref="TEntity"/> прошёл проверку.
        ///     <see langword="false" /> - Объект <see cref="TEntity"/> не прошёл проверку.
        /// </returns>
        Result IsSatisfiedBy(TEntity candidate);

        /// <summary>
        ///     Формирование функции для проведения проверки пригодности объекта для удовлетворения
        ///     потребности или достижения цели.
        /// </summary>
        /// <returns>Функция для проверки.</returns>
        Expression<Func<TEntity, bool>> Expression { get; }
    }
}
