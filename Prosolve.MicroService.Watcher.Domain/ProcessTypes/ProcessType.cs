using Sharpdev.SDK.Layers.Domain.Entities;

namespace Prosolve.MicroService.Watcher.Domain.ProcessTypes
{
    /// <summary>
    ///     Тип процесса.
    /// </summary>
    /// <remarks>
    ///     Бизнес-процесс — это логическая последовательность действий человека (или нескольких человек) в коллективе. Цель
    ///     описания бизнес-процесса – анализ и регламентация тех или иных действий в коллективе (см. habr.com).
    ///     Технологический процесс — совокупность методов и средств, предназначенная для реализации системы или систем,
    ///     позволяющих осуществлять управление самим технологическим процессом без непосредственного участия человека.
    /// </remarks>
    public sealed class ProcessType : Entity<IProcessType>, IProcessType
    {
        /// <summary>
        ///     Конструктор для объекта <see cref="ProcessType" />.
        /// </summary>
        /// <param name="identifier">Уникальный идентификатор объекта.</param>
        /// <param name="currentVersion">Версия объекта.</param>
        /// <param name="name">Наименование типа процесса.</param>
        internal ProcessType(IIdentifier<IProcessType> identifier, int currentVersion, string name)
            : base(identifier, currentVersion)
        {
            this.Name = name;
        }

        /// <summary>
        ///     Наименование типа процесса.
        /// </summary>
        public string Name { get; }
    }
}
