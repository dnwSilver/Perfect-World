﻿namespace Sharpdev.SDK.Domain.Entities
{
    /// <summary>
    ///     Объект точно содержит уникальный идентификатор.
    /// </summary>
    /// <typeparam name="TOwner">Владелец идентификатора.</typeparam>
    public interface IHasIdentifier<TOwner>
        where TOwner : class, IEntity<TOwner>
    {
        /// <summary>
        ///     Уникальный идентификатор.
        /// </summary>
        IIdentifier<TOwner> Id { get; }
    }
}
