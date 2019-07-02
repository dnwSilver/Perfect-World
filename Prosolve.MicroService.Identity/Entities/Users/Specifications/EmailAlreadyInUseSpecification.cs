using System.Linq;

using Sharpdev.SDK.Layers.Domain;

namespace Prosolve.MicroService.Identity.Entities.Users.Specifications
{
    /// <summary>
    ///     Проверка адреса электронной почты на привязку к пользователю.
    /// </summary>
    internal class EmailAlreadyInUseSpecification : ISpecification<IUser>
    {
        private readonly IUser[] _users;

        public EmailAlreadyInUseSpecification(IUser[] users)
        {
            _users = users;
        }

        /// <summary>
        ///     Проверка пригодности объекта для удовлетворения потребности или достижения цели.
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public bool IsSatisfiedBy(IUser candidate)
        {
            return _users.Any(x => x.ContactEmail.Value == candidate.ContactEmail);
        }
    }
}
