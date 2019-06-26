using Sharpdev.SDK.Layers.Domain.Entities;

namespace Sharpdev.SDK.Testing
{
    public class IdentifierStub<TEntity> : ITestStub<Identifier<TEntity>>
        where TEntity : IEntity<TEntity>
    {
        private int _privateIdentifier;

        public Identifier<TEntity> Please()
        {
            return new Identifier<TEntity>(_privateIdentifier);
        }

        public IdentifierStub<TEntity> With(int privateIdentifier)
        {
            _privateIdentifier = privateIdentifier;

            return this;
        }
    }
}
