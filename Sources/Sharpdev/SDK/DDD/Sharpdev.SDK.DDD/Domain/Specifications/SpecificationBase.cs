using System;
using System.Linq;
using System.Linq.Expressions;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Extensions;

namespace Sharpdev.SDK.Domain.Specifications
{
    /// <summary>
    ///     Спецификация  -  это  предикат,  который  определяет,  удовлетворяет  объект  некоторым
    ///     критериям или нет.
    /// </summary>
    /// <typeparam name="TEntity"> Тип объекта для которого предназначена проверка. </typeparam>
    public abstract class SpecificationBase<TEntity>: ISpecification<TEntity>
            where TEntity: class, IEntity<TEntity>
    {
        /// <summary>
        ///     Сообщение в случае не соответствия спецификации.
        /// </summary>
        private readonly string _failureMessage;

        /// <summary>
        ///     Формирование функции для проведения проверки пригодности объекта для удовлетворения
        ///     потребности или достижения цели.
        /// </summary>
        /// <returns> Функция для проверки. </returns>
        public Expression<Func<TEntity, bool>> Criteria { get; }

        /// <summary>
        ///     Конструктор для инициализации объекта <see cref="SpecificationBase{TEntity}"/>.
        /// </summary>
        /// <param name="criteria"> Функция для проведения проверки. </param>
        /// <param name="failureMessage"> Сообщение в случае не соответствия спецификации. </param>
        protected SpecificationBase(Expression<Func<TEntity, bool>> criteria, string failureMessage)
        {
            if (criteria.ReturnFailure())
                throw new ArgumentNullException(nameof(criteria));

            Criteria = criteria;
            _failureMessage = failureMessage;
        }

        /// <summary>
        ///     Проверка пригодности объекта для удовлетворения потребности или достижения цели.
        /// </summary>
        /// <param name="candidate"> Проверяемый объект. </param>
        /// <returns>
        ///     <see langword="true"/> - Объект <see cref="TEntity"/> прошёл проверку.
        ///     <see langword="false"/> - Объект <see cref="TEntity"/> не прошёл проверку.
        /// </returns>
        /// <exception cref="SpecificationSatisfiesException" />
        /// <exception cref="ArgumentException" />
        public void Satisfies(TEntity candidate)
        {
            if (candidate.ReturnFailure())
                throw new ArgumentNullException(nameof(candidate));

            //todo Надо проверить всё то и написать тесты. Возможно есть способы написать красивее.
            if(candidate.Yield().AsQueryable().Where(Criteria).Empty())
                throw new SpecificationSatisfiesException(_failureMessage);
        }
    }
}
