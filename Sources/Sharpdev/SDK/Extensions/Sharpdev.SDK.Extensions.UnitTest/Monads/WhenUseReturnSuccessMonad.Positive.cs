using FluentAssertions;

using NUnit.Framework;

using Sharpdev.SDK.Testing;

namespace Sharpdev.SDK.Extensions.UnitTest.Monads
{
    [TestFixture]
    [Category(nameof(Extensions))]
    [Category(Constant.Positive)]
    [Parallelizable(ParallelScope.All)]
    public class WhenUseReturnSuccessMonadPositive
    {
        [Test]
        public void WhenUseReturnSuccessMonad_WithNotNullObject_ResultSuccessShouldBeTrue()
        {
            // Act:
            var person = new PersonStub();

            // Arrange:
            var identifier = person.ReturnSuccess();

            // Assert:
            identifier.Should().BeTrue();
        }
        
        [Test]
        public void WhenUseReturnSuccessMonad_WithNullObject_ResultSuccessShouldBeFalse()
        {
            // Act:

            // Arrange:
            var result = ((PersonStub) null).ReturnSuccess();

            // Assert:
            result.Should().BeFalse();
        }

        [Test]
        public void WhenUseReturnFailureMonad_WithNullProperty_ReturnFailureShouldBeTrue()
        {
            // Act:

            // Arrange:
            var result = ((PersonStub) null).ReturnFailure();

            // Assert:
            result.Should().BeTrue();
        }
    }
}
