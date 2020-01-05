using Sharpdev.SDK.Domain;

namespace Prosolve.Services.Identification.Users.Specifications
{
    /// <summary>
    ///     Проверка адреса электронной почты на привязку к пользователю.
    /// </summary>
    internal class EmailAlreadyInUse : SpecificationBase<IUserAggregate>
    {
        public EmailAlreadyInUse(IUserAggregate candidate)
            : base(x => x.ContactEmail != null &&
                        candidate.ContactEmail != null &&
                        x.ContactEmail.Value == candidate.ContactEmail,
                   "Что-то не так")
        {
        }
    }
}
