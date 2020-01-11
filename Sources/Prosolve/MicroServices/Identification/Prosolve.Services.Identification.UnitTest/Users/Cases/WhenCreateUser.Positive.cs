using System;
using System.Threading.Tasks;

using FluentAssertions;

using NUnit.Framework;

using Prosolve.Services.Identification.Users;

using Sharpdev.SDK.Testing;
using Sharpdev.SDK.Types.FullNames;

namespace Prosolve.Services.Identity.UnitTest.Users.Cases
{
    [TestFixture]
    [Category(nameof(IUserAggregate))]
    [Category(Constant.Positive)]
    [Parallelizable(ParallelScope.All)]
    internal class WhenCreateUserPositive: UserServiceTestBase
    {
        [Test]
        public void WhenCreateUser_WithNotExistsEmailAddress_ExecuteWithoutThrow()
        {
            // Act:
            var emailAddress = Prepare.EmailAddress.PorFavor;
            var fullName = Prepare.FullName.PorFavor;
            var newUserBuilder = Prepare.UserBuilder
                                      // .SetFullName(fullName)
                                      // .SetContactEmailAddress(emailAddress)
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
            var phoneNumber = Prepare.PhoneNumber.PorFavor;
            var fullName = new FullName("Петров", "Александр", "Андреевич");
            var newUserBuilder = Prepare.UserBuilder
                                       // .With(fullName)
                                       // .With(phoneNumber)
                                        .PorFavor;

            // Arrange:
            Func<Task> function = async () => await UserService.CreateAsync(newUserBuilder);

            // Assert:

            function.Should().NotThrowAsync();
        }
    }
}
