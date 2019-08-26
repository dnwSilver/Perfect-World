﻿using System;

using AutoMapper;

using Prosolve.Services.Identification.Users.DataSources;
using Prosolve.Services.Identification.Users.Factories;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;

namespace Prosolve.Services.Identification.Users
{
    /// <summary>
    ///     Класс для сопоставление полей объекта <see cref="IUserEntity" />.
    /// </summary>
    public sealed class UserMapper : Profile
    {
        /// <summary>
        ///     Метод для определения наименования конечного свойства.
        /// </summary>
        /// <returns>Конечное наименование свойства.</returns>
        public UserMapper()
        {
            this.CreateMap<IUserEntity, UserDataModel>()
                .ForMember(d => d.PrivateId, o => o.MapFrom(s => s.Id.Private))
                .ForMember(d => d.PublicId, p => p.MapFrom(s => s.Id.Public))
                .ForMember(d => d.FirstName, p => p.MapFrom(s => s.FullName.FirstName))
                .ForMember(d => d.MiddleName, p => p.MapFrom(s => s.FullName.Patronymic))
                .ForMember(d => d.Surname, p => p.MapFrom(s => s.FullName.Surname))
                .ForMember(d => d.EmailAddress, o=> o.MapFrom(s =>s.ContactEmail.Value))
                .ForMember(d => d.EmailAddressConfirmDate, o=> o.MapFrom(s =>s.ContactEmail.ConfirmedDate))
                .ForMember(d => d.PhoneNumber, o=> o.MapFrom(s =>s.ContactPhoneNumber.Value))
                .ForMember(d => d.PhoneNumberConfirmDate, o=> o.MapFrom(s =>s.ContactPhoneNumber.ConfirmedDate))
                .ForMember(d => d.Version, o=> o.MapFrom(s =>s.CurrentVersion))
                .ReverseMap()
                .ForAllOtherMembers(x => x.Ignore());
            
            this.CreateMap<UserDataModel, IUserBuilder>()
                .ForMember(d => d.Identifier, o => o.MapFrom(s => this.Id(s.PrivateId, s.PublicId)))
                .ForMember(d => d.ContactEmailAddress, o => o.MapFrom(s => new ConfirmedBase<EmailAddress>(s.EmailAddress, null)))
                .ReverseMap()
                .ForAllOtherMembers(x => x.Ignore());
        }

        private Identifier<IUserEntity> Id(int privateId, Guid publicId) =>
            new Identifier<IUserEntity>(privateId, publicId);
    }
}
