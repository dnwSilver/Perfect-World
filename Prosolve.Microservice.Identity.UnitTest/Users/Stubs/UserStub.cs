using System;

using Sharpdev.SDK.Layers.Kernel;
using Sharpdev.SDK.Testing;
using Sharpdev.SDK.Types.EmailAddresses;

namespace Prosolve.MicroService.Identity.UnitTest.Users.Stubs
{
    public class UserStub : ITestStub<IUser>
    {
        private readonly IUser _user;

        public IUser Please()
        {
            return _user;
        }

        public UserStub With(int userId)
        {
            throw new NotImplementedException();
        }

        public UserStub With(IConfirmed<EmailAddress> contactEmail)
        {
            throw new NotImplementedException();
        }

        public UserStub With(string roleId)
        {
            throw new NotImplementedException();
        }
    }
}
