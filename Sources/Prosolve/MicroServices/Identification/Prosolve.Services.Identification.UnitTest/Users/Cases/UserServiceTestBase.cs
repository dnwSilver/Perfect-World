using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

using Prosolve.Services.Identification;
using Prosolve.Services.Identification.Users;
using Prosolve.Services.Identification.Users.DataSources;
using Prosolve.Services.Identification.Users.Factories;
using Prosolve.Services.Identity.UnitTest.Users.Mocks;

using Sharpdev.SDK.DataSources.Databases;

namespace Prosolve.Services.Identity.UnitTest.Users.Cases
{
    [TestFixture]
    internal abstract class UserServiceTestBase
    {
        /// <summary>
        ///     Сервис готовый для тестов.
        /// </summary>
        protected UserService UserService;

        /// <summary>
        ///     Данные находящиеся в виртуальном хранилище.
        /// </summary>
        protected IEnumerable<UserDataModel> UserDataModels;
        
        public UserServiceTestBase()
        {
            var services = new ServiceCollection();
            services.AddDbContext<IdentificationContext>();
            
            // var serviceProvider = services.BuildServiceProvider();
            //
            // matchRepository = serviceProvider.GetService<IMatchRepository>();
        }

        /// <summary>
        ///     Подготовка сервиса для тестирования. Создание всех необходимых объектов и заполнение
        ///     данными виртуальное хранилище.
        /// </summary>
        [SetUp]
        protected void SetUp()
        {
            var integrationBus = Prepare.IntegrationBus.PorFavor;

            UserDataModels = Prepare.UserDataModel.CountOf(10).Please;
            var identificationContext = Prepare.IdentificationContext.With(UserDataModels).PorFavor;
            var unitOfWork = new DatabaseUnitOfWork<IdentificationContext>(identificationContext);
            var userFactory = new UserFactory();
            var userRepository = new UserFrameworkRepository(userFactory, IdentificationConfiguration.Mapper, identificationContext);
            UserService = new UserService(unitOfWork, integrationBus, userFactory, userRepository);
        }
    }
}
