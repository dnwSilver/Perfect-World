using System;

using AutoMapper;

using Prosolve.Services.Watcher.Domain.Processes.DataSources;
using Prosolve.Services.Watcher.Domain.Processes.Factories;

using Sharpdev.SDK.Domain.Entities;

namespace Prosolve.Services.Watcher.Domain.Processes
{
    /// <summary>
    ///     Класс для сопоставление полей объекта <see cref="IProcessEntity" />.
    /// </summary>
    public sealed class ProcessMapper : Profile
    {
        /// <summary>
        ///     Метод для определения наименования конечного свойства.
        /// </summary>
        /// <returns>Конечное наименование свойства.</returns>
        public ProcessMapper()
        {
            this.CreateMap<IProcessEntity, ProcessDataModel>()
                .ForMember(d => d.PrivateId, o => o.MapFrom(s => s.Id.Private))
                .ForMember(d => d.PublicId, p => p.MapFrom(s => s.Id.Public))
                .ForMember(d => d.TypeName, o=> o.MapFrom(s =>s.TypeName))
                .ForMember(d => d.Version, o=> o.MapFrom(s =>s.CurrentVersion)).ReverseMap();

            this.CreateMap<ProcessDataModel, IProcessBuilder>()
                .ForMember(d => d.Identifier, o => o.MapFrom(s => this.Id(s.PrivateId, s.PublicId)))
                .ForMember(d => d.TypeName, o => o.MapFrom(s => s.TypeName)).ReverseMap();
        }

        private Identifier<IProcessEntity> Id(int privateId, Guid publicId) =>
            new Identifier<IProcessEntity>(privateId, publicId);
    }
}
