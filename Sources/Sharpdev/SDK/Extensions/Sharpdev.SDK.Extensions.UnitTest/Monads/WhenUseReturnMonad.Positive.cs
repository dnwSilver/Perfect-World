using FluentAssertions;

using NUnit.Framework;

using Sharpdev.SDK.Testing;

namespace Sharpdev.SDK.Extensions.UnitTest.Monads
{
    [TestFixture]
    [Category(nameof(Extensions))]
    [Category(Constant.Positive)]
    [Parallelizable(ParallelScope.All)]
    public class WhenUseReturnMonadPositive
    {
        [Test]
        public void WhenUseReturnMonad_WithNullObject_ReturnShouldBeFailureValue()
        {
            // Act:
            AddressStub address = null;
            const string notFoundText = "Не найдено.";
            
            // Arrange:
            var resultText = address.Return(null, notFoundText);

            // Assert:
            resultText.Should().Be(notFoundText);
        }
        
        [Test]
        public void WhenUseReturnMonad_WithNotNullObject_ReturnShouldNotBeFailureValue()
        {
            // Act:
            AddressStub address = new AddressStub();
            const string notFoundText = "Не найдено.";
            
            // Arrange:
            var resultText = address.Return(x=> x.Text, notFoundText);

            // Assert:
            resultText.Should().NotBe(notFoundText);
        }
    }
}
