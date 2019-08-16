using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Types.Results;

namespace Sharpdev.SDK.Domain.Factories
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
    public interface IEntityFactory<TEntity>
        where TEntity : IEntity<TEntity>
    {
        /// <summary>
        ///     Создание нового объекта.
        /// </summary>
        /// <param name="entityToCreate">Строитель нового объекта.</param>
        /// <returns>Созданный объект.</returns>
        Result<TEntity> Create(IEntityBuilder<TEntity> entityToCreate);

        /// <summary>
        ///     Восстановление уже созданного объекта.
        /// </summary>
        /// <param name="entityToRecovery">Строитель восстанавливаемого объекта.</param>
        /// <returns>Восстановленный объект.</returns>
        Result<TEntity> Recovery(IEntityBuilder<TEntity> entityToRecovery);
    }
}
