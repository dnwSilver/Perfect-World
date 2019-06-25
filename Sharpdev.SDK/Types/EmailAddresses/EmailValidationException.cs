using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Sharpdev.SDK.Types.EmailAddresses
{
    /// <summary>
    ///     Представляет ошибки, происходящие во время проверки адреса электронной почты.
    /// </summary>
    [Serializable]
    [Localizable(false)]
    public class EmailValidationException : Exception
    {
        /// <summary>
        ///     Выполняет инициализацию нового экземпляра класса <see cref="Exception" />, используя
        ///     базовое сообщение об ошибке.
        /// </summary>
        public EmailValidationException()
            : base(EmailAddressMessage.EmailValidationException)
        {
        }

        /// <summary>
        ///     Выполняет  инициализацию   нового   экземпляра   класса   EmailValidationException,
        ///     используя  указанное  сообщение  об  ошибке.
        /// </summary>
        /// <param name="message">Сообщение, описывающее ошибку.</param>
        public EmailValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Инициализирует   новый   экземпляр   класса  <see cref="EmailValidationException" />
        ///     указанным  сообщением об ошибке  и  ссылкой на внутреннее исключение, которое стало
        ///     причиной данного исключения. Создание исключения с текстом сообщения.
        /// </summary>
        /// <param name="message">Сообщение об ошибке с объяснением причин исключения.</param>
        /// <param name="innerException">
        ///     Исключение, вызвавшее текущее исключение, или указатель null,
        ///     если внутреннее исключение не задано.
        /// </param>
        public EmailValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        ///     Инициализирует новый экземпляр класса System.Exception с сериализованными  данными.
        /// </summary>
        /// <param name="info">
        ///     System.Runtime.Serialization.SerializationInfo,   хранящий  сериализованные  данные
        ///     объекта, относящиеся к выдаваемому исключению.
        /// </param>
        /// <param name="context">
        ///     Объект   System.Runtime.Serialization.StreamingContext,   содержащий    контекстные
        ///     сведения об источнике или назначении.
        /// </param>
        protected EmailValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
