using System;

using Sharpdev.SDK.Layers.Domain.Factories;

namespace Sharpdev.SDK.Layers.Domain.ValueObjects
{
    /// <summary>
    ///     Объект-значение.
    /// </summary>
    /// <remarks>
    ///     Является ли адрес объектом-значением?
    ///     Смотря для кого. В программе  для  фирмы,  торгующей  по  почте,  адрес  необходим  для
    ///     подтверждения кредитной карточки и отправки посылки. Но  если там  же  заказывает товар
    ///     сосед  по  квартире, фирме  совершенно безразлично, что он находится по тому же адресу.
    ///     Здесь адрес  -  это ОБЪЕКТ-ЗНАЧЕНИЕ.
    ///     Но  в  модели  коммунальные  услуги   могут   ассоциироваться  с  "жилищем",   то  есть
    ///     объектом-сущностью,   у   которого   есть   атрибут   "адрес".   Тогда   "адрес"  будет
    ///     ОБЪЕКТОМ-ЗНАЧЕНИЕМ.
    ///     - No identity.
    ///     - Immutability.
    ///     - Lifetime shortening.
    ///     - Should not have separate tables in database.
    /// </remarks>
    public interface IValueObject<T> : IEncapsulated, IEquatable<IValueObject<T>>
        where T : IValueObject<T>
    {
    }
}
