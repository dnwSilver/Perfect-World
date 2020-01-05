using Sharpdev.SDK.Domain.Factories;

namespace Prosolve.Services.Watcher.Domain.Processes.Factories
{
    /// <summary>
    ///     Строитель для объекта <see cref="IProcessAggregate" />.
    /// </summary>
    public sealed class ProcessBuilder : EntityBuilderBase<IProcessAggregate>, IProcessBuilder
    {
        /// <summary>
        ///     Наименование процесса.
        /// </summary>
        public string Name { get; set; } = "Не указан";

        /// <summary>
        ///     Тип процесса.
        /// </summary>
        public string TypeName { get; set; } = "Не указан";
    }
}
