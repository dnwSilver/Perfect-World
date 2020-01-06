using System;
using System.Linq;
using System.Linq.Expressions;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Extensions;
using Sharpdev.SDK.Types.Results;

namespace Sharpdev.SDK.Domain
{
    /// <summary>
    ///     Спецификация  -  это  предикат,  который  определяет,  удовлетворяет  объект  некоторым
    ///     критериям или нет.
    /// </summary>
    /// <typeparam name="TEntity">Тип объекта для которого предназначена проверка.</typeparam>
    public class SpecificationBase<TEntity> : ISpecification<TEntity>
        where TEntity : class, IEntity<TEntity>
    {
        /// <summary>
        ///     Сообщение в случае не соответствия спецификации.
        /// </summary>
        private readonly string _failureMessage;

        /// <summary>
        ///     Конструктор для инициализации объекта <see cref="SpecificationBase{TEntity}" />.
        /// </summary>
        /// <param name="criteria">Функция для проведения проверки.</param>
        /// <param name="failureMessage">Сообщение в случае не соответствия спецификации.</param>
        protected SpecificationBase(Expression<Func<TEntity, bool>> criteria, string failureMessage)
        {
            if (criteria.ReturnFailure())
                throw new ArgumentNullException(nameof(criteria));

            Expression = criteria;
            _failureMessage = failureMessage;
        }

        /// <summary>
        ///     Проверка пригодности объекта для удовлетворения потребности или достижения цели.
        /// </summary>
        /// <param name="candidate">Проверяемый объект.</param>
        /// <returns>
        ///     <see langword="true" /> - Объект <see cref="TEntity" /> прошёл проверку.
        ///     <see langword="false" /> - Объект <see cref="TEntity" /> не прошёл проверку.
        /// </returns>
        public Result IsSatisfiedBy(TEntity candidate)
        {
            if (candidate.ReturnFailure())
                throw new ArgumentNullException(nameof(candidate));

            TEntity[] candidates =
            {
                candidate
            };
            //todo Что за хрень я тут написал? Зачем оно так? Что оно должно делать?
            return candidates.AsQueryable().Any() ? Result.Done() : Result.Fail(_failureMessage);
        }

        /// <summary>
        ///     Формирование функции для проведения проверки пригодности объекта для удовлетворения
        ///     потребности или достижения цели.
        /// </summary>
        /// <returns>Функция для проверки.</returns>
        public Expression<Func<TEntity, bool>> Expression { get; }
    }
}
