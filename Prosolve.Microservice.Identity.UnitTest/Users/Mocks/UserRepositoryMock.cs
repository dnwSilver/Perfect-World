using Prosolve.MicroService.Identity.Entities.Users;

using Sharpdev.SDK.Layers.Infrastructure.Repositories;
using Sharpdev.SDK.Testing;

namespace Prosolve.MicroService.Identity.UnitTest.Users.Mocks
{
    /// <summary>
    ///     Фальшивка для репозитория. Данные будем хранить в памяти.
    /// </summary>
    internal class UserRepositoryMock : RepositoryMock<IUser>, ITestStub<IRepository<IUser>>
    {
        /// <summary>
        ///     Фальшивый репозиторий для пользователей.
        /// </summary>
        private readonly IRepository<IUser> _userRepository = new UserRepositoryMock();

        /// <summary>
        ///     Построение объекта <see cref="IRepository{IUser}" />.
        /// </summary>
        /// <returns>Экземпляр объекта <see cref="IRepository{IUser}" /></returns>
        public IRepository<IUser> Please()
        {
            return _userRepository;
        }

        /// <summary>
        ///     Добавление пользователей в репозиторий.
        /// </summary>
        /// <param name="users">Набор новых пользователей.</param>
        /// <returns>Строитель для фальшивки объекта <see cref="IRepository{IUser}" />.</returns>
        internal UserRepositoryMock With(IUser[] users)
        {
            _userRepository.Create(users);

            return this;
        }

        /// <summary>
        ///     Добавление пользователя в репозиторий.
        /// </summary>
        /// <param name="user">Добавление пользователя.</param>
        /// <returns>Строитель для фальшивки объекта <see cref="IRepository{IUser}" />.</returns>
        internal UserRepositoryMock With(IUser user)
        {
            _userRepository.Create(new[]
            {
                user
            });

            return this;
        }
    }
}
