using Sharpdev.SDK.Domain.ValueObjects;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.PhoneNumbers;

namespace Prosolve.Services.Identification.Users.ValueObjects
{
    /// <summary>
    /// Информация по контактным данным клиента.
    /// </summary>
    public class ContentInformation : ValueObject<ContentInformation>
    {
        /// <summary>
        ///     Адрес электронной почты указанный для получения обратной связи.
        /// </summary>
        public IConfirmed<EmailAddress>? ContactEmail { get; }

        /// <summary>
        ///     Контактный телефон.
        /// </summary>
        public IConfirmed<PhoneNumber>? ContactPhoneNumber { get; }

        public ContentInformation(IConfirmed<EmailAddress>? contactEmail, IConfirmed<PhoneNumber>? contactPhoneNumber)
        {
            ContactEmail = contactEmail;
            ContactPhoneNumber = contactPhoneNumber;
        }

        protected override bool EqualsCore(ContentInformation other)
        {
            throw new System.NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new System.NotImplementedException();
        }
    }
}
