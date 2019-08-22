using System.Text.RegularExpressions;

namespace Sharpdev.SDK.Types.EmailAddresses
{
    /// <summary>
    ///     Адрес электронной почты.
    /// </summary>
    public struct EmailAddress
    {
        /// <summary>
        ///     Поле для хранения значения переменной.
        /// </summary>
        private readonly string _value;

        /// <summary>
        ///     На вход принимается только email адреса.
        /// </summary>
        /// <param name="emailAddress">Электронный адрес.</param>
        private EmailAddress(string emailAddress)
        {
            if (TryParse(emailAddress))
                this._value = emailAddress;
            else
                throw new EmailValidationException();
        }

        /// <summary>
        ///     Определяет равны ли значения этого экземпляра и указанного объекта object.
        /// </summary>
        /// <param name="obj">object для сравнения с данным экземпляром</param>
        /// <returns>
        ///     <see langword="true" /> - <see cref="_value" /> не отличается от <paramref name="obj" />.
        ///     <see langword="false" /> - <see cref="_value" /> отличается от <paramref name="obj" />.
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is null)
                return this._value is null;

            if (this._value is null)
                return false;

            switch(obj)
            {
                case EmailAddress email:

                    return this._value.Equals(email._value);
                case string strEmail:

                    return this._value.Equals(strEmail);
            }

            return false;
        }

        /// <summary>
        ///     Возвращает хэш-код для этой строки.
        /// </summary>
        /// <returns>Хэш-код 32-битового целого числа со знаком.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return this._value.GetHashCode() * 397;
            }
        }

        /// <summary>
        ///     Приведение к строке.
        /// </summary>
        /// <returns>Значение в типе строка.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>
        ///     Производит преобразование из типа EmailAddress в тип string.
        /// </summary>
        /// <param name="emailAddress">Адрес электронной почты.</param>
        /// <returns>Значение преобразованное в тип string.</returns>
        public static implicit operator string(EmailAddress emailAddress)
        {
            return emailAddress._value;
        }

        /// <summary>
        ///     Производит преобразование из типа <see cref="string" /> в тип
        ///     <see cref="EmailAddress" />.
        /// </summary>
        /// <param name="emailAddress">Адрес электронной почты.</param>
        /// <returns>Значение преобразованное в тип <see cref="EmailAddress" />.</returns>
        public static implicit operator EmailAddress(string emailAddress)
        {
            return new EmailAddress(emailAddress);
        }

        /// <summary>
        ///     Определяет, равны ли значения двух указанных объектов.
        /// </summary>
        /// <param name="a">Значение типа <see cref="EmailAddress" /></param>
        /// <param name="b">Значение типа <see cref="string" />.</param>
        /// <returns>
        ///     <see langword="true" /> - <paramref name="a" /> не отличается от <paramref name="b" />.
        ///     <see langword="false" /> - <paramref name="a" /> отличается от <paramref name="b" />.
        /// </returns>
        public static bool operator ==(EmailAddress a, object b)
        {
            return a.Equals(b);
        }

        /// <summary>
        ///     Определяет, различаются ли значения двух указанных строк.
        /// </summary>
        /// <param name="a">Значение типа <see cref="EmailAddress" /></param>
        /// <param name="b">Значение типа <see cref="string" />.</param>
        /// <returns>
        ///     <see langword="true" /> - <paramref name="a" /> отличается от <paramref name="b" />.
        ///     <see langword="false" /> - <paramref name="a" /> не отличается от <paramref name="b" />.
        /// </returns>
        public static bool operator !=(EmailAddress a, object b)
        {
            return !a.Equals(b);
        }

        /// <summary>
        ///     Проверяет электронный адрес на корректность.
        /// </summary>
        /// <param name="emailAddress">Адрес электронной почты.</param>
        /// <returns>
        ///     <see langword="true" /> - Электронный адрес корректный.
        ///     <see langword="false" /> - Электронный адрес некорректный.
        /// </returns>
        public static bool TryParse(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
                return false;

            //const string emailName = @"^\w+([-+.']\w+)*";
            //const string domainName = @"\w+([-.]\w+)*";
            //const string domainZone = @"\w+([-.]\w+)*$";
            //const string emailPattern = emailName + "@" + domainName + "\\." + domainZone;
            const string emailPattern = @"\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3}";

            var emailFormat = Regex.Match(emailAddress, emailPattern, RegexOptions.IgnoreCase);

            return emailFormat.Success;
        }

        /// <summary>
        ///     Проверяет адрес электронной почты на валидность и если проверка проходит успешно,
        ///     то возвращается true и адрес электронной почты сохраняется в выходящем параметре.
        ///     Иначе выходящий параметр равен null.
        /// </summary>
        /// <param name="emailAddress">Адрес электронной почты для проверки</param>
        /// <param name="email">Переменная, в которую необходимо сохранить адрес электронной почты, в случае его валидности</param>
        /// <returns>Возвращает результат успешности операции</returns>
        public static bool TryParse(string emailAddress, out EmailAddress? email)
        {
            if (TryParse(emailAddress))
            {
                email = new EmailAddress(emailAddress);

                return true;
            }

            email = null;

            return false;
        }

        /// <summary>
        ///     Признак валидности электронного адреса.
        /// </summary>
        /// <returns>
        ///     <see langword="true" /> - Электронный адрес прошёл проверку.
        ///     <see langword="false" /> - Электронный адрес не прошёл проверку.
        /// </returns>
        public bool IsValid()
        {
            return TryParse(this._value);
        }
    }
}
