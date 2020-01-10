using System;
using System.Linq;
using System.Threading.Tasks;

using FluentAssertions;

using NUnit.Framework;

using Prosolve.Services.Identification.Users;

using Sharpdev.SDK.DataSources.Databases;
using Sharpdev.SDK.Testing;
using Sharpdev.SDK.Types.FullNames;

namespace Prosolve.Services.Identity.UnitTest.Users.Cases
{
    [TestFixture]
    [Category(nameof(IUserAggregate))]
    [Category(Constant.Negative)]
    [Parallelizable(ParallelScope.All)]
    internal class WhenCreateUserNegative : UserServiceTestBase
    {
        [Test]
        public void WhenCreateUser_WithExistsEmailAddress_ResultShouldBeFailure()
        {
            // Act:
            var emailAddress = UserDataModels.First().EmailAddress;

            var fullName = new FullName("Петров", "Александр", "Андреевич");

            var newUserBuilder = Create.UserBuilder
                                        //.With(fullName)
                                        //.With(emailAddress)
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
            var phoneNumber = UserDataModels.First().PhoneNumber;
            var fullName = new FullName("Петров", "Александр", "Андреевич");

            var newUserBuilder = Create.UserBuilder
                                        //.With(fullName)
                                        //.With(phoneNumber)
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
            var emailAddress = UserDataModels.First().EmailAddress;

            var fullName = Create.FullName.PorFavor;

            var newUserBuilder = Create.UserBuilder
                                       // .With(fullName)
                                       // .With(emailAddress)
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
            var emailAddress = UserDataModels.First().EmailAddress;

            var newUserBuilder = Create.UserBuilder
                                        //.With(emailAddress)
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
