using System;
using System.Linq;
using System.Linq.Expressions;

using Sharpdev.SDK.Extensions;
using Sharpdev.SDK.Layers.Domain.Entities;

namespace Sharpdev.SDK.Layers.Domain
{
    /// <summary>
    ///     Спецификация  -  это  предикат,  который  определяет,  удовлетворяет  объект  некоторым
    ///     критериям или нет.
    /// </summary>
    /// <typeparam name="TEntity">Тип объекта для которого предназначена проверка.</typeparam>
    public abstract class SpecificationBase<TEntity> : ISpecification<TEntity>
        where TEntity : IEntity<TEntity>
    {
        /// <summary>
        ///     Функция для проведения проверки.
        /// </summary>
        private readonly Expression<Func<TEntity, bool>> _criteria;

        /// <summary>
        ///     Конструктор для инициализации объекта <see cref="SpecificationBase{TEntity}" />.
        /// </summary>
        /// <param name="criteria">Функция для проведения проверки.</param>
        protected SpecificationBase(Expression<Func<TEntity, bool>> criteria)
        {
            if (criteria.ReturnFailure())
                throw new ArgumentNullException(nameof(criteria));

            _criteria = criteria;
        }

        /// <summary>
        ///     Проверка пригодности объекта для удовлетворения потребности или достижения цели.
        /// </summary>
        /// <param name="candidate">Проверяемый объект.</param>
        /// <returns>
        ///     <see langword="true" /> - Объект <see cref="TEntity" /> прошёл проверку.
        ///     <see langword="false" /> - Объект <see cref="TEntity" /> не прошёл проверку.
        /// </returns>
        public bool IsSatisfiedBy(TEntity candidate)
        {
            if (candidate == null)
                throw new ArgumentNullException(nameof(candidate));

            TEntity[] candidates = { candidate };

            return candidates.AsQueryable().Any();
        }

        /// <summary>
        ///     Формирование функции для проведения проверки пригодности объекта для удовлетворения
        ///     потребности или достижения цели.
        /// </summary>
        /// <returns>Функция для проверки.</returns>
        public Expression<Func<TEntity, bool>> ToExpression()
        {
            return _criteria;
        }
    }
}
