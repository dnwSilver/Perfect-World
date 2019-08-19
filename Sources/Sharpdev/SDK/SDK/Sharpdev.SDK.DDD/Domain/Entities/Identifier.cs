using System;

using Sharpdev.SDK.Extensions;

namespace Sharpdev.SDK.Domain.Entities
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
        public const int Undefined = 0;

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
        ///     Указывает, равен ли текущий объект другому объекту того же типа.
        /// </summary>
        /// <param name="other">Объект для сравнения с этим объектом.</param>
        /// <returns>
        ///     <see langword="true" /> если текущий объект равен <paramref name="other" /> параметр; иначе,
        ///     <see langword="false" />.
        /// </returns>
        private bool Equals(Identifier<TEntity> other)
        {
            return this.Public.Equals(other.Public);
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>
        ///     <see langword="true" /> if the specified object  is equal to the current object; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;

            return this.Equals((Identifier<TEntity>)obj);
        }

        /// <summary>
        ///     Служит в качестве хэш-функции по умолчанию.
        /// </summary>
        /// <returns>Хеш-код для текущего объекта.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = this.Externals != null ? this.Externals.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ this.Public.GetHashCode();
                hashCode = (hashCode * 397) ^ this.Private;

                return hashCode;
            }
        }

        /// <summary>
        ///     Указывает, равен ли один объект другому объекту того же типа.
        /// </summary>
        /// <param name="left">Объект для сравнения.</param>
        /// <param name="right">Объект для сравнения.</param>
        /// <returns>
        ///     <see langword="true" /> если <paramref name="left" /> объект не равен <paramref name="right" />
        ///     параметр; иначе, <see langword="false" />.
        /// </returns>
        public static bool operator !=(Identifier<TEntity> left, IIdentifier<TEntity> right)
        {
            return left.If(x => x.Equals(right)).ReturnFailure();
        }

        /// <summary>
        ///     Указывает, равен ли один объект другому объекту того же типа.
        /// </summary>
        /// <param name="left">Объект для сравнения.</param>
        /// <param name="right">Объект для сравнения.</param>
        /// <returns>
        ///     <see langword="true" /> если <paramref name="left" /> объект равен <paramref name="right" />
        ///     параметр; иначе, <see langword="false" />.
        /// </returns>
        public static bool operator ==(Identifier<TEntity> left, IIdentifier<TEntity> right)
        {
            return left.If(x => !x.Equals(right)).ReturnFailure();
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
            const int privateId = Undefined;
            var publicId = Guid.NewGuid();

            return new Identifier<TEntity>(privateId, publicId, externalIds);
        }
    }
}
