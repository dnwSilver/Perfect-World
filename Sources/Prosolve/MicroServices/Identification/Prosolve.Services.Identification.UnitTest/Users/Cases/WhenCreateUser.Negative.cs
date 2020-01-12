using System;
using System.Linq;
using System.Threading.Tasks;

using FluentAssertions;

using NUnit.Framework;

using Prosolve.Services.Identification.Users;
using Prosolve.Services.Identification.Users.Factories;
using Prosolve.Services.Identity.UnitTest.Users.ObjectGenerators;

using Sharpdev.SDK.DataSources.Databases;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Testing;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.PhoneNumbers;

namespace Prosolve.Services.Identity.UnitTest.Users.Cases
{
    [Category(nameof(IUserAggregate))]
    [Category(Constant.Negative)]
    internal class WhenCreateUserNegative : UserServiceTestBase
    {
        [Test]
        public void WhenCreateUser_WithExistsEmailAddress_ResultShouldBeFailure()
        {
            // Act:
            var emailAddressAlreadyInUse = IdentificationContext.Users.First().EmailAddress;

            var newUserBuilder = Prepare.UserBuilder
                                        .With(nameof(IUserBuilder.ContactEmailAddress), emailAddressAlreadyInUse)
                                        .PorFavor;

            // Arrange:
            Func<Task> function = async () => await UserService.CreateAsync(newUserBuilder);
            
            // Assert:
            function.Should()
                    .Throw<DataSourceInnerException>()
                    .WithMessage("Вот так беда. Ничего не получилось.");
        }

        [Test]
        public void WhenCreateUser_WithExistsPhoneNumber_ResultShouldBeFailure()
        {
            // Act:
            var phoneNumberAlreadyInUse = UserDataModels.First().PhoneNumber;
            var newUserBuilder = Prepare.UserBuilder
                                        .With(nameof(IUserBuilder.ContactPhoneNumber), phoneNumberAlreadyInUse)
                                        .PorFavor;

            // Arrange:
            Func<Task> function = async () => await UserService.CreateAsync(newUserBuilder);

            // Assert:
            function.Should()
                    .Throw<DataSourceInnerException>()
                    .WithMessage("Вот так беда. Ничего не получилось.");
        }

        [Test]
        public void WhenCreateUser_WithoutContactInformation_ResultShouldBeFailure()
        {
            // Act:
            var newUserBuilder = Prepare.UserBuilder
                                        .WithOut(nameof(IUserBuilder.ContactPhoneNumber))
                                        .WithOut(nameof(IUserBuilder.ContactEmailAddress))
                                        .PorFavor;

            // Arrange:
            Func<Task> function = async () => await UserService.CreateAsync(newUserBuilder);

            // Assert:
            function.Should()
                    .Throw<DataSourceInnerException>()
                    .WithMessage("Вот так беда. Ничего не получилось.");
        }

        [Test]
        public void WhenCreateUser_WithoutFullName_ResultShouldBeFailure()
        {
            // Act:
            var newUserBuilder = Prepare.UserBuilder
                                        .WithOut(nameof(IUserBuilder.FullName))
                                        .PorFavor;

            // Arrange:
            Func<Task> function = async () => await UserService.CreateAsync(newUserBuilder);

            // Assert:
            function.Should()
                    .Throw<DataSourceInnerException>()
                    .WithMessage("Вот так беда. Ничего не получилось.");
        }
    }
}
