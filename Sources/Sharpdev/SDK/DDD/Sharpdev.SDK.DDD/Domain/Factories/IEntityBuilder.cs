using Sharpdev.SDK.Domain.Entities;

namespace Sharpdev.SDK.Domain.Factories
{
    /// <summary>
    ///     Строитель для объектов.
    /// </summary>
    /// <typeparam name="TEntity">Тип собираемого объекта.</typeparam>
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
        IIdentifier<TEntity>? Identifier { get; set; }

        /// <summary>
        ///     Версия объекта <see cref="TEntity" />.
        /// </summary>
        int Version { get; set; }
    }
}
