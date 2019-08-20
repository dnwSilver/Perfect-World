using FluentAssertions;

using NUnit.Framework;

using Sharpdev.SDK.Testing;

namespace Sharpdev.SDK.Extensions.UnitTest.Monads
{
    [TestFixture]
    [Category(nameof(Extensions))]
    [Category(Constant.Positive)]
    [Parallelizable(ParallelScope.All)]
    public class WhenUseReturnFailureMonadPositive
    {
        [Test]
        public void WhenUseReturnFailureMonad_WithNullObject_ReturnFailureShouldBeTrue()
        {
            // Act:

            // Arrange:
            var result = ((PersonStub) null).ReturnFailure();

            // Assert:
            result.Should().BeTrue();
        }
        
        [Test]
        public void WhenUseReturnFailureMonad_WithNotNullObject_ReturnFailureShouldBeFalse()
        {
            // Act:
            var person = new PersonStub();

            // Arrange:
            var result = person.ReturnFailure();

            // Assert:
            result.Should().BeFalse();
        }
    }
}
