using System;

using Moq;

using Sharpdev.SDK.Layers.Domain.Entities;

namespace Sharpdev.SDK.Testing
{
    /// <summary>
    ///     Заглушка для идентификатора <see cref="IIdentifier{TOwner}" />.
    /// </summary>
    /// <typeparam name="TEntity">Тип объекта, для которого предназначен идентификатор.</typeparam
    /// <typeparam name="TExternalType">Тип внешнего идентификатора.</typeparam>
    public class IdentifierStub<TEntity, TExternalType> : ITestStub<IIdentifier<TEntity, TExternalType>>
        where TEntity : IEntity<TEntity>
        where TExternalType : struct
    {
        /// <summary>
        ///     Заглушка для идентификатора.
        /// </summary>
        private readonly Mock<IIdentifier<TEntity, TExternalType>> _identifierMock =
            new Mock<IIdentifier<TEntity, TExternalType>>();

        /// <summary>
        ///     Построение заглушки для объекта <see cref="IIdentifier{TEntity,TExternalType}" />.
        /// </summary>
        /// <returns>Заглушка для объекта <see cref="IIdentifier{TEntity,TExternalType}" />.</returns>
        public IIdentifier<TEntity, TExternalType> Please()
        {
            return _identifierMock.Object;
        }

        /// <summary>
        ///     Заполнение приватного идентификатора.
        /// </summary>
        /// <param name="privateIdentifier">Значение приватного идентификатора.</param>
        /// <returns>Строитель для заглушки объекта <see cref="IIdentifier{TEntity,TExternalType}" />.</returns>
        public IdentifierStub<TEntity, TExternalType> PrivateId(int privateIdentifier)
        {
            _identifierMock.Setup(x => x.Private).Returns(privateIdentifier);

            return this;
        }

        /// <summary>
        ///     Заполнение внешнего идентификатора.
        /// </summary>
        /// <param name="externalIdentifier">Значение внешнего идентификатора.</param>
        /// <returns>Строитель для заглушки объекта <see cref="IIdentifier{TEntity,TExternalType}" />.</returns>
        public IdentifierStub<TEntity, TExternalType> ExternalId(TExternalType externalIdentifier)
        {
            _identifierMock.Setup(x => x.External).Returns(externalIdentifier);

            return this;
        }

        /// <summary>
        ///     Заполнение публичного идентификатора.
        /// </summary>
        /// <param name="publicIdentifier">Значение публичного идентификатора.</param>
        /// <returns>Строитель для заглушки объекта <see cref="IIdentifier{TEntity,TExternalType}" />.</returns>
        public IdentifierStub<TEntity, TExternalType> PublicId(Guid publicIdentifier)
        {
            _identifierMock.Setup(x => x.Public).Returns(publicIdentifier);

            return this;
        }
    }
}
