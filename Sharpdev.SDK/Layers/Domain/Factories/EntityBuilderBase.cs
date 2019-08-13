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
    public abstract class EntityBuilderBase<TEntity> : IEntityBuilder<TEntity>
        where TEntity : IEntity<TEntity>
    {
        /// <summary>
        ///     Идентификатор объекта <see cref="TEntity" />.
        /// </summary>
        public IIdentifier<TEntity> Identifier { get;  set; }

        /// <summary>
        ///     Идентификатор объекта <see cref="TEntity" />.
        /// </summary>
        public int Version { get; set; }
    }
}
