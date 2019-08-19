using System;

using FluentAssertions;

using NUnit.Framework;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Testing;

namespace Sharpdev.SDK.UnitTest.Domain.Entities.Cases
{
    
    [TestFixture]
    [Category(nameof(Domain))]
    [Category(Constant.Positive)]
    [Parallelizable(ParallelScope.All)]
    public class WhenEqualsIdentifierPositive
    {
        [Test]
        public void WhenEqualsIdentifier_WithEqualsMethod_ResultShouldBeTrue()
        {
            // Act:
            const int privateIdentifier = 1;
            var publicId = Guid.NewGuid();
            var firstIdentifier = new Identifier<StubEntity>(privateIdentifier, publicId);
            var secondIdentifier = new Identifier<StubEntity>(privateIdentifier, publicId);

            // Arrange:
            var equalsResult = firstIdentifier.Equals(secondIdentifier);
            
            // Assert:
            equalsResult.Should().BeTrue();
        }
        
        [Test]
        public void WhenEqualsIdentifier_WithEqualOperator_ResultShouldBeTrue()
        {
            // Act:
            const int privateIdentifier = 1;
            var publicId = Guid.NewGuid();
            var firstIdentifier = new Identifier<StubEntity>(privateIdentifier, publicId);
            var secondIdentifier = new Identifier<StubEntity>(privateIdentifier, publicId);

            // Arrange:
            var equalsResult = firstIdentifier == secondIdentifier;
            
            // Assert:
            equalsResult.Should().BeTrue();
        }
        
        [Test]
        public void WhenUnequalsIdentifier_WithUnequalOperator_ResultShouldBeTrue()
        {
            // Act:
            const int privateIdentifier = 1;
            var firstIdentifier = new Identifier<StubEntity>(privateIdentifier, Guid.NewGuid());
            var secondIdentifier = new Identifier<StubEntity>(privateIdentifier, Guid.NewGuid());

            // Arrange:
            var equalsResult = firstIdentifier != secondIdentifier;
            
            // Assert:
            equalsResult.Should().BeTrue();
        }
    }
}
