namespace Sharpdev.SDK.Types.FullNames
{
    /// <summary>
    ///     Фамилия имя и отчество человека.
    /// </summary>
    public struct FullName
    {
        /// <summary>
        ///     Фамилия.
        /// </summary>
        public string Surname { get; }

        /// <summary>
        ///     Имя.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        ///     Отчество.
        /// </summary>
        public string Patronymic { get; }

        /// <summary>
        ///     Полное фио.
        /// </summary>
        public string GetFullName => $"{this.Surname} {this.FirstName} {this.Patronymic}";

        /// <summary>
        ///     Конструктор для ФИО.
        /// </summary>
        /// <param name="surname"> Фамилия. </param>
        /// <param name="firstName"> Имя. </param>
        /// <param name="patronymic"> Отчество. </param>
        public FullName(string surname, string firstName, string patronymic)
        {
            this.Surname = surname.Trim();
            this.FirstName = firstName.Trim();
            this.Patronymic = patronymic.Trim();
        }

        /// <summary>
        ///     Приведение текстовой ошибки к формату <see cref="string" />.
        /// </summary>
        /// <returns> Текстовое значение ошибки, если оно есть. </returns>
        public override string ToString()
        {
            return this.GetFullName;
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
            switch(obj)
            {
                case null:

                    return this.Surname is null && this.FirstName is null && this.Patronymic is null;
                case FullName fullName:

                    return this.Surname.Equals(fullName.Surname) &&
                           this.FirstName.Equals(fullName.FirstName) &&
                           this.Patronymic.Equals(fullName.Patronymic);
                default:

                    return false;
            }
        }

        /// <summary>
        ///     Переопределите метод GetHashCode, чтобы тип правильно работал в хэш-таблице.
        /// </summary>
        /// <returns>Значение хэш-кода.</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// </summary>
        /// <param name="a">Значение типа <see cref="FullName" /></param>
        /// <param name="b">Значение типа <see cref="string" />.</param>
        /// <returns>
        ///     <see langword="true" /> - Объекты равны.
        ///     <see langword="false" /> - Объекты не равны.
        /// </returns>
        public static bool operator ==(FullName a, object b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// </summary>
        /// <param name="a">Значение типа <see cref="FullName" /></param>
        /// <param name="b">Значение типа <see cref="string" />.</param>
        /// <returns>
        ///     <see langword="true" /> - Объекты не равны.
        ///     <see langword="false" /> - Объекты равны.
        /// </returns>
        public static bool operator !=(FullName a, object b)
        {
            return !a.Equals(b);
        }
    }
}
