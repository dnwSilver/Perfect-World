using System.Collections.Generic;
using System.Linq;

namespace Sharpdev.SDK.Types.Results
{
    public readonly partial struct Result
    {
        /// <summary>
        ///     Создание удачного результата работы метода, не возвращающего значение.
        /// </summary>
        /// <returns>Удачный результат работы метода.</returns>
        public static Result Done()
        {
            return new Result(true, Enumerable.Empty<IResultError>());
        }

        /// <summary>
        ///     Создание удачного результата работы метода, не возвращающего значение.
        /// </summary>
        /// <param name="data">Данные-результат работы метода.</param>
        /// <typeparam name="T">Тип данных-результата работы метода.</typeparam>             
        /// <returns>Удачный результат работы метода.</returns>
        public static Result<T> Done<T>(T data)
        {
            return new Result<T>(data, true, Enumerable.Empty<IResultError>());
        }

        /// <summary>
        ///     Создание неудачного результата работы метода, не возвращающего значение.
        /// </summary>
        /// <param name="resultError">Описание ошибки.</param>
        /// <returns>Неудачный результат работы метода.</returns>
        public static Result Fail(IResultError resultError)
        {
            return new Result(false, resultError);
        }

        /// <summary>
        ///     Создание неудачного результата работы метода, не возвращающего значение.
        /// </summary>
        /// <param name="resultError">Описание ошибки.</param>
        /// <returns>Неудачный результат работы метода.</returns>
        public static Result Fail(string resultError)
        {
            return new Result(false, TextResultError.Create(resultError));
        }

        /// <summary>
        ///     Создание неудачного результата работы метода, возвращающего значение
        /// </summary>
        /// <param name="errorMessage">Описание ошибки.</param>
        /// <typeparam name="T">Тип данных-результата работы метода.</typeparam>
        /// <returns>Неудачный результат работы метода.</returns>
        public static Result<T> Fail<T>(string errorMessage)
        {
            return new Result<T>(default!, false, TextResultError.Create(errorMessage));
        }

        /// <summary>
        ///     Создание неудачного результата работы метода, не возвращающего значение.
        /// </summary>
        /// <param name="errors">Список описаний ошибок.</param>
        /// <returns>Неудачный результат работы метода.</returns>
        public static Result Fail(IEnumerable<IResultError> errors)
        {
            return new Result(false, errors);
        }

        /// <summary>
        /// Создание неудачного результата работы метода, возвращающего значение.
        /// </summary>
        /// <param name="errors">Список описаний ошибок.</param>
        /// <typeparam name="T">Тип данных-результата работы метода.</typeparam>
        /// <returns>Неудачный результат работы метода.</returns>
        public static Result<T> Fail<T>(IEnumerable<IResultError> errors)
        {
            return new Result<T>(default!, false, errors);
        }

    }
}
