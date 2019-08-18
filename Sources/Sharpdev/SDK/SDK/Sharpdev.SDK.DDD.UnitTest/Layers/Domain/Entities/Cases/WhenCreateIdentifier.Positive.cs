using System;

using FluentAssertions;

using NUnit.Framework;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Infrastructure.Integrations;
using Sharpdev.SDK.Testing;

namespace Sharpdev.SDK.UnitTest.Layers.Domain.Entities.Cases
{
    [TestFixture]
    [Category(nameof(SDK))]
    [Category(Constant.Positive)]
    [Parallelizable(ParallelScope.All)]
    public class WhenCreateIdentifier
    {
        [Test]
        [TestCase("Some identifier")]
        [TestCase("1")]
        [TestCase("adasdsa dsa -ds das -")]
        public void WhenCreateIdentifier_WithExternalId_ExternalIdShouldBeValue(string externalIdentifier)
        {
            // Act:
            const int PRIVATE_IDENTIFIER = 1;
            const ProgramProductType PROGRAM_PRODUCT = ProgramProductType.SharpdevTesting;
            var publicId = Guid.NewGuid();
            var externalIds = new ExternalIdentifiers
            {
                {
                    PROGRAM_PRODUCT, externalIdentifier
                }
            };

            // Arrange:
            var identifier = new Identifier<StubEntity>(PRIVATE_IDENTIFIER, publicId, externalIds);

            // Assert:
            identifier.Externals[PROGRAM_PRODUCT].Should().Be(externalIdentifier);
        }

        [Test]
        [TestCase("Some identifier")]
        public void WhenCreateIdentifier_WithExternalId_ExternalIdShouldNotBeNull(string externalIdentifier)
        {
            // Act:
            const int PRIVATE_IDENTIFIER = 1;
            const ProgramProductType PROGRAM_PRODUCT = ProgramProductType.SharpdevTesting;
            var publicId = Guid.NewGuid();
            var externalIds = new ExternalIdentifiers
            {
                {
                    PROGRAM_PRODUCT, externalIdentifier
                }
            };

            // Arrange:
            var identifier = new Identifier<StubEntity>(PRIVATE_IDENTIFIER, publicId, externalIds);

            // Assert:
            identifier.Externals[PROGRAM_PRODUCT].Should().NotBeNull();
        }

        [Test]
        public void WhenCreateIdentifier_WithPrivateAndPublicId_PrivateIdShouldBeOne()
                 {
            // Act:
            const int PRIVATE_IDENTIFIER = 1;
            var publicIdentifier = Guid.NewGuid();

            // Arrange:
            var identifier = new Identifier<StubEntity>(PRIVATE_IDENTIFIER, publicIdentifier);

            // Assert:
            identifier.Private.Should().Be(PRIVATE_IDENTIFIER);
        }

        [Test]
        public void WhenCreateIdentifier_WithPrivateAndPublicId_PublicIdShouldBeNew()
        {
            // Act:
            const int PRIVATE_IDENTIFIER = 1;
            var publicId = Guid.NewGuid();

            // Arrange:
            var identifier = new Identifier<StubEntity>(PRIVATE_IDENTIFIER, publicId);

            // Assert:
            identifier.Public.Should().Be(publicId);
        }

        [Test]
        public void WhenCreateIdentifier_WithPrivateAndPublicId_ResultShouldNotBeNull()
        {
            // Act:
            const int PRIVATE_IDENTIFIER = 1;
            var publicIdentifier = Guid.NewGuid();

            // Arrange:
            var identifier = new Identifier<StubEntity>(PRIVATE_IDENTIFIER, publicIdentifier);

            // Assert:
            identifier.Should().NotBeNull();
        }
    }
}
