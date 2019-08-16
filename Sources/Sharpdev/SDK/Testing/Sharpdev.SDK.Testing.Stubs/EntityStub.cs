using Sharpdev.SDK.Layers.Domain.Entities;

namespace Sharpdev.SDK.Testing.Stubs
{
    /// <summary>
    ///     Объект заглушка имитирует бизнес сущность.
    /// </summary>
    public abstract class StubEntity : Entity<StubEntity>
    {
        /// <summary>
        ///     Конструктор для объекта <see cref="StubEntity" />.
        /// </summary>
        /// <param name="identifier">Уникальный идентификатор объекта.</param>
        /// <param name="currentVersion">Версия объекта.</param>
        protected StubEntity(IIdentifier<StubEntity> identifier, int currentVersion)
            : base(identifier, currentVersion)
        {
        }
    }
}
