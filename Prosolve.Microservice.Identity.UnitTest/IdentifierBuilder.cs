using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Testing;

namespace Prosolve.MicroService.Identity.UnitTest
{
    public class IdentifierBuilder<TEntity> : ITestBuilder<Identifier<TEntity>>
        where TEntity : IEntity<TEntity>
    {
        private int _privateIdentifier;

        public Identifier<TEntity> Please()
        {
            return new Identifier<TEntity>(_privateIdentifier);
        }

        public IdentifierBuilder<TEntity> With(int privateIdentifier)
        {
            _privateIdentifier = privateIdentifier;

            return this;
        }
    }
}
