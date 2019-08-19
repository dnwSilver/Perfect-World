namespace Sharpdev.SDK.Infrastructure.Repositories
{
    /// <summary>
    ///     Объект находится под контролем версий объекта. Начальное значение 1. Шаг 1.
    /// </summary>
    public interface IVersioned
    {
        /// <summary>
        ///     Версия объекта. Начальное значение 1. Шаг 1.
        /// </summary>
        int CurrentVersion { get; }
    }
}
