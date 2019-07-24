using System;

using Sharpdev.SDK.Extensions;

namespace Sharpdev.SDK.Layers.Domain.Entities
{
    /// <summary>
    ///     Идентификатор бизнес сущности. Состоит из трёх частей:
    ///     - public,
    ///     - private.
    /// </summary>
    public class Identifier<TEntity> : IIdentifier<TEntity>
        where TEntity : IEntity<TEntity>
    {
        /// <summary>
        ///     Уникальный идентификатор бизнес сущности.
        /// </summary>
        /// <param name="privateId">Приватный идентификатор.</param>
        /// <param name="publicId">Публичный идентификатор.</param>
        /// <param name="externalIds">Набор внешних идентификаторов.</param>
        public Identifier(int privateId, Guid publicId, ExternalIdentifiers externalIds = null)
        {
            Public = publicId;
            Private = privateId;
            Externals = externalIds ?? new ExternalIdentifiers();
        }

        /// <summary>
        ///     Набор внешних идентификаторов. Генерируются во внешнем сервисе.
        /// </summary>
        public ExternalIdentifiers Externals { get; }

        /// <summary>
        ///     Публичный идентификатор. Генерируется внутри сервиса.
        /// </summary>
        public Guid Public { get; }

        /// <summary>
        ///     Приватный идентификатор. Генерируется внутри сервиса.
        /// </summary>
        public int Private { get; }

        /// <summary>
        /// Значение неопределённого приавтного иденификатора.
        /// </summary>
        public static int Undefined = 0;
        
        /// <summary>
        ///     Указывает, равен ли текущий объект другому объекту того же типа.
        /// </summary>
        /// <param name="other">Объект для сравнения с этим объектом.</param>
        /// <returns>
        ///     <see langword="true" /> если текущий объект равен <paramref name="other" /> параметр; иначе,
        ///     <see langword="false" />.
        /// </returns>
        public bool Equals(IIdentifier<TEntity> other)
        {
            return other.If(x => x.Public == Public).ReturnSuccess();
        }
    }
}
