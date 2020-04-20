using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prosolve.Services.Identification.Users.DataSources
{
    /// <summary>
    ///     Модель отображающая таблицу в базе данных для пользователя.
    /// </summary>
    [Table("user")]
    public class UserDataModel : ModifiableDataModel
    {
        /// <summary>
        ///     Фамилия.
        /// </summary>
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [Column("surname", TypeName = PostgreSQL.Types.CharacterVarying)]
        public string Surname { get; set; } = "Не указана";

        /// <summary>
        ///     Имя.
        /// </summary>
        [MinLength(2)]
        [MaxLength(50)]
        [Column("first_name", TypeName = PostgreSQL.Types.CharacterVarying)]
        public string FirstName { get; set; } = "Не указано";

        /// <summary>
        ///     Отчество.
        /// </summary>
        [MinLength(2)]
        [MaxLength(50)]
        [Column("middle_name", TypeName = PostgreSQL.Types.CharacterVarying)]
        public string? MiddleName { get; set; }

        public ICollection<ContactModel> ContactModels { get; set; }
    }
}