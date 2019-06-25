using Sharpdev.SDK.Layers.Domain;

namespace Prosolve.MicroService.Identity
{
    /// <summary>
    ///     Проверка пароля пользователя на длину.
    /// </summary>
    public interface IUserPasswordLengthSpecification : ISpecification<IUser>
    {
    }
}
