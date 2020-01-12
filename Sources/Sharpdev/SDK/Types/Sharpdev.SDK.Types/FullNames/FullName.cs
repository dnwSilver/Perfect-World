using Sharpdev.SDK.Extensions;

namespace Sharpdev.SDK.Types.FullNames
{
    /// <summary>
    ///     Фамилия имя и отчество человека.
    /// </summary>
    public class FullName : IFullName
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
        ///     Конструктор для ФИО.
        /// </summary>
        /// <param name="surname"> Фамилия. </param>
        /// <param name="firstName"> Имя. </param>
        /// <param name="patronymic"> Отчество. </param>
        public FullName(string surname, string firstName, string patronymic)
        {
            Surname = surname;
            FirstName = firstName;
            Patronymic = patronymic;
        }

        /// <summary>
        ///     Приведение текстовой ошибки к формату <see cref="string" />.
        /// </summary>
        /// <returns> Текстовое значение ошибки, если оно есть. </returns>
        public override string ToString()
            => $"{Surname} {FirstName} {Patronymic}";

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
            return obj switch
            {
                null => (Surname is null && FirstName is null && Patronymic is null),
                FullName fullName => Surname.Equals(fullName.Surname)
                                  && FirstName.Equals(fullName.FirstName)
                                  && Patronymic.Equals(fullName.Patronymic),
                _ => false
            };
        }

        /// <summary>
        ///     Переопределите метод GetHashCode, чтобы тип правильно работал в хэш-таблице.
        /// </summary>
        /// <returns>Значение хэш-кода.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
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
            return a.ReturnFailure().Equals(b);
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
            return !a.ReturnFailure().Equals(b);
        }
    }
}
