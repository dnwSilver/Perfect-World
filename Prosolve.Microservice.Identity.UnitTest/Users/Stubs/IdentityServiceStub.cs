using System.Collections.Generic;

using Moq;

using Prosolve.MicroService.Identity.Entities.Users;

using Sharpdev.SDK.Layers.Infrastructure.Repositories;
using Sharpdev.SDK.Testing;

namespace Prosolve.MicroService.Identity.UnitTest.Users.Stubs
{
    /// <summary>
    ///     Строитель для создания сервиса для работы с пользователями.
    /// </summary>
    public class IdentityServiceStub : ITestStub<IIdentityService>
    {
        /// <summary>
        ///     Построение объекта <see cref="IIdentityService" />.
        /// </summary>
        /// <returns>Экземпляр объекта <see cref="IIdentityService" /></returns>
        public IIdentityService Please()
        {
            var repositoryStub = new Mock<IRepository<IUser>>();
            repositoryStub.Setup(x => x.Status).Returns(RepositoryStatus.Up);

            IReadOnlyCollection<IUser> users = new[]
            {
                Create.User().With(1).Please(),
                Create.User().With(2).Please(),
                Create.User().With(3).Please(),
                Create.User().With(4).Please(),
                Create.User().With(5).Please(),
                Create.User().With(6).Please(),
                Create.User().With(7).Please(),
                Create.User().With(8).Please(),
                Create.User().With(9).Please()
            };

            //repositoryStub.Setup(x => x.ReadAsync(It.IsAny<IUserSearchParameters>())).ReturnsAsync(users);

            return new IdentityService(repositoryStub.Object);
        }
    }
}
