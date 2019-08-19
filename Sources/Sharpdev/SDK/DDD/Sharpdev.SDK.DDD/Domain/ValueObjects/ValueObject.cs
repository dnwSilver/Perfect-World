namespace Sharpdev.SDK.Domain.ValueObjects
{
    /// <summary>
    ///     Объект-значение.
    /// </summary>
    /// <typeparam name="TValueObject">
    ///     Потомок класса <see cref="ValueObject{TValueObject}" />.
    /// </typeparam>
    /// <remarks>
    ///     <see href="https://enterprisecraftsmanship.com/2015/01/03/value-objects-explained/" />.
    /// </remarks>
    public abstract class ValueObject<TValueObject> : IValueObject<TValueObject>
        where TValueObject : ValueObject<TValueObject>
    {
        /// <summary>
        ///     Сравнение двух объектов значения.
        /// </summary>
        /// <param name="other">Другой объект значение для сравнивания.</param>
        /// <returns>
        ///     <see langword="true" /> - Объекты равны.
        ///     <see langword="false" /> - Объекты не равны.
        /// </returns>
        public bool Equals(IValueObject<TValueObject> other)
        {
            return ReferenceEquals(this, other);
        }

        /// <summary>
        ///     Сравнение двух объектов.
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

            if (ReferenceEquals(this, obj))
                return true;

            return obj.GetType() == this.GetType() && this.Equals((object)(ValueObject<TValueObject>)obj);
        }


        /// <summary>
        ///     Сравнение двух объектов по основным полям.
        /// </summary>
        /// <param name="other">Другой объект для сравнивания.</param>
        /// <returns>
        ///     <see langword="true" /> - Объекты равны.
        ///     <see langword="false" /> - Объекты не равны.
        /// </returns>
        protected abstract bool EqualsCore(TValueObject other);

        /// <summary>
        ///     Переопределите метод GetHashCode, чтобы тип правильно работал в хэш-таблице.
        /// </summary>
        /// <returns>Значение хэш-кода.</returns>
        public override int GetHashCode()
        {
            return this.GetHashCodeCore();
        }

        /// <summary>
        ///     Переопределите метод GetHashCode, чтобы тип правильно работал в хэш-таблице.
        /// </summary>
        /// <returns>Значение хэш-кода.</returns>
        protected abstract int GetHashCodeCore();

        /// <summary>
        ///     Бинарный оператор сравнения двух значимых объектов.
        /// </summary>
        /// <param name="a">Левый операнд.</param>
        /// <param name="b">Правый операнд.</param>
        /// <returns>
        ///     <see langword="true" /> - Объекты равны.
        ///     <see langword="false" /> - Объекты не равны.
        /// </returns>
        public static bool operator ==(ValueObject<TValueObject> a, ValueObject<TValueObject> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals((object)b);
        }

        /// <summary>
        ///     Бинарный оператор сравнения двух значимых объектов.
        /// </summary>
        /// <param name="a">Левый операнд.</param>
        /// <param name="b">Правый операнд.</param>
        /// <returns>
        ///     <see langword="true" /> - Объекты не равны.
        ///     <see langword="false" /> - Объекты равны.
        /// </returns>
        public static bool operator !=(ValueObject<TValueObject> a, ValueObject<TValueObject> b)
        {
            return !(a == b);
        }
    }
}
