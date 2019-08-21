using Sharpdev.SDK.Domain.Factories;

namespace Prosolve.Services.Watcher.Domain.Processes.Factories
{
    /// <summary>
    ///     Строитель для объекта <see cref="IProcessEntity" />.
    /// </summary>
    public sealed class ProcessBuilder : EntityBuilderBase<IProcessEntity, IProcessBuilder>, IProcessBuilder
    {
        /// <summary>
        ///     Наименование процесса.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Тип процесса.
        /// </summary>
        public string TypeName { get; set; }
    }
}
