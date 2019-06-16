using Sharpdev.SDK.Layers.Infrastructure.Integrations;

namespace Prosolve.MicroService.Identity
{
    /// <summary>
    ///     Событие миграции данных по созданному пользователю.
    /// </summary>
    public interface IUserCreateIntegrationEvent : IIntegrationEvent
    {
    }
}
