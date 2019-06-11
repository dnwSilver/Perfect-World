﻿using Sharpdev.SDK.Layers.Infrastructure.Statuses;
using Sharpdev.SDK.Types.Results;

namespace Sharpdev.SDK.Layers.Application
{
    /// <summary>
    ///     Сервис предоставляемый для бизнеса.
    /// </summary>
    /// <remarks>
    ///     Лучший вариант, когда домен содержит точные названия для сервиса  —  «касса»,  «склад»,
    ///     «кол-центр».  Набор  методов   в   каждом  классе  соответствует  набору  use  case'ов,
    ///     сгруппированных  по  элементам пользовательского  интерфейса.     Работает хорошо, если
    ///     интерфейс разработан в стиле Task Based UI.
    ///     Проверка  запроса  производится  в  отдельном   слое   строго  до  выполнения    метода
    ///     (<see cref="AntiCorruption" />).  Если метод может завершиться  неудачей,  следует явно
    ///     обозначить это в сигнатуре с помощью типа <see cref="Result" />.
    /// </remarks>
    public interface IService : IHasStatus<ServiceStatus>
    {
    }
}
