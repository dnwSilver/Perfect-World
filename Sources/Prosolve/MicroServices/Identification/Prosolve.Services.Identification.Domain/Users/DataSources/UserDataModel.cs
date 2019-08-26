using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prosolve.Services.Identification.Users.DataSources
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
        [Key, Required, Column("id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrivateId { get; set; }

        /// <summary>
        ///     Внешний идентификатор процесса.
        /// </summary>
        [Required, Column("guid")]
        public Guid PublicId { get; set; }

        /// <summary>
        ///     Версия объекта.
        /// </summary>
        [Required, Column("version")]
        public int Version { get; set; }

        /// <summary>
        ///     Фамилия.
        /// </summary>
        [Column("surname")]
        public string Surname { get; set; } = "Не указана";

        /// <summary>
        ///     Имя.
        /// </summary>
        [Required, Column("first_name")]
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
