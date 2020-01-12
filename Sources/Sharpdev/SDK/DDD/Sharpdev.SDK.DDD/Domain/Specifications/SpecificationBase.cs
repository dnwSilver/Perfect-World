using System;
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
        protected abstract string FailureMessage { get; }

        /// <summary>
        ///     Формирование функции для проведения проверки пригодности объекта для удовлетворения
        ///     потребности или достижения цели.
        /// </summary>
        /// <returns> Функция для проверки. </returns>
        public abstract Expression<Func<TEntity, bool>> Criteria { get; }
        
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
            if(!Criteria.Compile().Invoke(candidate))
                throw new SpecificationSatisfiesException(FailureMessage);
        }
    }
}
