using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;

namespace Prosolve.MicroService.Watcher.Domain
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
