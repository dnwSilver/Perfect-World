using Prosolve.Services.Watcher.Domain.Processes.Factories;

using Sharpdev.SDK.Domain.Entities;

namespace Prosolve.Services.Watcher.Domain.Processes
{
    /// <summary>
    ///     Процесс протекающий в информационной системе.
    /// </summary>
    public sealed class ProcessEntity : Entity<IProcessEntity>, IProcessEntity
    {
        /// <summary>
        ///     Инициализация процесса.
        /// </summary>
        /// <param name="processBuilder">Строитель для объекта <see cref="ProcessEntity" />.</param>
        internal ProcessEntity(IProcessBuilder processBuilder)
            : base(processBuilder.Identifier, processBuilder.Version)
        {
            this.Name = processBuilder.Name;
            this.TypeName = processBuilder.TypeName;
        }

        /// <summary>
        ///     Наименование процесса.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Тип процесса: бизнес процесс или технологический процесс.
        /// </summary>
        public string TypeName { get; }
    }
}
