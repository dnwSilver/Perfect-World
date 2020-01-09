using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FluentAssertions;

using NUnit.Framework;

using Prosolve.Services.Identification;
using Prosolve.Services.Identification.Users;
using Prosolve.Services.Identification.Users.DataSources;
using Prosolve.Services.Identification.Users.Factories;

using Sharpdev.SDK.DataSources.Databases;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Testing;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;
using Sharpdev.SDK.Types.PhoneNumbers;

namespace Prosolve.Services.Identity.UnitTest.Users.Cases
{
    [TestFixture]
    [Category(nameof(IUserAggregate))]
    [Category(Constant.Negative)]
    [Parallelizable(ParallelScope.All)]
    public class WhenCreateUserNegative
    {
        // todo надо сделать StartUp и вынести его в базовый класс для тестов.
        /// <summary>
        ///     Подготовка сервиса для тестирования. Создание всех необходимых объектов и заполнение
        ///     данными виртуальное хранилище.
        /// </summary>
        /// <param name="userDataModels"> Данные находящиеся в виртуальном хранилище. </param>
        /// <returns> Сервис готовый для тестов. </returns>
        private UserService AllocateUserService(out IEnumerable<UserDataModel> userDataModels)
        {
            userDataModels = Create.UserDataModel.CountOf(10).Please();

            var identificationContext = Create.IdentificationContext.With(userDataModels).PorFavor();

            var integrationBus = Create.IntegrationBus.PorFavor();
            var unitOfWork = new DatabaseUnitOfWork<IdentificationContext>(identificationContext);
            var userFactory = new UserFactory();

            var userRepository = new UserFrameworkRepository(userFactory, IdentificationConfiguration.Mapper, identificationContext);

            var userService = new UserService(unitOfWork, integrationBus, userFactory, userRepository);

            return userService;
        }

        [Test]
        public void WhenCreateUser_WithExistsEmailAddress_ResultShouldBeFailure()
        {
            // Act:
            var userService = AllocateUserService(out var userDataModels);

            var emailAddress = new ConfirmedBase<EmailAddress>(userDataModels.First().EmailAddress);

            var fullName = new FullName("Петров", "Александр", "Андреевич");

            var newUserBuilder = Create.UserBuilder
                                        .With(fullName)
                                        .With(emailAddress)
                                        .PorFavor();

            // Arrange:
            Func<Task> function = async () => await userService.CreateUserAsync(newUserBuilder);

            // Assert:
            function.Should()
                    .Throw<DataSourceInnerException>()
                    .WithMessage("Вот так беда. Ничего не получилось.");
        }

        [Test]
        public void WhenCreateUser_WithExistsPhoneNumber_ResultShouldBeFailure()
        {
            // Act:
            var userService = AllocateUserService(out var userDataModels);

            var phoneNumber = new ConfirmedBase<PhoneNumber>(userDataModels.First()
                                                                           .PhoneNumber);

            var fullName = new FullName("Петров", "Александр", "Андреевич");

            var newUserBuilder = Create.UserBuilder
                                        .With(fullName)
                                        .With(phoneNumber)
                                        .PorFavor();

            // Arrange:
            Func<Task> function = async () => await userService.CreateUserAsync(newUserBuilder);

            // Assert:
            function.Should()
                    .Throw<DataSourceInnerException>()
                    .WithMessage("Вот так беда. Ничего не получилось.");
        }

        [Test]
        public void WhenCreateUser_WithoutContactInformation_ResultShouldBeFailure()
        {
            // Act:
            var userService = AllocateUserService(out var userDataModels);

            var emailAddress = new ConfirmedBase<EmailAddress>(userDataModels.First()
                                                                             .EmailAddress);

            var fullName = new FullName("Петров", "Александр", "Андреевич");

            var newUserBuilder = Create.UserBuilder
                                        .With(fullName)
                                        .With(emailAddress)
                                        .PorFavor();

            // Arrange:
            Func<Task> function = async () => await userService.CreateUserAsync(newUserBuilder);

            // Assert:
            function.Should()
                    .Throw<DataSourceInnerException>()
                    .WithMessage("Вот так беда. Ничего не получилось.");
        }

        [Test]
        public void WhenCreateUser_WithoutFullName_ResultShouldBeFailure()
        {
            // Act:
            var userService = AllocateUserService(out var userDataModels);

            var emailAddress = new ConfirmedBase<EmailAddress>(userDataModels.First()
                                                                             .EmailAddress);

            var newUserBuilder = Create.UserBuilder
                                        .With(emailAddress)
                                        .PorFavor();

            // Arrange:
            Func<Task> function = async () => await userService.CreateUserAsync(newUserBuilder);

            // Assert:
            function.Should()
                    .Throw<DataSourceInnerException>()
                    .WithMessage("Вот так беда. Ничего не получилось.");
        }
    }
}
