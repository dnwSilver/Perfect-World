﻿using System;
using System.Collections.Generic;
using System.Linq;

using Sharpdev.SDK.Extensions;

namespace Sharpdev.SDK.Types.Results
{
    /// <summary>
    ///     Результат выполнения метода, возвращающего данные (не void).
    /// </summary>
    /// <typeparam name="TResultObjectType">Тип возвращаемых данных</typeparam>
    public readonly struct Result<TResultObjectType> : IEquatable<Result<TResultObjectType>>
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
        ///     Признак не выполнения метода.
        /// </summary>
        public bool Failure => !Success;

        /// <summary>
        ///     Данные-результат работы метода
        ///     Заполняется только в случае успеха при выполнении метода
        /// </summary>
        public TResultObjectType Value { get; }

        /// <summary>
        ///     Создание результата работы метода.
        /// </summary>
        /// <param name="value">Данные-результат работы метода.</param>
        /// <param name="success">Признак успешности выполнения метода.</param>
        /// <param name="errors">Список описаний ошибок, возникших при выполнении метода.</param>
        internal Result(TResultObjectType value, bool success, IEnumerable<IResultError> errors)
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
        /// <param name="resultError">Описание ошибки, возникшей при выполнении метода.</param>
        internal Result(TResultObjectType value, bool success, IResultError resultError)
        {
            Success = success;
            Errors = resultError.Yield();
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
        public static implicit operator TResultObjectType(Result<TResultObjectType> result)
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
        public static implicit operator Result(Result<TResultObjectType> result)
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
        public bool Equals(Result<TResultObjectType> other)
        {
            return Success == other.Success &&
                   Errors.SequenceEqual(other.Errors) &&
                   EqualityComparer<TResultObjectType>.Default.Equals(Value, other.Value);
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

            return obj is Result<TResultObjectType> result && Equals(result);
        }

        /// <summary>
        ///     Переопределите метод GetHashCode, чтобы тип правильно работал в хэш-таблице.
        /// </summary>
        /// <returns>Значение хэш-кода.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Success.GetHashCode();
                var errorsHashCode = Errors?.GetHashCode() ?? 0;
                hashCode = hashCode * 397 ^ errorsHashCode;
                hashCode = hashCode * 397 ^ EqualityComparer<TResultObjectType>.Default.GetHashCode(Value);

                return hashCode;
            }
        }

        /// <summary>
        ///     Приведение текстовой ошибки к формату <see cref="string" />.
        /// </summary>
        /// <returns> Текстовое значение ошибки, если оно есть. </returns>
        public override string? ToString()
        {
            return Success ? Value?.ToString() : this.Format(new ResultFormatProvider());
        }
    }
}
