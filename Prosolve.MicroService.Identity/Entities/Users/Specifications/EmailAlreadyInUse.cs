using Sharpdev.SDK.Layers.Domain;

namespace Prosolve.MicroService.Identity.Entities.Users.Specifications
{
    /// <summary>
    ///     Проверка адреса электронной почты на привязку к пользователю.
    /// </summary>
    internal class EmailAlreadyInUse : SpecificationBase<IUser>
    {
        public EmailAlreadyInUse(IUser candidate)
            : base(x => x.ContactEmail.Value == candidate.ContactEmail)
        {
        }
    }
}
