using System;
using System.Linq.Expressions;

using Sharpdev.SDK.Domain.Specifications;

namespace Prosolve.Services.Identification.Users.Specifications
{
    /// <summary>
    ///     Спецификация на соответствие идентификатору процесса.
    /// </summary>
    internal sealed class UserPublicIdSpecification: SpecificationBase<IUserAggregate>
    {
        /// <summary>
        /// Публичный уникальный идентификатор пользователя.
        /// </summary>
        private readonly Guid _publicIdentifier;

        /// <summary>
        ///     Конструктор для инициализации объекта <see cref="SpecificationBase{TEntity}" />.
        /// </summary>
        /// <param name="publicIdentifier">Публичный идентификатор.</param>
        public UserPublicIdSpecification(Guid publicIdentifier)
        {
            _publicIdentifier = publicIdentifier;
        }

        /// <summary>
        ///     Сообщение в случае не соответствия спецификации.
        /// </summary>
        protected override string FailureMessage
            => string.Format(UserResources.UserPublicIdSpecificationMessage, nameof(IUserAggregate), _publicIdentifier);

        /// <summary>
        ///     Проверка соответствия идентификатору.
        /// </summary>
        public override Expression<Func<IUserAggregate, bool>> Criteria
            => x => x.Id.Public == _publicIdentifier;
    }
}
