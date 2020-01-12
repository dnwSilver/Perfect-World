using System;
using System.Linq;
using System.Threading.Tasks;

using FluentAssertions;

using NUnit.Framework;

using Prosolve.Services.Identification.Users.Specifications;

using Sharpdev.SDK.Testing;

namespace Prosolve.Services.Identity.UnitTest.Users.Cases
{
    [TestFixture]
    [Category(nameof(UserService))]
    [Category(Constant.Positive)]
    [Parallelizable(ParallelScope.All)]
    internal class WhenFindUserPositive: UserServiceTestBase
    {
        [Test]
        public async Task WhenFindUser_ByPublicId_CountShouldBeOne()
        {
            // Act:
            var specification = new UserPublicIdSpecification(IdentificationContext.Users.First().PublicId);

            // Arrange:
            var foundUsers = await UserService.FindAsync(specification);

            // Assert:
            foundUsers.Should().HaveCount(1);
        }

        [Test]
        public async Task WhenFindUser_ByPublicId_FoundUsersShouldBeZero()
        {
            // Act:
            var specification = new UserPublicIdSpecification(Guid.NewGuid());

            // Arrange:
            var foundUsers = await UserService.FindAsync(specification);

            // Assert:
            foundUsers.Should().HaveCount(0);
        }
    }
}
