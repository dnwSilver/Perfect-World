using System;

using AutoMapper;

using Prosolve.Services.Watcher.Domain.Processes.DataSources;
using Prosolve.Services.Watcher.Domain.Processes.Factories;

using Sharpdev.SDK.Domain.Entities;

namespace Prosolve.Services.Watcher.Domain.Processes
{
    /// <summary>
    ///     Класс для сопоставление полей объекта <see cref="IProcessAggregate"/>.
    /// </summary>
    public sealed class ProcessMapper: Profile
    {
        /// <summary>
        ///     Метод для определения наименования конечного свойства.
        /// </summary>
        /// <returns> Конечное наименование свойства. </returns>
        public ProcessMapper()
        {
            CreateMap<IProcessAggregate, ProcessDataModel>()
                   .ForMember(d => d.PrivateId, o => o.MapFrom(s => s.Id.Private))
                   .ForMember(d => d.PublicId, p => p.MapFrom(s => s.Id.Public))
                   .ForMember(d => d.TypeName, o => o.MapFrom(s => s.TypeName))
                   .ForMember(d => d.Version, o => o.MapFrom(s => s.CurrentVersion))
                   .ReverseMap()
                   .ForAllOtherMembers(x => x.Ignore());

            CreateMap<ProcessDataModel, IProcessBuilder>()
                   .ForMember(d => d.Identifier, o => o.MapFrom(s => Identifier(s.PrivateId, s.PublicId)))
                   .ForMember(d => d.TypeName, o => o.MapFrom(s => s.TypeName))
                   .ReverseMap()
                   .ForAllOtherMembers(x => x.Ignore());
        }

        private static Identifier<IProcessAggregate> Identifier(int privateId, Guid publicId)
        {
            return new Identifier<IProcessAggregate>(privateId, publicId);
        }
    }
}
