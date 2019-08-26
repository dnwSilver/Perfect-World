using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using NUnit.Framework;

using Prosolve.Services.Identification;
using Prosolve.Services.Identification.Users;
using Prosolve.Services.Identification.Users.DataSources;
using Prosolve.Services.Identification.Users.Factories;

using Sharpdev.SDK.DataSources.Databases;
using Sharpdev.SDK.Extensions;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Testing;
using Sharpdev.SDK.Types.FullNames;
using Sharpdev.SDK.Types.PhoneNumbers;

namespace Prosolve.Services.Identity.UnitTest.Users.Cases
{
    [TestFixture]
    [Category(nameof(IUserEntity))]
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
                new UserRepository(userFactory, IdentificationConfiguration.Mapper);
            var userService = new UserService(unitOfWork, integrationBus, userRepository);

            return userService;
        }

        [Test]
        public void WhenCreateUser_WithNotExistsEmailAddress_ResultShouldBeTrue()
        {
            // Act:
            var userService = this.AllocateIdentityService(out var _);
            var emailAddress = Create.EmailAddress("TestUser@mail.ru").PorFavor();
            var fullName = new FullName("Петров", "Александр", "Андреевич");
            var newUserBuilders = Create.UserBuilder
                                        .With(fullName)
                                        .With(emailAddress)
                                        .PorFavor()
                                        .Yield()
                                        .ToArray();

            // Arrange:
            var result = userService.CreateUsers(newUserBuilders);

            // Assert:
            result.Success.Should().BeTrue();
        }

        [Test]
        public void WhenCreateUser_WithNotExistsPhoneNumber_ResultShouldBeTrue()
        { 
            // Act:
            var userService = this.AllocateIdentityService(out var _);
            var phoneNumber = new ConfirmedBase<PhoneNumber>($"+7{10000000:D10}");
            var fullName = new FullName("Петров", "Александр", "Андреевич");
            var newUserBuilders = Create.UserBuilder
                                        .With(fullName)
                                        .With(phoneNumber)
                                        .PorFavor()
                                        .Yield()
                                        .ToArray();

            // Arrange:
            var result = userService.CreateUsers(newUserBuilders);

            // Assert:
            result.Success.Should().BeTrue();
        }
    }
}
