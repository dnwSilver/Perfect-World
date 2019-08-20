namespace Sharpdev.SDK.Extensions.UnitTest
{
    public class PersonStub
    {
        public AddressStub Address { get; set; }
    }

    public class AddressStub
    {
        public string Text { get; set; } = "г. Екатеринбург, ул. Родонитовая д.33 оф.22";
    }
}
