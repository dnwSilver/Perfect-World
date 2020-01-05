﻿using System;

namespace Sharpdev.SDK.Domain.Entities
{
    /// <summary>
    ///     Идентификатор бизнес сущности. Состоит из трёх частей:  public,  private,  external.
    /// </summary>
    /// <typeparam name="TOwner">Владелец идентификатора.</typeparam>
    /// <remarks>
    ///     Особое внимание необходимо уделять идентификаторам. Идентификаторы делятся на три типа:
    ///     <see cref="Private" />
    ///     Идентификатор  системы  используемый для внутренних  нужд  системы. Например в качестве
    ///     первичного ключа в базе данных.
    ///     <see cref="Public" />
    ///     Идентификатор созданный для передачи во внешний мир.  Он является уникальным среди всех
    ///     систем.  С го помощью  мы скрываем  вторичную  информацию от злоумышленников.  Никто не
    ///     поймёт  сколько  у  нас  пользователей  или  не  сможет  использовать  Brute  Force для
    ///     стягивания данных (по крайней мере это будет почти невозможно).
    ///     <see cref="Externals" />
    ///     Идентификатор  пришедший в нашу систему извне.  Понятия не имеем какого он типа и что в
    ///     себе содержит.  Фантазия у разработчиков  может  быть  абсолютно  разная. Идентификатор
    ///     может быть в виде:
    ///     - числа (524773)
    ///     - строки (CU-332772)
    ///     - набора байтов (0xBB489DF2A2905D504CF003FACADE621)
    ///     - 128-битный идентификатор (6F9619FF-8B86-D011-B42D-00CF4FC964FF)
    /// </remarks>
    public interface IIdentifier<TOwner> : IEquatable<IIdentifier<TOwner>>
        where TOwner : IEntity<TOwner>
    {
        /// <summary>
        ///     Публичный идентификатор. Генерируется внутри сервиса.
        /// </summary>
        Guid Public { get; }

        /// <summary>
        ///     Приватный идентификатор. Генерируется внутри сервиса.
        /// </summary>
        int Private { get; }

        /// <summary>
        ///     Набор внешних идентификаторов. Генерируются во внешнем сервисе.
        /// </summary>
        ExternalIdentifiers Externals { get; }
    }
}
