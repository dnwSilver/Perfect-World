using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prosolve.Services.Identification.Users.DataSources
{
    /// <summary>
    /// Таблица с контактами клиентов.
    /// </summary>
    [Table("contact")]
    public class ContactModel : ModifiableDataModel
    {
        /// <summary>
        ///     Контактный адрес электронной почты.
        /// </summary>
        [Column("email_address")]
        public string? EmailAddress { get; set; }

        /// <summary>
        /// Признак подтверждения контакта
        /// </summary>
        [Column("is_confirm")]
        public bool IsConfirm { get; set; }

        /// <summary>
        ///     Дата подтверждения контактного адреса электронной почты.
        /// </summary>
        [Column("confirm_date")]
        public DateTime? ConfirmDate { get; set; }

        /// <summary>
        ///     Контактный номер телефона.
        /// </summary>
        [Column("phone_number")]
        public string? PhoneNumber { get; set; }


        public long UserDataModelId { get; set; }
        
        public UserDataModel? UserDataModel { get; set; }
    }

    public static class PostgreSQL
    {
        public static class Types
        {
            public const string Serial = "serial";
            public const string CharacterVarying = "character varying";
            public const string Timestamp = "timestamp";
            public const string Date = "date";
            public const string SmallSerial = "smallserial";
        }
    }
}