using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Prosolve.Services.Identification.Entities.Users.DataSources
{
    /// <summary>
    ///     Модель отображающая таблицу в базе данных для пользователя.
    /// </summary>
    [Table("user")]
    internal class UserDataModel
    {
        /// <summary>
        ///     Внутренний идентификатор процесса.
        /// </summary>
        [Key, Required, NotNull, Column("id")]
        public int PrivateId { get; set; }

        /// <summary>
        ///     Внешний идентификатор процесса.
        /// </summary>
        [Required, Column("guid"), NotNull]
        public Guid PublicId { get; set; }

        /// <summary>
        ///     Версия объекта.
        /// </summary>
        [Required, Column("version"), NotNull]
        public int Version { get; set; }

        /// <summary>
        ///     Фамилия.
        /// </summary>
        [Column("surname"), NotNull]
        public string Surname { get; set; } = "Не указана";

        /// <summary>
        ///     Имя.
        /// </summary>
        [Column("first_name"), NotNull]
        public string FirstName { get; set; } = "Не указано";

        /// <summary>
        ///     Отчество.
        /// </summary>
        [Column("middle_name")]
        public string? MiddleName { get; set; }

        /// <summary>
        ///     Контактный адрес электронной почты.
        /// </summary>
        [Column("email_address")]
        public string? EmailAddress { get; set; }

        /// <summary>
        ///     Дата подтверждения контактного адреса электронной почты.
        /// </summary>
        [Column("email_address_confirm_date")]
        public DateTime? EmailAddressConfirmDate { get; set; }

        /// <summary>
        ///     Контактный номер телефона.
        /// </summary>
        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        ///     Дата подтверждения контактного номера телефона.
        /// </summary>
        [Column("phone_number_confirm_date")]
        public DateTime? PhoneNumberConfirmDate { get; set; }
    }
}
