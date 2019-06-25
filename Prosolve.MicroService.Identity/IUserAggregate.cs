using Sharpdev.SDK.Layers.Domain;

namespace Prosolve.MicroService.Identity
{
    /// <summary>
    ///     Кластер доменных объектов, которые можно рассматривать как единое целое.
    ///     Кластер для управления пользователями.
    /// </summary>
    public interface IUserAggregate : IAggregate<IUser>
    {
    }
}
