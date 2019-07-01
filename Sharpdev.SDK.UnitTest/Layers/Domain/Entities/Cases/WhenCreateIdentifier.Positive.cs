using System;

using FluentAssertions;

using NUnit.Framework;

using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Layers.Infrastructure.Integrations;
using Sharpdev.SDK.Testing;

namespace Sharpdev.SDK.UnitTest.Layers.Domain.Entities.Cases
{
    [TestFixture]
    [Category(nameof(SDK))]
    [Parallelizable(ParallelScope.All)]
    public class WhenCreateIdentifier
    {
        [Test]
        public void WhenCreateIdentifier_WithExternalId_ExternalIdShouldBeValue()
        {
            // Act:
            const int PRIVATE_IDENTIFIER = 1;
            const string EXTERNAL_IDENTIFIER = "Some identifier";
            const ProgramProductType PROGRAM_PRODUCT = ProgramProductType.Sharpdev_Testing;
            var publicIdentifier = Guid.NewGuid();
            var externalIdentifiers = new ExternalIdentifiers
            {
                {
                    PROGRAM_PRODUCT, EXTERNAL_IDENTIFIER
                }
            };

            // Arrange:
            var identifier = new Identifier<StubEntity>(PRIVATE_IDENTIFIER, publicIdentifier, externalIdentifiers);

            // Assert:
            identifier.Externals[PROGRAM_PRODUCT]
                      .Should()
                      .Be(EXTERNAL_IDENTIFIER,
                          $" we are create new {nameof(Identifier<StubEntity>)} with external id");
        }

        [Test]
        public void WhenCreateIdentifier_WithExternalId_ExternalIdShouldNotBeNull()
        {
            // Act:
            const int PRIVATE_IDENTIFIER = 1;
            const string EXTERNAL_IDENTIFIER = "Some identifier";
            const ProgramProductType PROGRAM_PRODUCT = ProgramProductType.Sharpdev_Testing;
            var publicIdentifier = Guid.NewGuid();
            var externalIdentifiers = new ExternalIdentifiers
            {
                {
                    PROGRAM_PRODUCT, EXTERNAL_IDENTIFIER
                }
            };

            // Arrange:
            var identifier = new Identifier<StubEntity>(PRIVATE_IDENTIFIER, publicIdentifier, externalIdentifiers);

            // Assert:
            identifier.Externals[PROGRAM_PRODUCT]
                      .Should()
                      .NotBeNull($" we are create new {nameof(Identifier<StubEntity>)} with external id");
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
            identifier.Private.Should()
                      .Be(PRIVATE_IDENTIFIER,
                          $" we are create new {nameof(Identifier<StubEntity>)} with private id = 1");
        }

        [Test]
        public void WhenCreateIdentifier_WithPrivateAndPublicId_PublicIdShouldBeNew()
        {
            // Act:
            const int PRIVATE_IDENTIFIER = 1;
            var publicIdentifier = Guid.NewGuid();

            // Arrange:
            var identifier = new Identifier<StubEntity>(PRIVATE_IDENTIFIER, publicIdentifier);

            // Assert:
            identifier.Public.Should()
                      .Be(publicIdentifier,
                          $" we are create new {nameof(Identifier<StubEntity>)} with public id = new");
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
            identifier.Should().NotBeNull($" we are create new {nameof(Identifier<StubEntity>)}");
        }
    }
}
