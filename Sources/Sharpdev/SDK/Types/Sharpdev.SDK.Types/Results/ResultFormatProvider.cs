using System;

using Sharpdev.SDK.Extensions;

namespace Sharpdev.SDK.Types.Results
{
    /// <summary>
    ///     Стандартный механизм для управления форматом для <see cref="Result" />.
    /// </summary>
    public sealed class ResultFormatProvider : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        ///     Приводим аргумент к необходимому формату.
        /// </summary>
        /// <param name="format">Формат, к которому необходимо привести аргумент.</param>
        /// <param name="arg">Аргумент.</param>
        /// <param name="formatProvider">Провайдер.</param>
        /// <returns> Текстовое значение ошибки, если оно есть. </returns>
        public string Format(string? format, object? arg, IFormatProvider? formatProvider)
        {
            if (formatProvider!.Check(x=>x.Equals(this)).ReturnFailure())
                return string.Empty;

            if (arg is Exception exception)
                return exception.ToStringWithInnerExceptions();

            return string.Empty;
        }

        /// <summary>
        ///     Провайдер, который предоставляет форматирование.
        /// </summary>
        /// <param name="formatType">Формат.</param>
        /// <returns>Провайдер.</returns>
        public object? GetFormat(Type? formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : default;
        }
    }
}
