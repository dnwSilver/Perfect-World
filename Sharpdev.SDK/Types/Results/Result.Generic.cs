﻿using System;
using System.Collections.Generic;
using System.Linq;

using Sharpdev.SDK.Extensions;

namespace Sharpdev.SDK.Types.Results
{
    /// <summary>
    ///     Результат выполнения метода, возвращающего данные (не void).
    /// </summary>
    /// <typeparam name="T">Тип возвращаемых данных</typeparam>
    public readonly struct Result<T> : IEquatable<Result<T>>
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
        ///     Признак не выполнения метода.
        /// </summary>
        public bool Failure => !Success;

        /// <summary>
        ///     Данные-результат работы метода
        ///     Заполняется только в случае успеха при выполнении метода
        /// </summary>
        public T Value { get; }

        /// <summary>
        ///     Создание результата работы метода.
        /// </summary>
        /// <param name="value">Данные-результат работы метода.</param>
        /// <param name="success">Признак успешности выполнения метода.</param>
        /// <param name="errors">Список описаний ошибок, возникших при выполнении метода.</param>
        internal Result(T value, bool success, IEnumerable<IError> errors)
        {
            Success = success;
            Errors = errors;
            Value = value;
        }

        /// <summary>
        ///     Создание результата работы метода.
        /// </summary>
        /// <param name="value">Данные-результат работы метода.</param>
        /// <param name="success">Признак успешности выполнения метода.</param>
        /// <param name="error">Описание ошибки, возникшей при выполнении метода.</param>
        internal Result(T value, bool success, IError error)
        {
            Success = success;
            Errors = error.Yield();
            Value = value;
        }

        /// <summary>
        ///     Определяем данные-результат работы метода как implicit.
        /// </summary>
        /// <param name="result">Данные-результат работы метода.</param>
        /// <returns>Данные-результат работы метода</returns>
        /// <exception cref="InvalidOperationException">
        ///     При попытке получить значение  неудачно завершившегося метода.
        /// </exception>
        public static implicit operator T(Result<T> result)
        {
            if (result.Failure)
                throw new ResultException(result);

            return result.Value;
        }

        /// <summary>
        ///     Определяем конвертацию в <see cref="Result" /> как implicit.
        /// </summary>
        /// <param name="result">Данные-результат работы метода.</param>
        /// <returns>
        ///     <see cref="Result" />
        /// </returns>
        public static implicit operator Result(Result<T> result)
        {
            return new Result(result.Success, result.Errors);
        }

        /// <summary>
        ///     Сравнение двух объектов по основным полям.
        /// </summary>
        /// <param name="other">Другой объект для сравнивания.</param>
        /// <returns>
        ///     <see langword="true" /> - Объекты равны.
        ///     <see langword="false" /> - Объекты не равны.
        /// </returns>
        public bool Equals(Result<T> other)
        {
            return Success == other.Success &&
                   Errors.SequenceEqual(other.Errors) &&
                   EqualityComparer<T>.Default.Equals(Value, other.Value);
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

            return obj is Result<T> result && Equals(result);
        }

        /// <summary>
        ///     Переопределите метод GetHashCode, чтобы тип правильно работал в хэш-таблице.
        /// </summary>
        /// <returns>Значение хэш-кода.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Success.GetHashCode();
                hashCode = (hashCode * 397) ^ (Errors?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ EqualityComparer<T>.Default.GetHashCode(Value);

                return hashCode;
            }
        }

        /// <summary>
        ///     Приведение текстовой ошибки к формату <see cref="string" />.
        /// </summary>
        /// <returns> Текстовое значение ошибки, если оно есть. </returns>
        public override string ToString()
        {
            return Success ? Value.ToString() : this.Format(new ResultFormatProvider());
        }
    }
}
