using System;

using FluentAssertions;

using NUnit.Framework;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Infrastructure.Integrations;
using Sharpdev.SDK.Testing;

namespace Sharpdev.SDK.UnitTest.Domain.Entities.Cases
{
    [TestFixture]
    [Category(nameof(Domain))]
    [Category(Constant.Positive)]
    [Parallelizable(ParallelScope.All)]
    public class WhenCreateIdentifier
    {
        [Test]
        [TestCase("Some identifier")]
        [TestCase("1")]
        [TestCase("МАРС0002-330")]
        public void WhenCreateIdentifier_WithExternalId_ExternalIdShouldBeValue(
            string externalIdentifier)
        {
            // Act:
            const int privateIdentifier = 1;
            const ProgramProductType programProduct = ProgramProductType.SharpdevTesting;
            var publicId = Guid.NewGuid();
            var externalIds = new ExternalIdentifiers
            {
                {
                    programProduct, externalIdentifier
                }
            };

            // Arrange:
            var identifier = new Identifier<StubEntity>(privateIdentifier, publicId, externalIds);

            // Assert:
            identifier.Externals[programProduct].Should().Be(externalIdentifier);
        }

        [Test]
        [TestCase("Some identifier")]
        public void WhenCreateIdentifier_WithExternalId_ExternalIdShouldNotBeNull(
            string externalIdentifier)
        {
            // Act:
            const int privateIdentifier = 1;
            const ProgramProductType programProduct = ProgramProductType.SharpdevTesting;
            var publicId = Guid.NewGuid();
            var externalIds = new ExternalIdentifiers
            {
                {
                    programProduct, externalIdentifier
                }
            };

            // Arrange:
            var identifier = new Identifier<StubEntity>(privateIdentifier, publicId, externalIds);

            // Assert:
            identifier.Externals[programProduct].Should().NotBeNull();
        }

        [Test]
        public void WhenCreateIdentifier_WithPrivateAndPublicId_PrivateIdShouldBeOne()
        {
            // Act:
            const int privateIdentifier = 1;
            var publicIdentifier = Guid.NewGuid();

            // Arrange:
            var identifier = new Identifier<StubEntity>(privateIdentifier, publicIdentifier);

            // Assert:
            identifier.Private.Should().Be(privateIdentifier);
        }

        [Test]
        public void WhenCreateIdentifier_WithPrivateAndPublicId_PublicIdShouldBeNew()
        {
            // Act:
            const int privateIdentifier = 1;
            var publicId = Guid.NewGuid();

            // Arrange:
            var identifier = new Identifier<StubEntity>(privateIdentifier, publicId);

            // Assert:
            identifier.Public.Should().Be(publicId);
        }

        [Test]
        public void WhenCreateIdentifier_WithPrivateAndPublicId_ResultShouldNotBeNull()
        {
            // Act:
            const int privateIdentifier = 1;
            var publicIdentifier = Guid.NewGuid();

            // Arrange:
            var identifier = new Identifier<StubEntity>(privateIdentifier, publicIdentifier);

            // Assert:
            identifier.Should().NotBeNull();
        }


        [Test]
        [TestCase("Some identifier")]
        public void WhenCreateIdentifier_WithExternalId_PrivateIdShouldBeUndefined(
            string externalIdentifier)
        {
            // Act:
            const ProgramProductType programProduct = ProgramProductType.SharpdevTesting;
            var externalIds = new ExternalIdentifiers
            {
                {
                    programProduct, externalIdentifier
                }
            };

            // Arrange:
            var identifier = Identifier<StubEntity>.Create(externalIds);

            // Assert:
            identifier.Private.Should().Be(Identifier<StubEntity>.Undefined);
        }
    }
}
