namespace Sharpdev.SDK.Layers.Application
{
    /// <summary>
    /// Набор конфигурационных методов для настройки доменной области.
    /// </summary>
    public interface IConfigurationDomain
    {
        /// <summary>
        /// Настройки мапперов.
        /// </summary>
        void MapperConfigure();
    }
}
