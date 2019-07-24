using Prosolve.MicroService.Watcher.Domain.ProcessTypes;

using Sharpdev.SDK.Layers.Domain.Entities;

namespace Prosolve.MicroService.Watcher.Domain.Processes
{
    /// <summary>
    ///     Процесс протекащий в информационной системе.
    /// </summary>
    public sealed class ProcessEntity : Entity<IProcessEntity>, IProcessEntity
    {
        /// <summary>
        ///     Инициализация процесса.
        /// </summary>
        /// <param name="processBuilder">Сторитель для объекта <see cref="ProcessEntity" />.</param>
        internal ProcessEntity(IProcessBuilder processBuilder)
            : base(processBuilder.Identifier, processBuilder.Version)
        {
            this.Name = processBuilder.Name;
            this.Type = processBuilder.Type;
        }

        /// <summary>
        ///     Наименование процесса.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Тип процесса: бизнес процесс или технологический процесс.
        /// </summary>
        public IProcessType Type { get; }
    }
}
