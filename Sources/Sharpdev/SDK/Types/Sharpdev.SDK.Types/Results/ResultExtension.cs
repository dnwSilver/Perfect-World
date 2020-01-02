using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sharpdev.SDK.Extensions;

namespace Sharpdev.SDK.Types.Results
{
    /// <summary>
    ///     Набор расширений для интерфейса <see cref="Result" />.
    /// </summary>
    public static class ResultExtension
    {
        /// <summary>
        ///     Разделитель используемый по умолчанию.
        /// </summary>
        private const string DefaultDelimiter = "\n";

        /// <summary>
        ///     Конвертация в строку.
        /// </summary>
        /// <param name="result">Результат выполнения метода, не возвращающего значение.</param>
        /// <param name="formatProvider">Предоставляет механизм извлечения объекта для управления форматированием.</param>
        /// <param name="delimiter">Строка разделения ошибок.</param>
        /// <returns>Строковое представление объекта <see cref="Result" />.</returns>
        public static string ToString(this Result result,
                                      IFormatProvider formatProvider,
                                      string delimiter = DefaultDelimiter)
        {
            if (result.Success)
                return result.Success.ToString();

            return Format(result, formatProvider, delimiter);
        }

        /// <summary>
        ///     Конвертация в строку.
        /// </summary>
        /// <param name="result">Результат выполнения метода, не возвращающего значение</param>
        /// <param name="delimiter">Строка разделения ошибок.</param>
        /// <returns>Строковое представление объекта <see cref="Result" />.</returns>
        public static string ToString(this Result result, string delimiter = DefaultDelimiter)
        {
            if (result.Success)
                return result.Success.ToString();

            return string.Join(delimiter, result.Errors);
        }

        /// <summary>
        ///     Конвертация в строку.
        /// </summary>
        /// <param name="result">Результат выполнения метода, не возвращающего значение.</param>
        /// <param name="errorsToString">Делегат преобразования списка ошибок в одну строку</param>
        /// <returns>Строковое представление объекта <see cref="Result" />.</returns>
        public static string ToString(this Result result, Func<IEnumerable<IFormattable>, string> errorsToString)
        {
            if (result.Success)
                return result.Success.ToString();

            return errorsToString(result.Errors);
        }

        /// <summary>
        ///     Конвертация в строку.
        /// </summary>
        /// <param name="result">Результат выполнения метода, не возвращающего значение.</param>
        /// <param name="formatProvider">Предоставляет механизм извлечения объекта для управления форматированием.</param>
        /// <param name="delimiter">Строка разделения ошибок.</param>
        /// <returns>Строковое представление объекта <see cref="Result" />.</returns>
        public static string? ToString<T>(this Result<T> result,
                                         IFormatProvider formatProvider,
                                         string delimiter = DefaultDelimiter)
        {
            if (result.Success)
                return result.Value?.ToString();

            return Format(result, formatProvider, delimiter);
        }

        /// <summary>
        ///     Конвертация в строку.
        /// </summary>
        /// <param name="result">Результат выполнения метода, не возвращающего значение.</param>
        /// <param name="delimiter">Строка разделения ошибок.</param>
        /// <returns>Строковое представление объекта <see cref="Result" />.</returns>
        public static string? ToString<T>(this Result<T> result, string delimiter = DefaultDelimiter)
        {
            return ToString(result, new ResultFormatProvider(), delimiter);
        }

        /// <summary>
        ///     Конвертация в строку.
        /// </summary>
        /// <param name="result">Результат выполнения метода, не возвращающего значение.</param>
        /// <param name="errorsToString">Делегат преобразования списка ошибок в одну строку.</param>
        /// <returns>Строковое представление объекта <see cref="Result" />.</returns>
        public static string? ToString<T>(this Result<T> result, Func<IEnumerable<IFormattable>, string> errorsToString)
        {
            if (result.Success)
                return result.Value?.ToString();

            return errorsToString(result.Errors);
        }

        /// <summary>
        ///     Форматирует результат выполнения метода, возвращающего значение.
        /// </summary>
        /// <param name="result">Результат выполнения метода, возвращающего значение.</param>
        /// <param name="formatProvider">Предоставляет механизм извлечения объекта для управления форматированием.</param>
        /// <param name="delimiter">Строка разделения ошибок.</param>
        /// <returns>Строковое представление объекта <see cref="Result" />.</returns>
        public static string Format<T>(this Result<T> result,
                                       IFormatProvider formatProvider,
                                       string delimiter = DefaultDelimiter)
        {
            return DoFormat(result, formatProvider, delimiter);
        }

        /// <summary>
        ///     Форматирует результат выполнения метода, не возвращающего значение.
        /// </summary>
        /// <param name="result">Результат выполнения метода, не возвращающего значение.</param>
        /// <param name="formatProvider">Предоставляет механизм извлечения объекта для управления форматированием.</param>
        /// <param name="delimiter">Строка разделения ошибок.</param>
        /// <returns>Строковое представление объекта <see cref="Result" />.</returns>
        public static string Format(this Result result,
                                    IFormatProvider formatProvider,
                                    string delimiter = DefaultDelimiter)
        {
            return DoFormat(result, formatProvider, delimiter);
        }

        /// <summary>
        /// </summary>
        /// <param name="result"></param>
        /// <param name="formatProvider">Предоставляет механизм извлечения объекта для управления форматированием.</param>
        /// <param name="delimiter">Строка разделения ошибок.</param>
        /// <returns>Строковое представление объекта <see cref="Result" />.</returns>
        private static string DoFormat(Result result, IFormatProvider formatProvider, string delimiter)
        {
            if (result.Errors.IsNullOrEmpty())
                return string.Empty;

            // todo вынести в базовый конструктор. Бугаенко будет сильно возмущён такой штукой.
            var sb = new StringBuilder();

            foreach(var error in result.Errors)
            {
                sb.Append(error.ToString(string.Empty, formatProvider));
                sb.Append(delimiter);
            }

            sb.Remove(sb.Length - delimiter.Length, delimiter.Length);

            return sb.ToString();
        }
    }
}
