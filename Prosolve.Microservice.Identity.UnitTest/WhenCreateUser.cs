using System;

using FluentAssertions;

using NUnit.Framework;

namespace Prosolve.MicroService.Identity.UnitTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class WhenCreateUser
    {
        [Test]
        public void WhenCreateUser_ResultShouldBeFailure()
        {
            // Act
            var identityService = Create.IdentityService().Please();
            var user = Create.User().Please();
            var users = new[]
            {
                user
            };

            // Arrange
            var searchResult = identityService.CreateUser(users);

            // Assert
            searchResult.Failure.Should().BeTrue(" we are create new user");
        }

        [Test]
        public void WhenCreateUser_ResultShouldBeTrue()
        {
            // Act
            var identityService = Create.IdentityService().Please();
            var emailAddress = Create.EmailAddress("test@test.ru")
                                     .Confirmed(new DateTime(2019, 6,25))
                                     .Please();
            var user = Create.User().With(emailAddress).Please();

            // Arrange
            var searchResult = identityService.CreateUser(new[]
            {
                user
            });

            // Assert
            searchResult.Success.Should().BeTrue(" we are create new user");
        }
    }
}
