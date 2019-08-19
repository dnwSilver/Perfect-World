using System;

using FluentAssertions;

using NUnit.Framework;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Testing;

namespace Sharpdev.SDK.UnitTest.Domain.Entities.Cases
{
    
    [TestFixture]
    [Category(nameof(Domain))]
    [Category(Constant.Negative)]
    [Parallelizable(ParallelScope.All)]
    public class WhenEqualsIdentifierNegative
    {
        [Test]
        public void WhenEqualsIdentifier_WithEqualsMethod_ResultShouldBeFalse()
        {
            // Act:
            const int privateIdentifier = 1;
            var firstIdentifier = new Identifier<StubEntity>(privateIdentifier, Guid.NewGuid());
            var secondIdentifier = new Identifier<StubEntity>(privateIdentifier, Guid.NewGuid());

            // Arrange:
            var equalsResult = firstIdentifier.Equals(secondIdentifier);
            
            // Assert:
            equalsResult.Should().BeFalse();
        }
        
        [Test]
        public void WhenEqualsIdentifier_WithEqualOperator_ResultShouldBeFalse()
        {
            // Act:
            const int privateIdentifier = 1;
            var firstIdentifier = new Identifier<StubEntity>(privateIdentifier, Guid.NewGuid());
            var secondIdentifier = new Identifier<StubEntity>(privateIdentifier, Guid.NewGuid());

            // Arrange:
            var equalsResult = firstIdentifier == secondIdentifier;
            
            // Assert:
            equalsResult.Should().BeFalse();
        }
        
        [Test]
        public void WhenUnequalsIdentifier_WithEqualsMethod_ResultShouldBeFalse()
        {
            // Act:
            const int privateIdentifier = 1;
            var firstIdentifier = new Identifier<StubEntity>(privateIdentifier, Guid.NewGuid());
            var secondIdentifier = new Identifier<StubEntity>(privateIdentifier, Guid.NewGuid());

            // Arrange:
            var equalsResult = firstIdentifier.Equals(secondIdentifier);
            
            // Assert:
            equalsResult.Should().BeFalse();
        }
        
        [Test]
        public void WhenUnequalsIdentifier_WithEqualOperator_ResultShouldBeFalse()
        {
            // Act:
            const int privateIdentifier = 1;
            var firstIdentifier = new Identifier<StubEntity>(privateIdentifier, Guid.NewGuid());
            var secondIdentifier = new Identifier<StubEntity>(privateIdentifier, Guid.NewGuid());

            // Arrange:
            var equalsResult = firstIdentifier == secondIdentifier;
            
            // Assert:
            equalsResult.Should().BeFalse();
        }
    }
}
