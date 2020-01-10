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
using Prosolve.Services.Identification.Users.Specifications;

using Sharpdev.SDK.DataSources.Databases;
using Sharpdev.SDK.Testing;

namespace Prosolve.Services.Identity.UnitTest.Users.Cases
{
    [TestFixture]
    [Category(nameof(UserService))]
    [Category(Constant.Positive)]
    [Parallelizable(ParallelScope.All)]
    public class WhenFindUserPositive
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
                    new UserFrameworkRepository(userFactory, IdentificationConfiguration.Mapper, identificationContext);
            var userService = new UserService(unitOfWork, integrationBus, userFactory, userRepository);

            return userService;
        }

        [Test]
        public async Task WhenFindProcess_ByPublicId_CountShouldBeOne()
        {
            // Act:
            var identityService = AllocateIdentityService(out var userDataModels);
            var specification = new UserPublicIdSpecification(userDataModels.First().PublicId);

            // Arrange:
            var foundUsers = await identityService.FindAsync(specification);

            // Assert:
            foundUsers.Should().HaveCount(1);
        }

        [Test]
        public async Task WhenFindProcess_ByPublicId_CountShouldBeZero()
        {
            // Act:
            var processService = AllocateIdentityService(out _);
            var specification = new UserPublicIdSpecification(Guid.NewGuid());

            // Arrange:
            var foundUsers = await processService.FindAsync(specification);

            // Assert:
            foundUsers.Should().HaveCount(0);
        }
    }
}
