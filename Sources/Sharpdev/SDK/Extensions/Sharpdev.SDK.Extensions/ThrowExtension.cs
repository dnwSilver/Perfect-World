using System;
using System.Text;

namespace Sharpdev.SDK.Extensions
{
    public static class ThrowExtension
    {
        /// <summary>
        ///     Вызывает исключение TException, если выполняется условие.
        /// </summary>
        /// <typeparam name="TException">Тип исключения.</typeparam>
        /// <param name="condition">Условие для вызова исключения.</param>
        /// <param name="message">Сообщение.</param>
        public static void If<TException>(bool condition, string message)
            where TException : Exception
        {
            if (condition)
                throw New.Instance<TException, string>(message);
        }

        /// <summary>
        ///     Вызывает исключение <see cref="ArgumentNullException" />, если параметр не указан.
        /// </summary>
        /// <param name="param">Параметр.</param>
        /// <param name="paramName">Название параметра.</param>
        public static void IfNull(object param, string paramName)
        {
            if (param == null)
                throw New.Instance<ArgumentNullException, string>(paramName);
        }

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

        /// <summary>
        ///     Пытается найти исключение определенного типа при помощи рекурсии.
        /// </summary>
        /// <typeparam name="T">Тип искомого исключения.</typeparam>
        /// <param name="ex">Исходное исключение.</param>
        /// <returns></returns>
        public static T FindException<T>(this Exception ex)
        {
            while(true)
            {
                if (ex is T)
                    return (T)(object)ex;

                var inner = ex?.InnerException;

                switch(inner)
                {
                    case null:

                        return default;
                    case T _:

                        return (T)(object)inner;
                    default:
                        ex = inner;

                        break;
                }
            }
        }
    }
}
