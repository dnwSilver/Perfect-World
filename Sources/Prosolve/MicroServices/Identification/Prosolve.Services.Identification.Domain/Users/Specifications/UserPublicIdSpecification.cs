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
        ///     Конструктор для инициализации объекта <see cref="SpecificationBase{TEntity}" />.
        /// </summary>
        /// <param name="publicIdentifier">Публичный идентификатор.</param>
        public UserPublicIdSpecification(Guid publicIdentifier)
                : base(Criteria(publicIdentifier), FailureMessage(publicIdentifier))
        {
        }

        /// <summary>
        ///     Сообщение в случае не соответствия спецификации.
        /// </summary>
        private static string FailureMessage(Guid publicIdentifier)
            => string.Format(UserResources.UserPublicIdSpecificationMessage, nameof(IUserAggregate), publicIdentifier);

        /// <summary>
        ///     Проверка соответствия идентификатору.
        /// </summary>
        private static Expression<Func<IUserAggregate, bool>> Criteria(Guid publicIdentifier)
            => x => x.Id.Public == publicIdentifier;
    }
}
