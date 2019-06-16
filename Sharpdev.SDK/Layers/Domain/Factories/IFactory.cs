using Sharpdev.SDK.Layers.Infrastructure.Repositories;
using Sharpdev.SDK.Patterns;

namespace Sharpdev.SDK.Layers.Domain.Factories
{
    /// <summary>
    ///     Порождающий  шаблон  проектирования,  предоставляет  интерфейс  для  создания  семейств
    ///     взаимосвязанных или взаимозависимых объектов, не специфицируя их конкретных классов.
    /// </summary>
    /// <typeparam name="TStored">Тип создаваемого объекта.</typeparam>
    /// <remarks>
    ///     Работа ФАБРИКИ  -  создать объект  любой требуемой сложности  на  основе  данных.  Если
    ///     в результате получается новый объект,  об этом должен знать клиент, который при желании
    ///     может добавить его в  ХРАНИЛИЩЕ, а оно уже инкапсулирует операции по сохранению объекта
    ///     в базе данных.
    /// </remarks>
    [Factory]
    public interface IFactory<TStored>
        where TStored : IStored
    {
        /// <summary>
        ///     Создание нового объекта.
        /// </summary>
        /// <param name="objectToCreate">Строитель нового объекта.</param>
        /// <returns>Созданный объект.</returns>
        TStored Create(IEntityBuilder<TStored> objectToCreate);

        /// <summary>
        ///     Восстановление уже созданного объекта.
        /// </summary>
        /// <param name="objectToRecovery">Строитель восстанавливаемого объекта.</param>
        /// <returns>Восстановленный объект.</returns>
        TStored Recovery(IEntityBuilder<TStored> objectToRecovery);
    }
}
