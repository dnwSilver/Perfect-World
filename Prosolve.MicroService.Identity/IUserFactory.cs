using Sharpdev.SDK.Layers.Domain.Factories;

namespace Prosolve.MicroService.Identity
{
    /// <summary>
    ///     Фабрика для объекта пользователя <see cref="IUser" />.
    /// </summary>
    public interface IUserFactory : IFactory<IUser>
    {
    }
}
