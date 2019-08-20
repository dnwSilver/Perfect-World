using FluentAssertions;

using NUnit.Framework;

using Sharpdev.SDK.Testing;

namespace Sharpdev.SDK.Extensions.UnitTest.Enumerables
{
    [TestFixture]
    [Category(nameof(Extensions))]
    [Category(Constant.Positive)]
    [Parallelizable(ParallelScope.All)]
    public class WhenUseYieldPositive
    {
        [Test]
        public void WhenUseYield_WithNullObject_ResultShouldHaveCountOne()
        {
            // Act:
            var obj = new object();

            // Arrange:
            var result = obj.Yield();

            // Assert:
            result.Should().HaveCount(1);
        }
    }
}