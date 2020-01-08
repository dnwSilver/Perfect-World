using System.Collections.Generic;

using FluentAssertions;

using NUnit.Framework;

using Prosolve.Services.Identification;
using Prosolve.Services.Identification.Users;
using Prosolve.Services.Identification.Users.DataSources;
using Prosolve.Services.Identification.Users.Factories;

using Sharpdev.SDK.DataSources.Databases;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Testing;
using Sharpdev.SDK.Types.FullNames;
using Sharpdev.SDK.Types.PhoneNumbers;

namespace Prosolve.Services.Identity.UnitTest.Users.Cases
{
    [TestFixture]
    [Category(nameof(IUserAggregate))]
    [Category(Constant.Positive)]
    [Parallelizable(ParallelScope.All)]
    public class WhenCreateUserPositive
    {
        /// <summary>
        ///     Подготовка сервиса для тестирования. Создание всех необходимых объектов и заполнение
        ///     данными виртуальное хранилище.
        /// </summary>
        /// <param name="userDataModels">Данные находящиеся в виртуальном хранилище.</param>
        /// <returns>Сервис готовый для тестов.</returns>
        private UserService AllocateIdentityService(
            out IEnumerable<UserDataModel> userDataModels)
        {
            userDataModels = Create.UserDataModel.CountOf(2).Please();
            var identificationContext =
                Create.IdentificationContext.With(userDataModels).PorFavor();
            var integrationBus = Create.IntegrationBus.PorFavor();
            var unitOfWork = new DatabaseUnitOfWork<IdentificationContext>(identificationContext);
            var userFactory = new UserFactory();
            var userRepository =
                new UserFrameworkRepository(userFactory, IdentificationConfiguration.Mapper);
            var userService = new UserService(unitOfWork, integrationBus, userFactory, userRepository);

            return userService;
        }

        [Test]
        public void WhenCreateUser_WithNotExistsEmailAddress_ResultShouldBeTrue()
        {
            // Act:
            var userService = AllocateIdentityService(out var _);
            var emailAddress = Create.EmailAddress("TestUser@mail.ru").PorFavor();
            var fullName = new FullName("Петров", "Александр", "Андреевич");
            var newUserBuilder = Create.UserBuilder
                                        .With(fullName)
                                        .With(emailAddress)
                                        .PorFavor();

            // Arrange:
            var result = userService.CreateUserAsync(newUserBuilder).Result;

            // Assert:
            result.Success.Should().BeTrue();
        }

        [Test]
        public void WhenCreateUser_WithNotExistsPhoneNumber_ResultShouldBeTrue()
        { 
            // Act:
            var userService = AllocateIdentityService(out var _);
            var phoneNumber = new ConfirmedBase<PhoneNumber>($"+7{10000000:D10}");
            var fullName = new FullName("Петров", "Александр", "Андреевич");
            var newUserBuilder = Create.UserBuilder
                                        .With(fullName)
                                        .With(phoneNumber)
                                        .PorFavor();

            // Arrange:
            var result = userService.CreateUserAsync(newUserBuilder).Result;

            // Assert:
            result.Success.Should().BeTrue();
        }
    }
}
