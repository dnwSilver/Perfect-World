using System;
using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using NUnit.Framework;

using Prosolve.Services.Identification;
using Prosolve.Services.Identification.Entities.Users;
using Prosolve.Services.Identification.Entities.Users.DataSources;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Extensions;
using Sharpdev.SDK.Testing;
using Sharpdev.SDK.Types.FullNames;

using UserRepository = Prosolve.Services.Identification.Entities.Users.DataSources.UserRepository;

namespace Prosolve.Services.Identity.UnitTest.Users.Cases
{
    [TestFixture]
    [Category(nameof(IUser))]
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
        private IIdentityService AllocateIdentityService(out IList<UserDataModel> userDataModels)
        {
            userDataModels = Create.UserDataModel.CountOf(10).Please();
            var identificationContext =
                Create.IdentificationContext.With(userDataModels).Please().First();
            var integrationBus = Create.IntegrationBus.Please().First();
            var unitOfWork = new IdentificationUnitOfWork(watcherContext);
            var userFactory = new UserFactory();
            var userRepository =
                new UserRepository(userFactory, IdentificationConfiguration.Mapper);
            var userService = new UserService(unitOfWork, integrationBus, userRepository);
            var identityService = new IdentityService(userRepository, integrationBus);

            return identityService;
        }

        [Test]
        public void WhenCreateUser_WithNotExistsEmailAddress_ResultShouldBeTrue()
        {
            // Act:
            var userService = this.AllocateIdentityService(out var _);
            var newUserBuilders = new UserBuilder
                {
                    FullName = new FullName("Петров", "Александр", "Андреевич"),
                    ContactEmailAddress = Create.EmailAddress("TestUser@mail.ru").Please().First(),
                    Identifier = Identifier<IUser>.New(),
                    Version = 1
                }.Yield()
                 .ToArray();

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
