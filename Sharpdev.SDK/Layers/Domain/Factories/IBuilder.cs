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
    public interface IBuilder<out TStored>
        where TStored : IStored
    {
        /// <summary>
        ///     Признак отвечающий за заполнение всех полей в строителе.
        /// </summary>
        /// <returns>
        ///     True - все поля заполнены.
        ///     False - не все поля заполнены.
        /// </returns>
        bool IsValid();

        /// <summary>
        ///     Построение объекта <see cref="TStored" />.
        /// </summary>
        /// <returns>Экземпляр объекта <see cref="TStored" /></returns>
        TStored Build();
    }
}
