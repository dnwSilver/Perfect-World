using System.Runtime.CompilerServices;

using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;

[assembly: InternalsVisibleTo("Prosolve.Services.Identification.UnitTest")]

namespace Prosolve.Services.Identification
{
    public static class IdentificationConfiguration
    {
        //todo инициализация мапперов получается одинаковой... надо убрать дубли кода.
        public static IMapper Mapper
        {
            get
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddExpressionMapping();
                    cfg.AddMaps(typeof(IdentificationConfiguration).Assembly);
                    cfg.EnableNullPropagationForQueryMapping = true;
                });
                config.AssertConfigurationIsValid();

                return config.CreateMapper();
            }
        }
    }
}
