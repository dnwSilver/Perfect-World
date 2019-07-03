﻿using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Patterns;

namespace Sharpdev.SDK.Layers.Domain.Factories
{
    /// <summary>
    ///     Порождающий  шаблон  проектирования,  предоставляет  интерфейс  для  создания  семейств
    ///     взаимосвязанных или взаимозависимых объектов, не специфицируя их конкретных классов.
    /// </summary>
    /// <typeparam name="TEntity">Тип создаваемого объекта.</typeparam>
    /// <remarks>
    ///     Работа ФАБРИКИ  -  создать объект  любой требуемой сложности  на  основе  данных.  Если
    ///     в результате получается новый объект,  об этом должен знать клиент, который при желании
    ///     может добавить его в  ХРАНИЛИЩЕ, а оно уже инкапсулирует операции по сохранению объекта
    ///     в базе данных.
    /// </remarks>
    [Factory]
    public interface IFactory<TEntity>
        where TEntity : IEntity<TEntity>
    {
        /// <summary>
        ///     Создание нового объекта.
        /// </summary>
        /// <param name="objectToCreate">Строитель нового объекта.</param>
        /// <returns>Созданный объект.</returns>
        TEntity Create(IEntityBuilder<TEntity> objectToCreate);

        /// <summary>
        ///     Восстановление уже созданного объекта.
        /// </summary>
        /// <param name="objectToRecovery">Строитель восстанавливаемого объекта.</param>
        /// <returns>Восстановленный объект.</returns>
        TEntity Recovery(IEntityBuilder<TEntity> objectToRecovery);
    }
}
