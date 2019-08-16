using System;

namespace Sharpdev.SDK.Layers.Kernel
{
    /// <summary>
    ///     Объект бизнес логики, который содержит в себе процедуру подтверждения. Это могут быть
    ///     номер телефонов или электронные адреса.
    /// </summary>
    /// <typeparam name="TConfirmedObject">Объект бизнес логики.</typeparam>
    public interface IConfirmed<TConfirmedObject> : IEquatable<TConfirmedObject>
        where TConfirmedObject : struct
    {
        /// <summary>
        ///     Значение объект бизнес логики.
        /// </summary>
        TConfirmedObject Value { get; }

        /// <summary>
        ///     Признак подтверждения объект бизнес логики (<see cref="TConfirmedObject" />).
        /// </summary>
        bool IsConfirmed { get; }

        /// <summary>
        ///     Дата подтверждения объект бизнес логики (<see cref="TConfirmedObject" />).
        /// </summary>
        DateTime? ConfirmedDate { get; }
    }
}
