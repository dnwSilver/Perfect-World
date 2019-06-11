using Sharpdev.SDK.Layers.Application;
using Sharpdev.SDK.Layers.Infrastructure.Statuses;
using Sharpdev.SDK.Patterns;

namespace Sharpdev.SDK.Layers.AntiCorruption
{
    /// <summary>
    ///     Внешний программный продукт.
    /// </summary>
    /// <remarks>
    ///     ФАСАДНЫЙ ОБЪЕКТ - это альтернативный интерфейс некоторой подсистемы,  который  упрощает
    ///     обращение к ней со стороны клиента и вообще облегчает ее использование.  Нам известно в
    ///     точности,  какие функции другой системы мы хотим использовать,  вот мы и пишем ФАСАДНЫЙ
    ///     ОБЪЕКТ,  который   упрощает  и  спрямляет   доступ  к  ним,   скрывая   все  остальное.
    ///     Для    каждой    определяемой    нами    службы   (<see cref="IService" />)    необходим
    ///     адаптер (<see cref="IAdapter" />), который поддерживает  интерфейс этой службы  и  умеет
    ///     делать эквивалентные запросы к другой системе или ее ФАСАДНОМУ ОБЪЕКТУ.
    /// </remarks>
    [Facade]
    public interface IExternalProgram : IHasStatus<ExternalProgramStatus>
    {
    }
}
