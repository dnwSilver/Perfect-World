using Prosolve.MicroService.Watcher.Domain.ProcessTypes;

using Sharpdev.SDK.Layers.Domain.Factories;

namespace Prosolve.MicroService.Watcher.Domain.Processes
{
    /// <summary>
    ///     Строитель для объекта <see cref="IProcessEntity" />.
    /// </summary>
    public sealed class ProcessBuilder : EntityBuilderBase<IProcessEntity>, IProcessBuilder
    {
        /// <summary>
        ///     Наименование процесса.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     Тип процесса.
        /// </summary>
        public IProcessType Type { get; private set; }

        /// <summary>
        ///     Присвоение типа процессу.
        /// </summary>
        /// <param name="processType">Тип процесса.</param>
        /// <returns>Строитель для объекта <see cref="IProcessEntity" />.</returns>
        public ProcessBuilder SetType(IProcessType processType)
        {
            this.Type = processType;

            return this;
        }

        /// <summary>
        ///     Присвоение наименования процессу.
        /// </summary>
        /// <param name="name">Наименование процесса.</param>
        /// <returns>Строитель для объекта <see cref="IProcessEntity" />.</returns>
        public ProcessBuilder SetName(string name)
        {
            this.Name = name;

            return this;
        }
    }
}
