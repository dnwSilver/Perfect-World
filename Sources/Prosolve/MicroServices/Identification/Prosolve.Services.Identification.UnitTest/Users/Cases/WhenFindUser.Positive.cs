using System;
using System.Linq;
using System.Threading.Tasks;

using FluentAssertions;

using NUnit.Framework;

using Prosolve.Services.Identification.Users;

using Sharpdev.SDK.Testing;

namespace Prosolve.Services.Identity.UnitTest.Users.Cases
{
    [Category(Constant.Positive)]
    [Category(nameof(IUserAggregate))]
    internal class WhenFindUserPositive: UserServiceTestBase
    {
        [Test]
        public async Task WhenFindUser_ByPublicId_CountShouldBeOne()
        {
            // Act:
            var userAggregatePublicId = IdentificationContext.Users.First().PublicId;
            var specification = Prepare.UserPublicIdSpecification(userAggregatePublicId).PorFavor;

            // Arrange:
            var foundUsers = await UserService.FindAsync(specification);

            // Assert:
            foundUsers.Should().HaveCount(1);
        }

        [Test]
        public async Task WhenFindUser_ByPublicId_FoundUsersShouldBeZero()
        {
            // Act:
            var unknownUserAggregatePublicId = Guid.Empty;
            var specification = Prepare.UserPublicIdSpecification(unknownUserAggregatePublicId).PorFavor;

            // Arrange:
            var foundUsers = await UserService.FindAsync(specification);

            // Assert:
            foundUsers.Should().HaveCount(0);
        }
    }
}
