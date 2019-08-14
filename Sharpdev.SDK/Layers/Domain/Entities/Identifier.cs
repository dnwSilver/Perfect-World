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
        ///     Значение неопределённого приватного идентификатора.
        /// </summary>
        private const int Undefined = 0;

        /// <summary>
        ///     Уникальный идентификатор бизнес сущности.
        /// </summary>
        /// <param name="privateId">Приватный идентификатор.</param>
        /// <param name="publicId">Публичный идентификатор.</param>
        public Identifier(int privateId, Guid publicId)
        {
            this.Public = publicId;
            this.Private = privateId;
        }

        /// <summary>
        ///     Уникальный идентификатор бизнес сущности.
        /// </summary>
        /// <param name="privateId">Приватный идентификатор.</param>
        /// <param name="publicId">Публичный идентификатор.</param>
        /// <param name="externalIds">Набор внешних идентификаторов.</param>
        public Identifier(int privateId, Guid publicId, ExternalIdentifiers externalIds)
        {
            this.Public = publicId;
            this.Private = privateId;
            this.Externals = externalIds ?? new ExternalIdentifiers();
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
        ///     Указывает, равен ли текущий объект другому объекту того же типа.
        /// </summary>
        /// <param name="other">Объект для сравнения с этим объектом.</param>
        /// <returns>
        ///     <see langword="true" /> если текущий объект равен <paramref name="other" /> параметр; иначе,
        ///     <see langword="false" />.
        /// </returns>
        public bool Equals(IIdentifier<TEntity> other)
        {
            return other.If(x => x.Public == this.Public).ReturnSuccess();
        }

        /// <summary>
        ///     Создание нового уникального идентификатора.
        /// </summary>
        /// <param name="externalIds">Набор внешних идентификаторов.</param>
        /// <returns>Уникальный идентификатор с пустым приватным идентификатором.</returns>
        /// <remarks>
        ///     Приватный идентификатор нам должен выдать источник данных.   Публичный идентификатор
        ///     делаем прямо тут.
        /// </remarks>
        public static Identifier<TEntity> New(ExternalIdentifiers externalIds)
        {
            var privateId = Undefined;
            var publicId = Guid.NewGuid();

            return new Identifier<TEntity>(privateId, publicId, externalIds);
        }
    }
}
