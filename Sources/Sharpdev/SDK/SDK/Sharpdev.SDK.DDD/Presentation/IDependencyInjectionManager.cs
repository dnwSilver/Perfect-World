namespace Sharpdev.SDK.Presentation
{
    /// <summary>
    ///     Менеджер для управления процессом предоставления внешней зависимости.
    /// </summary>
    public interface IDependencyInjectionManager
    {
        /// <summary>
        ///     Настройка процесса предоставления внешней зависимости.
        /// </summary>
        void Configure();
    }
}
