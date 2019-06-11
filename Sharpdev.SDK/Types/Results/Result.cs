using System;
using System.Collections.Generic;
using System.Linq;

using Sharpdev.SDK.Extensions;

namespace Sharpdev.SDK.Types.Results
{
    /// <summary>
    ///     Результат выполнения метода, не возвращающего данные (void).
    /// </summary>
    /// <remarks>
    ///     <see href="https://habr.com/ru/post/347284/" />
    /// </remarks>
    public readonly struct Result : IEquatable<Result>
    {
        /// <summary>
        ///     Признак успешности выполнения метода.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        ///     Список описаний ошибок, возникших при выполнении метода.
        ///     Заполняется только в случае неудачи при выполнении метода.
        /// </summary>
        public IEnumerable<IError> Errors { get; }

        /// <summary>
        ///     Признак не успешности выполнения метода.
        /// </summary>
        public bool Failure => !Success;

        /// <summary>
        ///     Конструктор для объекта <see cref="Result" />.
        /// </summary>
        /// <param name="success">Признак успешности выполнения метода.</param>
        /// <param name="errors">Набор ошибок.</param>
        internal Result(bool success, IEnumerable<IError> errors)
        {
            Success = success;
            Errors = errors;
        }

        /// <summary>
        ///     Конструктор для объекта <see cref="Result" />.
        /// </summary>
        /// <param name="success">Признак успешности выполнения метода.</param>
        /// <param name="error">Ошибка.</param>
        internal Result(bool success, IError error)
        {
            Success = success;
            Errors = error.Yield();
        }

        /// <summary>
        ///     Сравнение двух объектов по основным полям.
        /// </summary>
        /// <param name="other">Другой объект для сравнивания.</param>
        /// <returns>
        ///     <see langword="true" /> - Объекты равны.
        ///     <see langword="false" /> - Объекты не равны.
        /// </returns>
        public bool Equals(Result other)
        {
            return Success == other.Success && Errors.SequenceEqual(other.Errors);
        }

        /// <summary>
        ///     Сравнение двух объектов по основным полям.
        /// </summary>
        /// <param name="obj">Другой объект для сравнивания.</param>
        /// <returns>
        ///     <see langword="true" /> - Объекты равны.
        ///     <see langword="false" /> - Объекты не равны.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            return obj is Result result && Equals(result);
        }

        /// <summary>
        ///     Переопределите метод GetHashCode, чтобы тип правильно работал в хэш-таблице.
        /// </summary>
        /// <returns>Значение хэш-кода.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Success.GetHashCode() * 397) ^ (Errors?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        ///     Приведение текстовой ошибки к формату <see cref="string" />.
        /// </summary>
        /// <returns> Текстовое значение ошибки, если оно есть. </returns>
        public override string ToString()
        {
            return Success ? string.Empty : this.Format(new ResultFormatProvider());
        }
    }
}
