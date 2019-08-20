using System.Runtime.CompilerServices;

using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;

[assembly: InternalsVisibleTo("Prosolve.Services.Watcher.UnitTest")]

namespace Prosolve.Services.Watcher.Domain
{
    public static class WatcherConfiguration
    {
        public static IMapper Mapper
        {
            get
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddExpressionMapping();
                    cfg.AddMaps(typeof(WatcherConfiguration).Assembly);
                    cfg.EnableNullPropagationForQueryMapping = true;
                });
                config.AssertConfigurationIsValid();

                return config.CreateMapper();
            }
        }
    }
}
