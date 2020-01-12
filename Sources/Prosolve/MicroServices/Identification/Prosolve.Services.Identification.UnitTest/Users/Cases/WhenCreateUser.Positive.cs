using System;
using System.Threading.Tasks;

using FluentAssertions;

using NUnit.Framework;

using Prosolve.Services.Identification.Users;
using Prosolve.Services.Identification.Users.Factories;

using Sharpdev.SDK.Testing;

namespace Prosolve.Services.Identity.UnitTest.Users.Cases
{
    [Category(Constant.Positive)]
    [Category(nameof(IUserAggregate))]
    internal class WhenCreateUserPositive: UserServiceTestBase
    {
        [Test]
        public void WhenCreateUser_WithNotExistsEmailAddress_ExecuteWithoutThrow()
        {
            // Act:
            var newUserBuilder = Prepare.UserBuilder
                                        .With(nameof(IUserAggregate.ContactEmail), Prepare.EmailAddress.PorFavor)
                                        .PorFavor;

            // Arrange:
            Func<Task> function = async () => await UserService.CreateAsync(newUserBuilder);

            // Assert:
            function.Should().NotThrowAsync();
        }

        [Test]
        public void WhenCreateUser_WithNotExistsPhoneNumber_ExecuteWithoutThrow()
        { 
            // Act:
            var newUserBuilder = Prepare.UserBuilder
                                        .With(nameof(IUserBuilder), Prepare.PhoneNumber.PorFavor)
                                        .PorFavor;

            // Arrange:
            Func<Task> function = async () => await UserService.CreateAsync(newUserBuilder);

            // Assert:
            function.Should().NotThrowAsync();
        }
    }
}
