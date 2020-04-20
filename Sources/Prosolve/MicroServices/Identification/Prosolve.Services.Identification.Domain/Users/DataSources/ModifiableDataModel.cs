using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prosolve.Services.Identification.Users.DataSources
{
    /// <summary>
    /// Модель данных для модифицированной сущности.
    /// </summary>
    public abstract class ModifiableDataModel : StandardDataModel
    {
        /// <summary>
        /// Дата и время последней публикации.
        /// </summary>
        [Required]
        [Column("modification_date", TypeName = PostgreSQL.Types.Timestamp)]
        public DateTime? ModificationTime { get; set; }

        /// <summary>
        /// Версия объекта.
        /// </summary>
        [Required]
        [Column("version", TypeName = PostgreSQL.Types.SmallSerial)]
        public long Version { get; set; }
    }
}