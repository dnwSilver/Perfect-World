namespace Sharpdev.SDK.Layers.Domain.Entities
{
    /// <summary>
    ///     Объект точно содержит уникальный идентификатор.
    /// </summary>
    /// <typeparam name="TOwner">Владелец идентификатора.</typeparam>
    public interface IHasIdentifier<TOwner>
        where TOwner : IEntity<TOwner>
    {
        /// <summary>
        ///     Уникальный идентификатор.
        /// </summary>
        IIdentifier<TOwner> Id { get; }
    }
}
