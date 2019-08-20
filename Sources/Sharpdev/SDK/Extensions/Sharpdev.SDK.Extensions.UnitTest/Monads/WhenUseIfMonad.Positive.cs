using FluentAssertions;

using NUnit.Framework;

using Sharpdev.SDK.Testing;

namespace Sharpdev.SDK.Extensions.UnitTest.Monads
{
    [TestFixture]
    [Category(nameof(Extensions))]
    [Category(Constant.Positive)]
    [Parallelizable(ParallelScope.All)]
    public class WhenUseIfMonadSuccess
    {
        [Test]
        public void WhenUseIfMonad_WithNullObject_ResultShouldBeNull()
        {
            // Act:
            AddressStub address = null;

            // Arrange:
            var result = address.If(null);

            // Assert:
            result.Should().BeNull();
        }
        
        [Test]
        public void WhenUseIfMonad_WithCorrectLambda_ResultShouldBeNotNull()
        {
            // Act:
            var address = new AddressStub();

            // Arrange:
            var result = address.If(x => !string.IsNullOrEmpty(x.Text));

            // Assert:
            result.Should().NotBeNull();
        }
        
        [Test]
        public void WhenUseIfMonad_WithNotCorrectLambda_ResultShouldBeNull()
        {
            // Act:
            var address = new AddressStub();

            // Arrange:
            var result = address.If(x => string.IsNullOrEmpty(x.Text));

            // Assert:
            result.Should().BeNull();
        }
    }
}
