using System;

using Moq;

using Sharpdev.SDK.Layers.Domain.Entities;

namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Заглушка для идентификатора <see cref="IIdentifier{TOwner}" />.
    /// </summary>
    /// <typeparam name="TEntity">Тип объекта, для которого предназначен идентификатор.</typeparam>
    public class IdentifierStub<TEntity> : ITestStub<IIdentifier<TEntity>>
        where TEntity : IEntity<TEntity>
    {
        /// <summary>
        ///     Заглушка для идентификатора.
        /// </summary>
        private readonly Mock<IIdentifier<TEntity>> _identifierMock = new Mock<IIdentifier<TEntity>>();

        /// <summary>
        ///     Построение заглушки для объекта <see cref="IIdentifier{TEntity}" />.
        /// </summary>
        /// <returns>Заглушка для объекта <see cref="IIdentifier{TEntity}" />.</returns>
        public IIdentifier<TEntity> Please()
        {
            return _identifierMock.Object;
        }

        /// <summary>
        ///     Заполнение приватного идентификатора.
        /// </summary>
        /// <param name="privateIdentifier">Значение приватного идентификатора.</param>
        /// <returns>Строитель для заглушки объекта <see cref="IIdentifier{TEntity}" />.</returns>
        public IdentifierStub<TEntity> PrivateId(int privateIdentifier)
        {
            _identifierMock.Setup(x => x.Private).Returns(privateIdentifier);

            return this;
        }

        /// <summary>
        ///     Заполнение публичного идентификатора.
        /// </summary>
        /// <param name="publicIdentifier">Значение публичного идентификатора.</param>
        /// <returns>Строитель для заглушки объекта <see cref="IIdentifier{TEntity}" />.</returns>
        public IdentifierStub<TEntity> PublicId(Guid publicIdentifier)
        {
            _identifierMock.Setup(x => x.Public).Returns(publicIdentifier);
            return this;
        }
    }
}
