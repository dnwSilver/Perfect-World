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
    public readonly partial struct Result : IEquatable<Result>
    {
        /// <summary>
        ///     Признак успешности выполнения метода.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        ///     Список описаний ошибок, возникших при выполнении метода.
        ///     Заполняется только в случае неудачи при выполнении метода.
        /// </summary>
        public IEnumerable<IResultError> Errors { get; }

        /// <summary>
        ///     Признак не успешности выполнения метода.
        /// </summary>
        public bool Failure => !this.Success;

        /// <summary>
        ///     Конструктор для объекта <see cref="Result" />.
        /// </summary>
        /// <param name="success">Признак успешности выполнения метода.</param>
        /// <param name="errors">Набор ошибок.</param>
        internal Result(bool success, IEnumerable<IResultError> errors)
        {
            this.Success = success;
            this.Errors = errors;
        }

        /// <summary>
        ///     Конструктор для объекта <see cref="Result" />.
        /// </summary>
        /// <param name="success">Признак успешности выполнения метода.</param>
        /// <param name="resultError">Ошибка.</param>
        internal Result(bool success, IResultError resultError)
        {
            this.Success = success;
            this.Errors = resultError.Yield();
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
            return this.Success == other.Success && this.Errors.SequenceEqual(other.Errors);
        }

        /// <summary>
        ///     Сравнение двух объектов по основным полям.
        /// </summary>
        /// <param name="obj">Другой объект для сравнивания.</param>
        /// <returns>
        ///     <see langword="true" /> - Объекты равны.
        ///     <see langword="false" /> - Объекты не равны.
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            return obj is Result result && this.Equals(result);
        }

        /// <summary>
        ///     Переопределите метод GetHashCode, чтобы тип правильно работал в хэш-таблице.
        /// </summary>
        /// <returns>Значение хэш-кода.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Success.GetHashCode() * 397) ^ (this.Errors?.GetHashCode() ?? 0);
            }
        }

        /// <summary>
        ///     Приведение текстовой ошибки к формату <see cref="string" />.
        /// </summary>
        /// <returns> Текстовое значение ошибки, если оно есть. </returns>
        public override string ToString()
        {
            return this.Success ? string.Empty : this.Format(new ResultFormatProvider());
        }
    }
}
