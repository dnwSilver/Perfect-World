using System;
using System.Linq.Expressions;

using Sharpdev.SDK.Layers.Domain.Entities;

namespace Sharpdev.SDK.Layers.Domain
{
    /// <summary>
    ///     Спецификация  -  это  предикат,  который  определяет,  удовлетворяет  объект  некоторым
    ///     критериям или нет.
    /// </summary>
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
        where TEntity : IEntity<TEntity>
    {
        /// <summary>
        ///     Проверка пригодности объекта для удовлетворения потребности или достижения цели.
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        bool IsSatisfiedBy(TEntity candidate);

        Expression<Func<TEntity, bool>> ToExpression();
    }
}
