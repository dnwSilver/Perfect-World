using System;
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
using Sharpdev.SDK.Testing;
using Sharpdev.SDK.Types.FullNames;

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
        private IIdentityService AllocateIdentityService(out IEnumerable<UserDataModel> userDataModels)
        {
            userDataModels = Create.UserDataModel.CountOf(10).Please();
            var identificationContext = Create.IdentificationContext.With(userDataModels).PorFavor();
            var integrationBus = Create.IntegrationBus.PorFavor();
            var unitOfWork = new DatabaseUnitOfWork<IdentificationContext>(identificationContext);
            var userFactory = new UserFactory();
            var userRepository = new UserRepository(userFactory, IdentificationConfiguration.Mapper);
            var identityService = new IdentityService(unitOfWork, integrationBus, userRepository);

            return identityService;
        }

        [Test]
        public void WhenCreateUser_WithNotExistsEmailAddress_ResultShouldBeTrue()
        {
            // Act:
            var userService = this.AllocateIdentityService(out var _);
            var emailAddress = Create.EmailAddress("TestUser@mail.ru").PorFavor();
            var fullName = new FullName("Петров", "Александр", "Андреевич");
            var newUserBuilder = new UserBuilder()
                                 .SetFullName(fullName)
                                 .SetContactEmailAddress(emailAddress)
                                 .SetIdentifier(Identifier<IUserEntity>.New())
                                 .SetVersion(1) as IUserBuilder;
            
            var newUserBuilders = newUserBuilder.Yield().ToArray();

            // Arrange:
            var result = userService.CreateUsers(newUserBuilders);

            // Assert:
            result.Success.Should().BeTrue();
        }

        [Test]
        public void WhenCreateUser_WithNotExistsPhoneNumber_ResultShouldBeTrue()
        {
            throw new NotImplementedException();
        }
    }
}
