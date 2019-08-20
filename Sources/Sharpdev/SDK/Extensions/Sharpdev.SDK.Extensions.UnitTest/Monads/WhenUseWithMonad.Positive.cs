using FluentAssertions;

using NUnit.Framework;

using Sharpdev.SDK.Testing;

namespace Sharpdev.SDK.Extensions.UnitTest.Monads
{
    [TestFixture]
    [Category(nameof(Extensions))]
    [Category(Constant.Positive)]
    [Parallelizable(ParallelScope.All)]
    public class WhenUseWithMonadPositive
    {
        [Test]
        public void WhenUseWithMonad_WithNullObject_ResultShouldBeNull()
        {
            // Act:
            var obj = new PersonStub();

            // Arrange:
            var result = obj.With(x => x.Address);

            // Assert:
            result.Should().BeNull();
        }

        [Test]
        public void WhenUseWithMonad_WithNotNullObject_ResultShouldBeNotNull()
        {
            // Act:
            var obj = new PersonStub
            {
                Address = new AddressStub()
            };

            // Arrange:
            var result = obj.With(x => x.Address);

            // Assert:
            result.Should().NotBeNull();
        }

    }
}
