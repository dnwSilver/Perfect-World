using System;

namespace Sharpdev.SDK.Layers.Kernel
{
    /// <summary>
    ///     Набор функциональности для определения подтверждений какой-либо информации.
    /// </summary>
    public interface IConfirmed<TConfirmedObject> : IEquatable<TConfirmedObject>
        where TConfirmedObject : struct
    {
        /// <summary>
        ///     Признак подтверждёнными информации (<see cref="TConfirmedObject" />).
        /// </summary>
        bool IsConfirmed { get; }

        /// <summary>
        ///     Дата подтверждения информации (<see cref="TConfirmedObject" />).
        /// </summary>
        DateTime ConfirmedDate { get; }
    }
}
