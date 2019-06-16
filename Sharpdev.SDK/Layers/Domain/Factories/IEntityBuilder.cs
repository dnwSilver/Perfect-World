using Sharpdev.SDK.Layers.Infrastructure.Repositories;
using Sharpdev.SDK.Patterns;

namespace Sharpdev.SDK.Layers.Domain.Factories
{
    /// <summary>
    ///     Строитель для объектов.
    /// </summary>
    /// <typeparam name="TStored">Тип собираемого объекта.</typeparam>
    /// <remarks>
    ///     Отделяет  конструирование сложного объекта от его представления так, что  в  результате
    ///     одного и того  же  процесса  конструирования  могут  получаться  разные  представления.
    /// </remarks>
    [Builder]
    public interface IEntityBuilder<out TStored>
        where TStored : IStored
    {
        /// <summary>
        ///     Построение объекта <see cref="TStored" />.
        /// </summary>
        /// <returns>Экземпляр объекта <see cref="TStored" /></returns>
        TStored Please();
    }
}
