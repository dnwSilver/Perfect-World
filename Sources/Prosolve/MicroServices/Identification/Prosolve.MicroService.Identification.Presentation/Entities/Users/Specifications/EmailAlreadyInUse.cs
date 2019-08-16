using Sharpdev.SDK.Domain;

namespace Prosolve.MicroService.Identification.Entities.Users.Specifications
{
    /// <summary>
    ///     Проверка адреса электронной почты на привязку к пользователю.
    /// </summary>
    internal class EmailAlreadyInUse : SpecificationBase<IUser>
    {
        public EmailAlreadyInUse(IUser candidate)
            : base(x => x.ContactEmail.Value == candidate.ContactEmail,"Что-то не так")
        {
        }
    }
}
