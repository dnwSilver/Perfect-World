using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prosolve.Services.Identification.Users.DataSources
{
    /// <summary>
    ///     Модель данных с уникальным идентификатором.
    /// </summary>
    public abstract class DataModelWithId
    {
        /// <summary>
        ///     Внутренний идентификатор процесса.
        /// </summary>
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_private", TypeName = PostgreSQL.Types.Serial)]
        public long PrivateId { get; set; }

        /// <summary>
        ///     Внешний идентификатор процесса.
        /// </summary>
        [Required]
        [Column("id_public")]
        public Guid PublicId { get; set; }
    }
}