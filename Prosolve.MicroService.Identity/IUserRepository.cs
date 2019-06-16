using Sharpdev.SDK.Layers.Infrastructure.Repositories;

namespace Prosolve.MicroService.Identity
{
    /// <summary>
    ///     Репозиторий для пользователей <see cref="IUser" />.
    /// </summary>
    public interface IUserRepository : IRepository<IUser, IUserSearchParameters>
    {

    }
}
