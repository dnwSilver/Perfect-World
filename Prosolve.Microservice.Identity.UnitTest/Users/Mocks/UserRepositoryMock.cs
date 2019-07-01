using System.Collections.Generic;

using Moq;

using Prosolve.MicroService.Identity.Entities.Users;

using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Layers.Domain.Factories;
using Sharpdev.SDK.Layers.Infrastructure.Repositories;
using Sharpdev.SDK.Testing;
using Sharpdev.SDK.Types.Results;

namespace Prosolve.MicroService.Identity.UnitTest.Users.Mocks
{
    /// <summary>
    ///     Фальшивка для репозитория. Данные будем хранить в памяти.
    /// </summary>
    public class UserRepositoryMock : ITestStub<IRepository<IUser>>
    {
        /// <summary>
        ///     Построение объекта <see cref="IRepository{IUser}" />.
        /// </summary>
        /// <returns>Экземпляр объекта <see cref="IRepository{IUser}" /></returns>
        public IRepository<IUser> Please()
        {
            var mock = new Mock<IRepository<IUser>>();

            return mock.Object;
        }
    }


}
