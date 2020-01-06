namespace Sharpdev.SDK.Types.PhoneNumbers
{
    /// <summary>
    ///     Телефонный номер.
    /// </summary>
    public struct PhoneNumber
    {
        /// <summary>
        ///     Поле для хранения значения переменной.
        /// </summary>
        private readonly string _value;

        /// <summary>
        ///     Инициализация телефонного номер.
        /// </summary>
        /// <param name="value">телефонный номер.</param>
        public PhoneNumber(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Создание нового экземпляра телефонного номера.
        /// </summary>
        /// <param name="phoneNumber">Телефонный номер.</param>
        /// <returns>Новый экземпляр телефонного номера.</returns>
        public static implicit operator PhoneNumber(string phoneNumber)
        {
            // todo Проверка номера телефона на соответствие стандартам отсутствует.
            return new PhoneNumber(phoneNumber);
        }
        
        /// <summary>
        ///     Приведение к строке.
        /// </summary>
        /// <returns>Значение в типе строка.</returns>
        public override string ToString()
        {
            return _value;
        }
    }
}
