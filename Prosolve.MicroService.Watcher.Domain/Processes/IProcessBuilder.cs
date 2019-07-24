using Prosolve.MicroService.Watcher.Domain.ProcessTypes;

using Sharpdev.SDK.Layers.Domain.Factories;

namespace Prosolve.MicroService.Watcher.Domain.Processes
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
        IProcessType Type { get; }

        /// <summary>
        ///     Присвоение типа процессу.
        /// </summary>
        /// <param name="processType">Тип процесса.</param>
        /// <returns>Строитель для объекта <see cref="ProcessEntity" />.</returns>
        ProcessBuilder SetType(IProcessType processType);

        /// <summary>
        ///     Присвоение наименования процессу.
        /// </summary>
        /// <param name="name">Наименование процесса.</param>
        /// <returns>Строитель для объекта <see cref="ProcessEntity" />.</returns>
        ProcessBuilder SetName(string name);
    }
}
