using System;

namespace Sharpdev.SDK.Extensions
{
    /// <summary>
    ///     Набор расширений заимствованных из функционального программирования. Монады.
    ///     Используем данные методы чтобы избавиться от проверок на null в нашем коде.
    /// </summary>
    /// <remarks>
    ///     <see href="https://www.youtube.com/watch?time_continue=452&v=-bMPUBPwtSg">Урок</see>.
    /// </remarks>
    public static class MayBy
    {
        /// <summary>
        ///     Проверка объекта на null.
        /// </summary>
        /// <typeparam name="TInput">Входное значение.</typeparam>
        /// <typeparam name="TResult">Выходное значение.</typeparam>
        /// <param name="o">Проверяемый объект.</param>
        /// <param name="evaluator">Функция для вычисления выходного значения.</param>
        /// <returns>
        ///     В случае если объект не существует вернётся null. В противном случае будет
        ///     вычислено выходное значение при помощи функции evaluator.
        /// </returns>
        public static TResult With<TInput, TResult>(this TInput o, Func<TInput, TResult> evaluator)
            where TInput : class
            where TResult : class
        {
            return o == null ? null : evaluator(o);
        }

        /// <summary>
        ///     Проверка объекта на null, в случае отсутствия объекта заменяем его на другое
        ///     значение.
        /// </summary>
        /// <typeparam name="TInput">Входное значение.</typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="o">Проверяемый объект.</param>
        /// <param name="evaluator">Функция для вычисления выходного значения.</param>
        /// <param name="failureValue">Альтернативное значение.</param>
        /// <returns>
        ///     В случае если объект не существует вернётся альтернативное значение.
        ///     В противном случае будет вычислено выходное значение при помощи функции evaluator.
        /// </returns>
        public static TResult Return<TInput, TResult>(this TInput o,
                                                      Func<TInput, TResult> evaluator,
                                                      TResult failureValue)
        {
            return o == null ? failureValue : evaluator(o);
        }

        /// <summary>
        ///     Проверка существования объекта.
        /// </summary>
        /// <typeparam name="TInput">Входное значение.</typeparam>
        /// <param name="o">Проверяемый объект.</param>
        /// <returns>
        ///     <see langword="true" /> - если объект существует.
        ///     <see langword="false" /> - если объект не существует.
        /// </returns>
        public static bool ReturnSuccess<TInput>(this TInput o)
            where TInput : class
        {
            return o != null;
        }

        /// <summary>
        ///     Проверка существования объекта.
        /// </summary>
        /// <typeparam name="TInput">Входное значение.</typeparam>
        /// <param name="o">Проверяемый объект.</param>
        /// <returns>
        ///     <see langword="true" /> - если объект не существует.
        ///     <see langword="false" /> - если объект существует.
        /// </returns>
        public static bool ReturnFailure<TInput>(this TInput o)
            where TInput : class
        {
            return o == null;
        }

        /// <summary>
        ///     Проверка выполнения условия на выбранном объекте.
        /// </summary>
        /// <typeparam name="TInput">Входное значение.</typeparam>
        /// <param name="o">Проверяемый объект.</param>
        /// <param name="evaluator">Условие для выходного значения.</param>
        /// <returns>
        ///     В случае если объект не существует вернётся альтернативное значение.
        ///     В противном случае будет вычислено выходное значение при помощи функции evaluator.
        /// </returns>
        public static TInput If<TInput>(this TInput o, Predicate<TInput> evaluator)
            where TInput : class
        {
            if (o == null)
                return null;

            return evaluator(o) ? o : null;
        }

        /// <summary>
        ///     Выполнение метода.
        /// </summary>
        /// <typeparam name="TInput">Входное значение.</typeparam>
        /// <param name="o">Проверяемый объект.</param>
        /// <param name="action">Выполняемый метод. Входной параметр - проверяемый объект.</param>
        /// <returns>Проверяемый объект.</returns>
        public static TInput Do<TInput>(this TInput o, Action<TInput> action)
            where TInput : class
        {
            if (o == null)
                return null;
            action(o);

            return o;
        }
    }
}
