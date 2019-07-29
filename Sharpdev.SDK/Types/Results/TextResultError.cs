using System;

using Sharpdev.SDK.Patterns;

namespace Sharpdev.SDK.Types.Results
{
    /// <summary>
    ///     Текстовая ошибка.
    /// </summary>
    [State]
    public partial struct TextResultError : IResultError, IEquatable<TextResultError>
    {
        /// <summary>
        ///     Текст ошибки.
        /// </summary>
        private string Text { get; }

        /// <summary>
        ///     Конструктор для <see cref="TextResultError" />.
        /// </summary>
        /// <param name="text">Текст ошибки.</param>
        private TextResultError(string text)
        {
            this.Text = text;
        }

        /// <summary>
        ///     Приведение текстовой ошибки к формату <see cref="string" />.
        /// </summary>
        /// <returns>Текстовое значение ошибки.</returns>
        public override string ToString()
        {
            return this.ToString(string.Empty, null);
        }

        /// <summary>
        ///     Приведение текстовой ошибки к формату <see cref="string" />.
        /// </summary>
        /// <param name="format">Формат извлечения объекта.</param>
        /// <param name="formatProvider">
        ///     Предоставляет механизм извлечения объекта для управления форматированием.
        /// </param>
        /// <returns>Строковое представление объекта <see cref="TextResultError" />.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return this.Text;
        }

        /// <summary>
        ///     Сравнение двух текстовых ошибок.
        /// </summary>
        /// <param name="other">Другой объект значение для сравнивания.</param>
        /// <returns>
        ///     <see langword="true" /> - Объекты равны.
        ///     <see langword="false" /> - Объекты не равны.
        /// </returns>
        public bool Equals(TextResultError other)
        {
            return string.Equals(this.Text, other.Text);
        }

        /// <summary>
        ///     Сравнение двух текстовых ошибок.
        /// </summary>
        /// <param name="obj">Другой объект для сравнивания.</param>
        /// <returns>
        ///     <see langword="true" /> - Объекты равны.
        ///     <see langword="false" /> - Объекты не равны.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is TextResultError other)
                return this.Equals(other);

            return false;
        }

        /// <summary>
        ///     Переопределите метод GetHashCode, чтобы тип правильно работал в хэш-таблице.
        /// </summary>
        /// <returns>Значение хэш-кода.</returns>
        public override int GetHashCode()
        {
            return this.Text?.GetHashCode() ?? 0;
        }

        /// <summary>
        ///     Делаем объект с текстом ошибки. Фабричный метод.
        /// </summary>
        /// <param name="text">Текст ошибки.</param>
        /// <returns>Текстовая ошибка.</returns>
        /// <remarks> За счёт этого метода мы делаем объект иммутабельным.</remarks>
        public static TextResultError Create(string text)
        {
            return new TextResultError(text);
        }
    }
}
