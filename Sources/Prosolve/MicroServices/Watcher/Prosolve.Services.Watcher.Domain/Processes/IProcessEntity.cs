using Sharpdev.SDK.Domain.Entities;

namespace Prosolve.Services.Watcher.Domain.Processes
{
    /// <summary>
    ///     Процесс протекающий в информационной системе.
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
        string TypeName { get; }
    }
}
