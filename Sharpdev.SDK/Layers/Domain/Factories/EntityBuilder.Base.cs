using Sharpdev.SDK.Layers.Domain.Entities;

namespace Sharpdev.SDK.Layers.Domain.Factories
{
    /// <summary>
    ///     Строитель для объектов.
    /// </summary>
    /// <typeparam name="TEntity">Тип собираемого объекта.</typeparam>
    /// <remarks>
    ///     Отделяет  конструирование сложного объекта от его представления так, что  в  результате
    ///     одного и того  же  процесса  конструирования  могут  получаться  разные  представления.
    /// </remarks>
    public abstract class EntityBuilder<TEntity> : IEntityBuilder<TEntity>
        where TEntity : IEntity<TEntity>
    {
        /// <summary>
        ///     Идентификатор объекта <see cref="TEntity" />.
        /// </summary>
        public IIdentifier<TEntity> Identifier { get; private set; }

        /// <summary>
        ///     Идентификатор объекта <see cref="TEntity" />.
        /// </summary>
        public int Version { get; private set; }

        /// <summary>
        ///     Фиксация значения идентификатора объекта <see cref="TEntity" />.
        /// </summary>
        /// <param name="entityIdentifier">Значение идентификатора.</param>
        /// <returns>Строитель для объекта <see cref="TEntity" />.</returns>
        public IEntityBuilder<TEntity> SetIdentifier(IIdentifier<TEntity> entityIdentifier)
        {
            Identifier = entityIdentifier;
            return this;
        }

        /// <summary>
        ///     Фиксация версии объекта <see cref="TEntity" />.
        /// </summary>
        /// <param name="entityVersion">Версия объекта.</param>
        /// <returns>Строитель для объекта <see cref="TEntity" />.</returns>
        public IEntityBuilder<TEntity> SetVersion(int entityVersion)
        {
            Version = entityVersion;

            return this;
        }
    }
}
