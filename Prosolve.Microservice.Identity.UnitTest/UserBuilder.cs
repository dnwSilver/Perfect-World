using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Layers.Kernel;
using Sharpdev.SDK.Testing;
using Sharpdev.SDK.Types.EmailAddresses;

namespace Prosolve.MicroService.Identity.UnitTest
{
    public class UserBuilder : ITestBuilder<IUser>
    {
        private IUser _user;

        public IUser Please()
        {
            return _user;
        }

        public UserBuilder With(int userId)
        {
            return this;
        }

        public UserBuilder With(IConfirmed<EmailAddress> contactEmail)
        {
            return this;
        }

        public UserBuilder With(string roleId)
        {
            return this;
        }
    }
}
