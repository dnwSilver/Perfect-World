using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Layers.Domain.Factories;

namespace Sharpdev.SDK.Layers.Domain
{
    /// <summary>
    ///     Кластер доменных объектов, которые можно рассматривать как единое целое.
    /// </summary>
    /// <typeparam name="TRootObject">Корневой объект.</typeparam>
    /// <remarks>
    ///     Агрегат - это шаблон в дизайне, управляемом доменом. Агрегат DDD - это кластер доменных
    ///     объектов, которые можно рассматривать  как  единое  целое. Примером может быть заказ  и
    ///     его отдельные позиции,  это  будут  отдельные объекты, но полезно  рассматривать  заказ
    ///     (вместе с его отдельными позициями) как один агрегат.
    ///     Совокупность    ассоциированных   друг   с   другом   объектов   <see cref="IEntity" />,
    ///     воспринимаемых  с  точки  зрения изменения данных  как  единое  целое.  Внешние  ссылки
    ///     возможны только на один объект АГРЕГАТА, именуемый корневым (<see cref="TRootObject" />).
    ///     В границах АГРЕГАТА действует определенный набор правил согласования и единообразия.
    /// </remarks>
    public interface IAggregate<out TRootObject> : IEncapsulated
        where TRootObject : IEntity
    {
        /// <summary>
        ///     Получение коневого объекта.
        /// </summary>
        /// <returns>Корневой объект.</returns>
        TRootObject GetRootEntity();
    }
}
