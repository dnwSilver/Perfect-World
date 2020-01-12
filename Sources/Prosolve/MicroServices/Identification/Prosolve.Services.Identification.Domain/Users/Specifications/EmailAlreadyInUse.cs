using System;
using System.Linq.Expressions;

using Sharpdev.SDK.Domain.Specifications;

namespace Prosolve.Services.Identification.Users.Specifications
{
    /// <summary>
    ///     Проверка адреса электронной почты на привязку к пользователю.
    /// </summary>
    internal sealed class EmailAlreadyInUse : SpecificationBase<IUserAggregate>
    {
        private readonly IUserAggregate _userAggregate;
        public EmailAlreadyInUse(IUserAggregate userAggregate)
        {
            userAggregate = _userAggregate;
        }

        /// <summary>
        ///     Сообщение в случае не соответствия спецификации.
        /// </summary>
        protected override string FailureMessage => "Что-то не так";

        public override Expression<Func<IUserAggregate, bool>> Criteria
            => x => x.ContactEmail != null &&
                    _userAggregate.ContactEmail != null &&
                    x.ContactEmail.Value == _userAggregate.ContactEmail;
    }
}
