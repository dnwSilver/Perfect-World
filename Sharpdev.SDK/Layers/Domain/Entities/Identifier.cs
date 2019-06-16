using System;

using Sharpdev.SDK.Extensions;

namespace Sharpdev.SDK.Layers.Domain.Entities
{
    /// <summary>
    ///     Идентификатор бизнес сущности. Состоит из трёх частей:
    ///     - public,
    ///     - private,
    ///     - external.
    /// </summary>
    /// <remarks>
    ///     Для данного проекта выбрал ссылочный тип данных.
    ///     Причины и доводы описал в задаче.
    ///     Если есть желание обсудить прошу оставлять комментарии в задаче.
    ///     https://github.com/dnwSilver/Sharpdev.Services.Identity.API/issues/1
    /// </remarks>
    public class Identifier<TEntity> : IIdentifier<TEntity>
        where TEntity : IEntity<TEntity>
    {
        /// <summary>
        ///     Уникальный идентификатор бизнес сущности.
        /// </summary>
        /// <param name="privateId">Приватный идентификатор.</param>
        /// <param name="publicId">Публичный идентификатор.</param>
        /// <param name="externalId">Внешний идентификатор.</param>
        public Identifier(int privateId, Guid publicId = default, string externalId = default)
        {
            Public = publicId;
            Private = privateId;
            External = externalId;
        }

        /// <summary>
        ///     Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///     <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public bool Equals(IIdentifier<TEntity> other)
        {
            return other.If(x => x.Private == Private).ReturnSuccess();
        }

        /// <summary>
        ///     Публичный идентификатор. Генерируется внутри сервиса.
        /// </summary>
        public Guid Public { get; }

        /// <summary>
        ///     Приватный идентификатор. Генерируется внутри сервиса.
        /// </summary>
        public int Private { get; }

        /// <summary>
        ///     Идентификатор внешней системы. Генерируется не в сервисе.
        /// </summary>
        public string External { get; }

        /// <summary>
        ///     Проверка состояния приватного идентификатора.
        /// </summary>
        /// <returns>
        ///     <see langword="true" /> - постоянный идентификатор.
        ///     <see langword="false" /> - временный идентификатор.
        /// </returns>
        public bool IsTransient()
        {
            return Private != default;
        }

        /// <summary>
        ///     Проверка наличия публичного идентификатора.
        /// </summary>
        /// <returns>
        ///     <see langword="true" /> - Идентификатор существует.
        ///     <see langword="false" /> - Идентификатор не существует.
        /// </returns>
        public bool HasPublicIdentifier()
        {
            return Public != default;
        }

        /// <summary>
        ///     Проверка наличия внешнего идентификатора.
        /// </summary>
        /// <returns>
        ///     <see langword="true" /> - Идентификатор существует.
        ///     <see langword="false" /> - Идентификатор не существует.
        /// </returns>
        public bool HasExternalIdentifier()
        {
            return External != default;
        }
    }
}
