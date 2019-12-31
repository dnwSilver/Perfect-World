using System;

using Moq;

using Sharpdev.SDK.Domain.Entities;

namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Генератор для идентификатора <see cref="IIdentifier{TOwner}" />.
    /// </summary>
    /// <typeparam name="TEntity">Тип объекта, для которого предназначен идентификатор.</typeparam>
    public class IdentifierGenerator<TEntity> : TestObjectGeneratorBase<IIdentifier<TEntity>>
        where TEntity : class, IEntity<TEntity>
    {
        /// <summary>
        ///     Заглушка для идентификатора.
        /// </summary>
        private readonly Mock<IIdentifier<TEntity>> _identifierMock =
            new Mock<IIdentifier<TEntity>>();

        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="stubNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected override IIdentifier<TEntity> AllocateStub(int stubNumber)
        {
            return this._identifierMock.Object;
        }

        /// <summary>
        ///     Заполнение приватного идентификатора.
        /// </summary>
        /// <param name="privateIdentifier">Значение приватного идентификатора.</param>
        /// <returns>Строитель для заглушки объекта <see cref="IIdentifier{TEntity}" />.</returns>
        public IdentifierGenerator<TEntity> PrivateId(int privateIdentifier)
        {
            this._identifierMock.Setup(x => x.Private).Returns(privateIdentifier);

            return this;
        }

        /// <summary>
        ///     Заполнение публичного идентификатора.
        /// </summary>
        /// <param name="publicIdentifier">Значение публичного идентификатора.</param>
        /// <returns>Строитель для заглушки объекта <see cref="IIdentifier{TEntity}" />.</returns>
        public IdentifierGenerator<TEntity> PublicId(Guid publicIdentifier)
        {
            this._identifierMock.Setup(x => x.Public).Returns(publicIdentifier);

            return this;
        }
    }
}
