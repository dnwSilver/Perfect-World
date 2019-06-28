using System;

namespace Sharpdev.SDK.Layers.Domain.Entities
{
    /// <summary>
    ///     Идентификатор бизнес сущности. Состоит из трёх частей:
    ///     - public,
    ///     - private,
    ///     - external.
    /// </summary>
    /// <typeparam name="TEntity">Владелец идентификатора.</typeparam>
    /// <typeparam name="TExternalType">Тип внешнего идентификатора.</typeparam>
    /// <remarks>
    ///     Для данного проекта выбрал ссылочный тип данных.
    ///     Причины и доводы описал в задаче.
    ///     Если есть желание обсудить прошу оставлять комментарии в задаче.
    ///     https://github.com/dnwSilver/Sharpdev.Services.Identity.API/issues/1
    /// </remarks>
    public sealed class Identifier<TEntity, TExternalType> : Identifier<TEntity>, IIdentifier<TEntity, TExternalType>
        where TEntity : IEntity<TEntity>
        where TExternalType : struct
    {
        /// <summary>
        ///     Уникальный идентификатор бизнес сущности.
        /// </summary>
        /// <param name="privateId">Приватный идентификатор.</param>
        /// <param name="publicId">Публичный идентификатор.</param>
        /// <param name="external">Внешний идентификатор.</param>
        public Identifier(int privateId, Guid publicId, TExternalType external)
            : base(privateId, publicId)
        {
            External = external;
        }

        /// <summary>
        ///     Идентификатор внешней системы. Генерируется не в сервисе.
        /// </summary>
        public TExternalType External { get; }
    }
}
