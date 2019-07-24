using Prosolve.MicroService.Watcher.Domain.ProcessTypes;

using Sharpdev.SDK.Layers.Domain.Entities;

namespace Prosolve.MicroService.Watcher.Domain.Processes
{
    /// <summary>
    ///     Процесс протекащий в информационной системе.
    /// </summary>
    public interface IProcessEntity : IEntity<IProcessEntity>
    {
        /// <summary>
        ///     Наименование процесса.
        /// </summary>
        string Name { get; }
        

        /// <summary>
        ///     Тип процесса: бизнес процесс или технологический процесс.
        /// </summary>
        IProcessType Type { get; }
    }
}
