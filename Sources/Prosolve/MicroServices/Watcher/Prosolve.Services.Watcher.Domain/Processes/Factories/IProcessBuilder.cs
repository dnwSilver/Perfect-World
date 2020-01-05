using Sharpdev.SDK.Domain.Factories;

namespace Prosolve.Services.Watcher.Domain.Processes.Factories
{
    /// <summary>
    ///     Строитель для объекта <see cref="IProcessAggregate" />.
    /// </summary>
    public interface IProcessBuilder : IEntityBuilder<IProcessAggregate>
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
