using FluentAssertions;

using NUnit.Framework;

using Sharpdev.SDK.Testing;

namespace Sharpdev.SDK.Extensions.UnitTest.Monads
{
    [TestFixture]
    [Category(nameof(Extensions))]
    [Category(Constant.Positive)]
    [Parallelizable(ParallelScope.All)]
    public class WhenUseDoMonadPositive
    {
        [Test]
        public void WhenUseDoMonad_WithNullObject_ResultShouldBeNull()
        {
            // Act:
            AddressStub address = null;
            
            // Arrange:
            var result = address.Execute(null);

            // Assert:
            result.Should().BeNull();
        }
        
        [Test]
        public void WhenUseDoMonad_WithNotNullObject_TextShouldBeNew()
        {
            // Act:
            AddressStub address = new AddressStub();
            const string newAddressText = "г.Екатеринбург, ул.Блюхера д.55а";
            void ChangeAddressText(AddressStub addressStub)
            {
                addressStub.Text = newAddressText;
            }
            
            // Arrange:
            var result = address.Execute(ChangeAddressText);

            // Assert:
            result.Text.Should().Be(newAddressText);
        }
    }
}
