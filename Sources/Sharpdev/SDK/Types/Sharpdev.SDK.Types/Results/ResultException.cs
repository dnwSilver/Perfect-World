using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sharpdev.SDK.Types.Results
{
    /// <summary>
    ///     Создание исключения из Result (<see cref="Result" />).
    /// </summary>
    [DataContract]
    public sealed class ResultException : Exception
    {
        /// <summary>
        ///     Создание исключения из Result (<see cref="Result" />).
        /// </summary>
        /// <param name="result">Результат работы метода.</param>
        /// <param name="delimiter">Строка-разделитель для соединения списка ошибок.</param>
        public ResultException(Result result, string delimiter = "\n")
            : base(result.ToString(delimiter))
        {
            Errors = result.Errors;
        }

        /// <summary>
        ///     Создание исключения из Result (<see cref="Result" />).
        /// </summary>
        /// <param name="result">Результат работы метода.</param>
        /// <param name="errorsToString">Делегат преобразования списка ошибок в одну строку.</param>
        public ResultException(Result result,
                               Func<IEnumerable<IFormattable>, string> errorsToString)
            : base(result.ToString(errorsToString))
        {
            Errors = result.Errors;
        }

        /// <summary>
        ///     Список описаний ошибок, возникших при выполнении метода.
        /// </summary>
        [DataMember(Name = nameof(Errors))]
        public IEnumerable<IFormattable> Errors { get; }
    }
}
