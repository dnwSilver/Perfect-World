﻿using System.Collections.Generic;

using Sharpdev.SDK.Layers.Domain.Events;
using Sharpdev.SDK.Layers.Domain.Factories;
using Sharpdev.SDK.Layers.Infrastructure.Repositories;
using Sharpdev.SDK.Layers.Responsibility;

namespace Sharpdev.SDK.Layers.Domain.Entities
{
    /// <summary>
    ///     Сущность бизнес модели. Основная единица DDD.
    ///     Объект, суть которого определяется не его атрибутами,  а непрерывностью существования и
    ///     идентификации <see cref="IIdentifier{TOwner}" />.
    /// </summary>
    /// <remarks>
    ///     В  программе  обслуживания  почтовых  отправлений,
    ///     предназначенной   для   организации  маршрутов  доставки  почты,  страна   может   быть
    ///     представлена в виде иерархии областей,  городов,  индексных зон  и  жилищных  массивов,
    ///     которая  заканчивается  отдельными адресами.  Такие  адресные  объекты  наследуют  свой
    ///     почтовый индекс от родительского объекта в иерархии, и если почтовое  управление  решит
    ///     изменить индексные зоны, все адреса в их пределах "подстроятся" под это изменение.
    ///     Здесь адрес является СУЩНОСТЬЮ.
    ///     Identifier  equality  (эквивалентность  идентификаторов)  подразумевает, что  у  класса
    ///     присутствует поле Id.
    ///     В программе  для  коммунальной  электрической  компании  адрес  соответствует  месту, к
    ///     которому  подведены кабельные  линии и где  оказываются  услуги.  Если  два  соседа  по
    ///     квартире позвонят и по отдельности закажут какие-то работы, фирме нужно знать,  что они
    ///     находятся в одном месте.  Здесь адрес  -  также СУЩНОСТЬ.
    /// </remarks>
    public interface IEntity<TEntity> : IEncapsulated, IStored, IHasIdentifier<TEntity>, IHasDomainEvent
        where TEntity : IEntity<TEntity>
    {
        /// <summary>
        ///     Набор условий-ограничение.
        /// </summary>
        IReadOnlyCollection<IPolicy> Policies();
    }
}
