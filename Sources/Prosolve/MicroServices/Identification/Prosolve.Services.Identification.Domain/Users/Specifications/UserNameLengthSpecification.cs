using System;
using System.Linq.Expressions;

using Sharpdev.SDK.Domain.Specifications;

namespace Prosolve.Services.Identification.Users.Specifications
{
    /// <summary>
    ///     Спецификация на ограничение длины наименования процесса.
    /// </summary>
    public sealed class UserNameLengthSpecification: SpecificationBase<IUserAggregate>
    {
        /// <summary>
        ///     Максимальная длина наименования процесса.
        /// </summary>
        private const int MaxLength = 150; //todo Вынести в файл с ресурсами

        /// <summary>
        ///     Сообщение в случае не соответствия спецификации.
        /// </summary>
        private static readonly string FailureMessage =
                string.Format(UserResources.UserNameLengthSpecificationMessage, MaxLength);

        /// <summary>
        ///     Конструктор для инициализации объекта <see cref="SpecificationBase{TEntity}"/>.
        /// </summary>
        public UserNameLengthSpecification()
                : base(Criteria, FailureMessage)
        {
        }

        /// <summary>
        ///     Проверка наименования на длину.
        /// </summary>
        private new static Expression<Func<IUserAggregate, bool>> Criteria
            => x => x.FullName.GetFullName.Length <= MaxLength;
    }
}
