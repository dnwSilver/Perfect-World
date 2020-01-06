using System;

namespace Sharpdev.SDK.Infrastructure.Statuses
{
    /// <summary>
    ///     Базовый класс реализующий хранение и наличие статуса.
    /// </summary>
    public abstract class HasStatusBase<TStatusEnum>: IHasStatus<TStatusEnum>
            where TStatusEnum: Enum
    {
        /// <summary>
        ///     Инициализация объекта <see cref="HasStatusBase{TStatusEnum}"/>.
        /// </summary>
        /// <param name="status"> Стартовое состояние объекта. </param>
        protected HasStatusBase(TStatusEnum status)
        {
            Status = status;
        }

        /// <summary>
        ///     Текущий статус объекта.
        /// </summary>
        public TStatusEnum Status { get; private set; }

        /// <summary>
        ///     Изменение статуса.
        /// </summary>
        /// <param name="newStatus"> Новое состояние статуса. </param>
        public void ChangeStatus(TStatusEnum newStatus)
        {
            // todo Написать механизм для хранения и управления автоматами состояния.
            Status = newStatus;
        }
    }
}
