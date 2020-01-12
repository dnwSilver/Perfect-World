using System;

using AutoMapper;

using Prosolve.Services.Identification.Users.DataSources;
using Prosolve.Services.Identification.Users.Factories;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;
using Sharpdev.SDK.Types.PhoneNumbers;

namespace Prosolve.Services.Identification.Users
{
    /// <summary>
    ///     Класс для сопоставление полей объекта <see cref="IUserAggregate"/>.
    /// </summary>
    public sealed class UserMapper: Profile
    {
        /// <summary>
        ///     Метод для определения наименования конечного свойства.
        /// </summary>
        /// <returns> Конечное наименование свойства. </returns>
        public UserMapper()
        {
            CreateMap<IUserAggregate, UserDataModel>()
                   .ForMember(d => d.PrivateId, o => o.MapFrom(s => s.Id.Private))
                   .ForMember(d => d.PublicId, p => p.MapFrom(s => s.Id.Public))
                   .ForMember(d => d.FirstName, p => p.MapFrom(s => s.FullName.FirstName))
                   .ForMember(d => d.MiddleName, p => p.MapFrom(s => s.FullName.Patronymic))
                   .ForMember(d => d.Surname, p => p.MapFrom(s => s.FullName.Surname))
                   .ForMember(d => d.EmailAddress, o => o.MapFrom(s => s.ContactEmail.Value))
                   .ForMember(d => d.EmailAddressConfirmDate, o => o.MapFrom(s => s.ContactEmail.ConfirmedDate))
                   .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.ContactPhoneNumber.Value))
                   .ForMember(d => d.PhoneNumberConfirmDate, o => o.MapFrom(s => s.ContactPhoneNumber.ConfirmedDate))
                   .ForMember(d => d.Version, o => o.MapFrom(s => s.CurrentVersion))
                   .ReverseMap()
                   .ForAllOtherMembers(x => x.Ignore());

            CreateMap<UserDataModel, IUserBuilder>()
                   .ForMember(d => d.Identifier, o => o.MapFrom(s => Identifier(s.PrivateId, s.PublicId)))
                   .ForMember(d => d.ContactEmailAddress, o => o.MapFrom(s => new Confirmed<EmailAddress>(s.EmailAddress, s.EmailAddressConfirmDate)))
                   .ForMember(d => d.ContactPhoneNumber, o => o.MapFrom(s => new Confirmed<PhoneNumber>(s.PhoneNumber, s.PhoneNumberConfirmDate)))
                   .ForMember(d => d.FullName, o => o.MapFrom(s => new FullName(s.Surname, s.FirstName, s.MiddleName)))
                   .ReverseMap()
                   .ForAllOtherMembers(x => x.Ignore());
        }

        private static Identifier<IUserAggregate> Identifier(int privateId, Guid publicId)
        {
            return new Identifier<IUserAggregate>(privateId, publicId);
        }
    }
}
