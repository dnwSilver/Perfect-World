using System;

namespace Sharpdev.SDK.Infrastructure.Statuses
{
    /// <summary>
    ///     Наличие состояния у объекта.
    /// </summary>
    public interface IHasStatus<TStatusEnum>
        where TStatusEnum : Enum
    {
        /// <summary>
        ///     Текущий статус объекта.
        /// </summary>
        /// <returns>Статус объекта.</returns>
        TStatusEnum Status { get; }

        /// <summary>
        ///     Смена статуса.
        /// </summary>
        /// <param name="newStatus">Новый статус.</param>
        void ChangeStatus(TStatusEnum newStatus);
    }
}
