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
    public interface IEntityBuilder<TEntity>
        where TEntity : IEntity<TEntity>
    {
        // TODO Сделать snippet для создания свойства и метода для занесения значения в IEntityBuilder
        /// <summary>
        ///     Идентификатор объекта <see cref="TEntity" />.
        /// </summary>
        IIdentifier<TEntity> Identifier { get; }

        /// <summary>
        ///     Версия объекта <see cref="TEntity" />.
        /// </summary>
        int Version { get; }

        /// <summary>
        ///     Фиксация значения для идентификатора объекта <see cref="TEntity" />.
        /// </summary>
        /// <param name="identifier">Идентификатор объекта <see cref="TEntity" />.</param>
        /// <returns>Строитель для <see cref="TEntity" />". /></returns>
        IEntityBuilder<TEntity> SetIdentifier(IIdentifier<TEntity> identifier);

        /// <summary>
        ///     Фиксация версии для объекта <see cref="TEntity" />.
        /// </summary>
        /// <param name="version">Версия объекта.</param>
        /// <returns>Строитель для <see cref="TEntity" />". /></returns>
        IEntityBuilder<TEntity> SetVersion(int version);
    }
}
