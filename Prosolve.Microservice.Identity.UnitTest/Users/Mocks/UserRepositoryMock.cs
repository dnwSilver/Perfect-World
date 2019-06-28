using Moq;

using Prosolve.MicroService.Identity.Entities.Users;

using Sharpdev.SDK.Layers.Infrastructure.Repositories;

namespace Prosolve.MicroService.Identity.UnitTest.Users.Mocks
{
    public class UserRepositoryMock
    {
        public IRepository<IUser> Please()
        {
            var mock = new Mock<IRepository<IUser>>();

            return mock.Object;
        }
    }
}
