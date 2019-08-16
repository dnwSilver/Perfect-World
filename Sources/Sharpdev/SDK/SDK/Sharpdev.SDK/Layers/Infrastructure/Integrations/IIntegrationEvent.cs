using System;

namespace Sharpdev.SDK.Layers.Infrastructure.Integrations
{
    /// <summary>
    ///     Событие миграции данных.
    /// </summary>
    public interface IIntegrationEvent
    {
        /// <summary>
        ///     Уникальный идентификатор события.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        ///     Дата события (UTC+0).
        /// </summary>
        DateTime CreationDate { get; }
    }
}
