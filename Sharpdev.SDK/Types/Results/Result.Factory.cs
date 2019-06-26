using System.Linq;

namespace Sharpdev.SDK.Types.Results
{
    public readonly partial struct Result
    {
        /// <summary>
        ///     Создание удачного результата работы метода, не возвращающего значение.
        /// </summary>
        /// <returns>Удачный результат работы метода.</returns>
        public static Result Ok()
        {
            return new Result(true, Enumerable.Empty<IResultError>());
        }

        /// <summary>
        ///     Создание удачного результата работы метода, не возвращающего значение.
        /// </summary>
        /// <param name="data">Данные-результат работы метода.</param>
        /// <typeparam name="T">Тип данных-результата работы метода.</typeparam>
        /// <returns>Удачный результат работы метода.</returns>
        public static Result<T> Ok<T>(T data)
        {
            return new Result<T>(data, true, Enumerable.Empty<IResultError>());
        }

        /// <summary>
        /// Создание неудачного результата работы метода, не возвращающего значение
        /// </summary>
        /// <param name="resultError">Описание ошибки</param>
        /// <returns>Неудачный результат работы метода</returns>
        public static Result Fail(IResultError resultError)
        {
            return new Result(false, resultError);
        }
    }
}
