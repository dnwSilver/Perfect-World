using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prosolve.Services.Identification.Users.DataSources
{
    /// <summary>
    ///     Модель данных с учетом времени создания и полем для сортировки.
    /// </summary>
    public abstract class StandardDataModel : DataModelWithId
    {
        /// <summary>
        ///     Дата создания строки.
        /// </summary>
        [Required]
        [Column("modification_date", TypeName = PostgreSQL.Types.Timestamp)]
        public DateTime CreationTime { get; set; }

        /// <summary>
        ///     Период, к которому относится строчка.
        /// </summary>
        [Required]
        [Column("sort_date", TypeName = PostgreSQL.Types.Date)]
        public DateTime SortDate { get; set; }
    }
}