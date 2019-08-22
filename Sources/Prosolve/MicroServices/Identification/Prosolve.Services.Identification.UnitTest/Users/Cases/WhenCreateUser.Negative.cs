using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using NUnit.Framework;

using Prosolve.Services.Identification;
using Prosolve.Services.Identification.Entities.Users;
using Prosolve.Services.Identification.Entities.Users.DataSources;

using Sharpdev.SDK.DataSources.Databases;
using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Extensions;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Testing;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;
using Sharpdev.SDK.Types.PhoneNumbers;

namespace Prosolve.Services.Identity.UnitTest.Users.Cases
{
    [TestFixture]
    [Category(nameof(IUserEntity))]
    [Category(Constant.Negative)]
    [Parallelizable(ParallelScope.All)]
    public class WhenRegistrationUserNegative
    {  /// <summary>
        ///     Подготовка сервиса для тестирования. Создание всех необходимых объектов и заполнение
        ///     данными виртуальное хранилище.
        /// </summary>
        /// <param name="userDataModels">Данные находящиеся в виртуальном хранилище.</param>
        /// <returns>Сервис готовый для тестов.</returns>
        private IIdentityService AllocateIdentityService(
            out IEnumerable<UserDataModel> userDataModels)
        {
            userDataModels = Create.UserDataModel.CountOf(10).Please();
            var identificationContext =
                Create.IdentificationContext.With(userDataModels).PorFavor();
            var integrationBus = Create.IntegrationBus.PorFavor();
            var unitOfWork = new DatabaseUnitOfWork<IdentificationContext>(identificationContext);
            var userFactory = new UserFactory();
            var userRepository =
                new UserRepository(userFactory, IdentificationConfiguration.Mapper);
            var identityService = new IdentityService(unitOfWork, integrationBus, userRepository);

            return identityService;
        }
        
        [Test]
        public void WhenRegistrationUser_WithExistsEmailAddress_ResultShouldBeFailure()
        {
            // Act:
            var userService = this.AllocateIdentityService(out var userDataModels);
            var emailAddress = new ConfirmedBase<EmailAddress>(userDataModels.First().EmailAddress);
            var fullName = new FullName("Петров", "Александр", "Андреевич");
            var newUserBuilders = Create.UserBuilder
                                        .With(fullName)
                                        .With(emailAddress)
                                        .With(Identifier<IUserEntity>.New())
                                        .PorFavor()
                                        .Yield()
                                        .ToArray();

            // Arrange:
            var result = userService.CreateUsers(newUserBuilders);

            // Assert:
            result.Success.Should().BeFalse();
        }

        [Test]
        public void WhenRegistrationUser_WithExistsPhoneNumber_ResultShouldBeFailure()
        { 
            // Act:
            var userService = this.AllocateIdentityService(out var userDataModels);
            var phoneNumber = new ConfirmedBase<PhoneNumber>(userDataModels.First().PhoneNumber);
            var fullName = new FullName("Петров", "Александр", "Андреевич");
            var newUserBuilders = Create.UserBuilder
                                        .With(fullName)
                                        .With(phoneNumber)
                                        .With(Identifier<IUserEntity>.New())
                                        .PorFavor()
                                        .Yield()
                                        .ToArray();

            // Arrange:
            var result = userService.CreateUsers(newUserBuilders);

            // Assert:
            result.Success.Should().BeFalse();
        }

        [Test]
        public void WhenRegistrationUser_WithoutContactInformation_ResultShouldBeFailure()
        { 
            // Act:
            var userService = this.AllocateIdentityService(out var userDataModels);
            var emailAddress = new ConfirmedBase<EmailAddress>(userDataModels.First().EmailAddress);
            var fullName = new FullName("Петров", "Александр", "Андреевич");
            var newUserBuilders = Create.UserBuilder
                                        .With(fullName)
                                        .With(emailAddress)
                                        .With(Identifier<IUserEntity>.New())
                                        .PorFavor()
                                        .Yield()
                                        .ToArray();

            // Arrange:
            var result = userService.CreateUsers(newUserBuilders);

            // Assert:
            result.Success.Should().BeFalse();
        }

        [Test]
        public void WhenRegistrationUser_WithoutFullName_ResultShouldBeFailure()
        { 
            // Act:
            var userService = this.AllocateIdentityService(out var userDataModels);
            var emailAddress = new ConfirmedBase<EmailAddress>(userDataModels.First().EmailAddress);
            var newUserBuilders = Create.UserBuilder
                                        .With(emailAddress)
                                        .With(Identifier<IUserEntity>.New())
                                        .PorFavor()
                                        .Yield()
                                        .ToArray();

            // Arrange:
            var result = userService.CreateUsers(newUserBuilders);

            // Assert:
            result.Success.Should().BeFalse();
        }
    }
}
