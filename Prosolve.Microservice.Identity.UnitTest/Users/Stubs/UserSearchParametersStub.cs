using System.Collections.Generic;

using Moq;

using Prosolve.MicroService.Identity.Entities.Users;

using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Testing;

namespace Prosolve.MicroService.Identity.UnitTest.Users.Stubs
{
    public class UserSearchParametersStub : ITestStub<IUserSearchParameters>
    {
        private readonly IUserSearchParameters _userSearchParameters = new Mock<IUserSearchParameters>().Object;

        public IUserSearchParameters Please()
        {
            return _userSearchParameters;
        }

        public UserSearchParametersStub With(IIdentifier<IUser> userId)
        {
            return this;
        }
    }
}
