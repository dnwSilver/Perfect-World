using Prosolve.Services.Watcher.Domain.Processes.Factories;

using Sharpdev.SDK.Domain.Entities;

namespace Prosolve.Services.Watcher.Domain.Processes
{
    /// <summary>
    ///     Процесс протекающий в информационной системе.
    /// </summary>
    public sealed class ProcessAggregate : Entity<IProcessAggregate>, IProcessAggregate
    {
        /// <summary>
        ///     Инициализация процесса.
        /// </summary>
        /// <param name="processBuilder">Строитель для объекта <see cref="ProcessAggregate" />.</param>
        internal ProcessAggregate(IProcessBuilder processBuilder)
            : base(processBuilder.Identifier, processBuilder.Version)
        {
            Name = processBuilder.Name;
            TypeName = processBuilder.TypeName;
        }

        /// <summary>
        ///     Наименование процесса.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Тип процесса: бизнес процесс или технологический процесс.
        /// </summary>
        public string TypeName { get; }

        public IProcessAggregate RootEntity { get; }
    }
}
