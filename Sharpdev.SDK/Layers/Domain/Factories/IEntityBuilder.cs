﻿using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Patterns;

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
    [Builder]
    public interface IEntityBuilder<TEntity>
        where TEntity : IEntity<TEntity>
    {
        // TODO Сделать snippet для создания свойства и метода для занесения значения в IEntityBuilder
        /// <summary>
        ///     Идентификатор объекта <see cref="TEntity" />.
        /// </summary>
        IIdentifier<TEntity> Identifier { get; }

        /// <summary>
        ///     Идентификатор объекта <see cref="TEntity" />.
        /// </summary>
        int Version { get; }

        /// <summary>
        ///     Фиксация значения идентификатора объекта <see cref="TEntity" />.
        /// </summary>
        /// <param name="entityIdentifier">Значение идентификатора.</param>
        /// <returns>Строитель для заглушки объекта <see cref="TEntity" />.</returns>
        IEntityBuilder<TEntity> SetIdentifier(IIdentifier<TEntity> entityIdentifier);

        /// <summary>
        ///     Фиксация версии объекта <see cref="TEntity" />.
        /// </summary>
        /// <param name="entityVersion">Версия объекта.</param>
        /// <returns>Строитель для заглушки объекта <see cref="TEntity" />.</returns>
        IEntityBuilder<TEntity> SetVersion(int entityVersion);
    }
}
