using Sharpdev.SDK.Domain.Factories;

namespace Prosolve.Services.Watcher.Domain.Processes.Factories
{
    /// <summary>
    ///     Строитель для объекта <see cref="IProcessEntity" />.
    /// </summary>
    public interface IProcessBuilder : IEntityBuilder<IProcessEntity>
    {
        /// <summary>
        ///     Наименование процесса.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Тип процесса.
        /// </summary>
        string TypeName { get; }
    }
}
