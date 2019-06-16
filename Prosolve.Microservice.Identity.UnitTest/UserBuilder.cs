using System;

using Sharpdev.SDK.Layers.Kernel;
using Sharpdev.SDK.Testing;
using Sharpdev.SDK.Types.EmailAddresses;

namespace Prosolve.MicroService.Identity.UnitTest
{
    public class UserBuilder : ITestBuilder<IUser>
    {
        private IUser _user;

        public UserBuilder WithContact(IConfirmed<EmailAddress> contactEmail)
        {
            return this;
        }

        public UserBuilder WithRole(string roleId)
        {
            return this;
        }

        public IUser Please()
        {
            return _user;
        }
    }
}
