using Sharpdev.SDK.Domain.Entities;

namespace Sharpdev.SDK.Domain.Factories
{
    /// <summary>
    ///     Строитель для объектов.
    /// </summary>
    /// <typeparam name="TEntity">Тип собираемого объекта.</typeparam>
    /// <typeparam name="TEntityBuilder">Строитель для объекта более высокого уровня.</typeparam>
    /// <remarks>
    ///     Отделяет  конструирование сложного объекта от его представления так, что  в  результате
    ///     одного и того  же  процесса  конструирования  могут  получаться  разные  представления.
    /// </remarks>
    public abstract class
        EntityBuilderBase<TEntity, TEntityBuilder> : IEntityBuilder<TEntity>
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
        ///     Фиксация значения для идентификатора объекта <see cref="TEntity" />.
        /// </summary>
        /// <param name="identifier">Идентификатор объекта <see cref="TEntity" />.</param>
        /// <returns>Строитель для <see cref="TEntity" />". /></returns>
        public IEntityBuilder<TEntity> SetIdentifier(IIdentifier<TEntity> identifier)
        {
            this.Identifier = identifier;

            return this;
        }

        /// <summary>
        ///     Фиксация версии для объекта <see cref="TEntity" />.
        /// </summary>
        /// <param name="version">Версия объекта.</param>
        /// <returns>Строитель для <see cref="TEntity" />". /></returns>
        public IEntityBuilder<TEntity> SetVersion(int version)
        {
            this.Version = version;

            return this;
        }
    }
}
