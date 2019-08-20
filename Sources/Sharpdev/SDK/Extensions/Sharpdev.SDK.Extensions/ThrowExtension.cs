using System;
using System.Text;

namespace Sharpdev.SDK.Extensions
{
    /// <summary>
    ///     Набор расширений для работы с ошибками.
    /// </summary>
    public static class ThrowExtension
    {
        /// <summary>
        ///     Преобразование исключения с его внутренними исключениями в строку.
        /// </summary>
        /// <param name="ex">Исключение.</param>
        /// <returns></returns>
        public static string ToStringWithInnerExceptions(this Exception ex)
        {
            var sb = new StringBuilder();
            sb.Append(ex);

            var inner = ex.InnerException;

            while(inner != null)
            {
                sb.Append("\n===INNER EXCEPTION===\n");
                sb.Append(inner);
                inner = inner.InnerException;
            }

            return sb.ToString();
        }
    }
}
