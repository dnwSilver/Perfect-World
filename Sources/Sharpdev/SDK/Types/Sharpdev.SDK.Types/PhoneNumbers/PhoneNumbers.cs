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
            this._value = value;
        }

        /// <summary>
        ///     Приведение к строке.
        /// </summary>
        /// <returns>Значение в типе строка.</returns>
        public override string ToString()
        {
            return this._value;
        }
    }
}
