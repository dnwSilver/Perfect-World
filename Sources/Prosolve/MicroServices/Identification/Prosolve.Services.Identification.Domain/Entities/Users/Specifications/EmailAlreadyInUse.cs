using Sharpdev.SDK.Domain;

namespace Prosolve.Services.Identification.Entities.Users.Specifications
{
    /// <summary>
    ///     Проверка адреса электронной почты на привязку к пользователю.
    /// </summary>
    internal class EmailAlreadyInUse : SpecificationBase<IUserEntity>
    {
        public EmailAlreadyInUse(IUserEntity candidate)
            : base(x => x.ContactEmail != null &&
                        candidate.ContactEmail != null &&
                        x.ContactEmail.Value == candidate.ContactEmail,
                   "Что-то не так")
        {
        }
    }
}
