using System;

using Sharpdev.SDK.Extensions;

namespace Sharpdev.SDK.Domain.Entities
{
    /// <summary>
    ///     Идентификатор бизнес сущности. Состоит из трёх частей:
    ///     - public,
    ///     - private,
    ///     - externals.
    /// </summary>
    public class Identifier<TEntity>: IIdentifier<TEntity>
            where TEntity: IEntity<TEntity>
    {
        /// <summary>
        ///     Значение неопределённого приватного идентификатора.
        /// </summary>
        public const int Undefined = 0; // todo Нужно вынести это в конфигурационный файл.

        /// <summary>
        ///     Уникальный идентификатор бизнес сущности.
        /// </summary>
        /// <param name="privateId"> Приватный идентификатор. </param>
        /// <param name="publicId"> Публичный идентификатор. </param>
        public Identifier(long privateId, Guid publicId)
        {
            Public = publicId;
            Private = privateId;
        }

        /// <summary>
        ///     Уникальный идентификатор бизнес сущности.
        /// </summary>
        /// <param name="privateId"> Приватный идентификатор. </param>
        /// <param name="publicId"> Публичный идентификатор. </param>
        /// <param name="externalIds"> Набор внешних идентификаторов. </param>
        public Identifier(long privateId, Guid publicId, ExternalIdentifiers? externalIds)
        {
            Public = publicId;
            Private = privateId;
            Externals = externalIds ?? Externals;
        }

        /// <summary>
        ///     Набор внешних идентификаторов. Генерируются во внешнем сервисе.
        /// </summary>
        public ExternalIdentifiers Externals { get; } = new ExternalIdentifiers();

        /// <summary>
        ///     Публичный идентификатор. Генерируется внутри сервиса.
        /// </summary>
        public Guid Public { get; }

        /// <summary>
        ///     Приватный идентификатор. Генерируется внутри сервиса.
        /// </summary>
        public long Private { get; }

        /// <summary>
        ///     Указывает, равен ли текущий объект другому объекту того же типа.
        /// </summary>
        /// <param name="other"> Объект для сравнения с этим объектом. </param>
        /// <returns>
        ///     <see langword="true"/> если текущий объект равен <paramref name="other"/> параметр; иначе,
        ///     <see langword="false"/>.
        /// </returns>
        public bool Equals(IIdentifier<TEntity> other)
            => other != null && other.Public == Public;

        /// <summary>
        ///     Указывает, равен ли текущий объект другому объекту того же типа.
        /// </summary>
        /// <param name="other"> Объект для сравнения с этим объектом. </param>
        /// <returns>
        ///     <see langword="true"/> если текущий объект равен <paramref name="other"/> параметр; иначе,
        ///     <see langword="false"/>.
        /// </returns>
        private bool Equals(Identifier<TEntity> other)
            => Public.Equals(other.Public);

        /// <summary>
        ///     Определяет, равен ли указанный объект текущему объекту.
        /// </summary>
        /// <param name="obj"> Объект для сравнения с текущим объектом. </param>
        /// <returns>
        ///     <see langword="true"/> если указанный объект равен текущему объекту; в противном случае,
        ///     <see langword="false"/>.
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals((Identifier<TEntity>)obj);
        }

        /// <summary>
        ///     Служит в качестве хэш-функции по умолчанию.
        /// </summary>
        /// <returns> Хеш-код для текущего объекта. </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Externals != null? Externals.GetHashCode(): 0;
                hashCode = (hashCode * 397) ^ Public.GetHashCode();
                hashCode = (hashCode * 397) ^ Private.GetHashCode();

                return hashCode;
            }
        }

        /// <summary>
        ///     Указывает, равен ли один объект другому объекту того же типа.
        /// </summary>
        /// <param name="left"> Объект для сравнения. </param>
        /// <param name="right"> Объект для сравнения. </param>
        /// <returns>
        ///     <see langword="true"/> если <paramref name="left"/> объект не равен <paramref name="right"/>
        ///     параметр; иначе, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(Identifier<TEntity>? left, IIdentifier<TEntity> right)
            => left!.Check(x => x.Equals(right)).ReturnFailure();

        /// <summary>
        ///     Указывает, равен ли один объект другому объекту того же типа.
        /// </summary>
        /// <param name="left"> Объект для сравнения. </param>
        /// <param name="right"> Объект для сравнения. </param>
        /// <returns>
        ///     <see langword="true"/> если <paramref name="left"/> объект равен <paramref name="right"/>
        ///     параметр; иначе, <see langword="false"/>.
        /// </returns>
        public static bool operator ==(Identifier<TEntity>? left, IIdentifier<TEntity> right)
            => left!.Check(x => !x!.Equals(right)).ReturnFailure();

        /// <summary>
        ///     Создание нового уникального идентификатора.
        /// </summary>
        /// <param name="externalIds"> Набор внешних идентификаторов. </param>
        /// <returns> Уникальный идентификатор с пустым приватным идентификатором. </returns>
        /// <remarks>
        ///     Приватный идентификатор нам должен выдать источник данных.   Публичный идентификатор
        ///     делаем прямо тут.
        /// </remarks>
        public static IIdentifier<TEntity> Create(ExternalIdentifiers? externalIds = null)
            => new Identifier<TEntity>(Undefined, Guid.NewGuid(), externalIds);
    }
}
