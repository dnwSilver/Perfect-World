using System;
using System.Linq.Expressions;

using Sharpdev.SDK.Domain.Specifications;

namespace Prosolve.Services.Identification.Users.Specifications
{
    /// <summary>
    ///     Спецификация на ограничение длины наименования процесса.
    /// </summary>
    internal sealed class UserFirstNameLengthSpecification: SpecificationBase<IUserAggregate>
    {
        /// <summary>
        ///     Максимальная длина наименования процесса.
        /// </summary>
        private const int MaxLength = 150; //todo Вынести в файл с ресурсами

        /// <summary>
        ///     Сообщение в случае не соответствия спецификации.
        /// </summary>
        protected override string FailureMessage
            => string.Format(UserResources.UserFirstNameLengthSpecificationMessage, MaxLength);

        /// <summary>
        ///     Проверка наименования на длину.
        /// </summary>
        public override Expression<Func<IUserAggregate, bool>> Criteria
            => x => x.FullName.FirstName.Length <= MaxLength;
    }
}
