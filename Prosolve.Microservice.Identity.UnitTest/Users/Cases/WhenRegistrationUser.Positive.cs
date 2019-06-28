using System;

using FluentAssertions;

using NUnit.Framework;

namespace Prosolve.MicroService.Identity.UnitTest.Users.Cases
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public partial class WhenRegistrationUser
    {
        [Test]
        public void WhenRegistrationUser_WithEmailAddress_ResultShouldBeTrue()
        {
            // Act:
            var identityService = Create.IdentityService().Please();
            var emailAddress = Create.EmailAddress("test@test.ru").Please();
            var user = Create.User().With(emailAddress).Please();

            // Arrange:
            var searchResult = identityService.CreateUser(new[]
            {
                user
            });

            // Assert:
            searchResult.Success.Should().BeTrue(" we are create new user");
        }

        [Test]
        public void WhenRegistrationUser_WithPhoneNumber_ResultShouldBeTrue()
        {
            throw new NotImplementedException();
        }
    }
}
