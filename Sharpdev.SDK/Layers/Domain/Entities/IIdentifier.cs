using System;

namespace Sharpdev.SDK.Layers.Domain.Entities
{
    /// <summary>
    ///     Идентификатор бизнес сущности. Состоит из трёх частей:  public,  private,
    ///     external.
    /// </summary>
    /// <typeparam name="TOwner">Владелец идентификатора.</typeparam>
    public interface IIdentifier<TOwner> : IEquatable<IIdentifier<TOwner>>
        where TOwner : IEntity<TOwner>
    {
        /// <summary>
        ///     Публичный идентификатор. Генерируется внутри сервиса.
        /// </summary>
        Guid Public { get; }

        /// <summary>
        ///     Приватный идентификатор. Генерируется внутри сервиса.
        /// </summary>
        int Private { get; }

        /// <summary>
        ///     Идентификатор внешней системы. Генерируется не в сервисе.
        /// </summary>
        string External { get; }

        /// <summary>
        ///     Проверка состояния приватного идентификатора.
        /// </summary>
        /// <returns>
        ///     True - постоянный идентификатор.
        ///     False - временный идентификатор.
        /// </returns>
        bool IsTransient();

        /// <summary>
        ///     Проверка наличия публичного идентификатора.
        /// </summary>
        /// <returns>
        ///     True - Идентификатор существует.
        ///     False - Идентификатор не существует.
        /// </returns>
        bool HasPublicIdentifier();

        /// <summary>
        ///     Проверка наличия внешнего идентификатора.
        /// </summary>
        /// <returns>
        ///     True - Идентификатор существует.
        ///     False - Идентификатор не существует.
        /// </returns>
        bool HasExternalIdentifier();
    }
}
