using Sharpdev.SDK.Domain;

namespace Prosolve.Services.Watcher.Domain.Processes
{
    /// <summary>
    ///     Процесс протекающий в информационной системе.
    /// </summary>
    public interface IProcessAggregate : IAggregate<IProcessAggregate>
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
