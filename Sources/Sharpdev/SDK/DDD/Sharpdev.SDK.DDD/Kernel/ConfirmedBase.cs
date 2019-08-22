using System;

namespace Sharpdev.SDK.Kernel
{
    /// <summary>
    ///     Объект бизнес логики, который содержит в себе процедуру подтверждения. Это могут быть
    ///     номер телефонов или электронные адреса.
    /// </summary>
    /// <typeparam name="TConfirmedObject">Объект бизнес логики.</typeparam>
    public class ConfirmedBase<TConfirmedObject> : IConfirmed<TConfirmedObject>
        where TConfirmedObject : struct
    {
        /// <summary>
        ///     Инициализация объекта бизнес логики.
        /// </summary>
        /// <param name="confirmedObjectValue"></param>
        /// <param name="confirmedDate"></param>
        public ConfirmedBase(TConfirmedObject confirmedObjectValue, DateTime? confirmedDate = null)
        {
            this.Value = confirmedObjectValue;

            if (confirmedDate != null)
            {
                this.ConfirmedDate = confirmedDate;
                this.IsConfirmed = true;
            }
        }

        /// <summary>
        ///     Значение объект бизнес логики.
        /// </summary>
        public TConfirmedObject Value { get; }

        /// <summary>
        ///     Признак подтверждения объект бизнес логики (<see cref="TConfirmedObject" />).
        /// </summary>
        public bool IsConfirmed { get; }

        /// <summary>
        ///     Дата подтверждения объект бизнес логики (<see cref="TConfirmedObject" />).
        /// </summary>
        public DateTime? ConfirmedDate { get; }

        /// <summary>Указывает, равен ли текущий объект другому объекту того же типа.</summary>
        /// <param name="other">Объект для сравнения с этим объектом.</param>
        /// <returns>
        ///     <see langword="true" /> если текущий объект равен <paramref name="other" /> параметр; иначе,
        ///     <see langword="false" />.
        /// </returns>
        public bool Equals(TConfirmedObject other)
        {
            return other.Equals(this.Value);
        }
    }
}
