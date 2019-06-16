using System.Collections.Generic;

using Moq;

using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Testing;

namespace Prosolve.MicroService.Identity.UnitTest
{
    public class UserSearchParametersBuilder : ITestBuilder<IUserSearchParameters>
    {
        private IUserSearchParameters _userSearchParameters = new Mock<IUserSearchParameters>().Object;

        public UserSearchParametersBuilder WithId(IIdentifier<IUser> userId)
        {
            _userSearchParameters.ByIdentifiers(new List<IIdentifier<IUser>>
            {
                userId
            });

            return this;
        }

        public IUserSearchParameters Please()
        {
            return _userSearchParameters;
        }
    }
}
