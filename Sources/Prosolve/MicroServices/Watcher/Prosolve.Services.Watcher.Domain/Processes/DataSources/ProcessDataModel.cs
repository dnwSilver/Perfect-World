using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prosolve.Services.Watcher.Domain.Processes.DataSources
{
    /// <summary>
    ///     Модель отображающая таблицу в базе данных для процесса.
    /// </summary>
    [Table("process")]
    public class ProcessDataModel
    {
        /// <summary>
        ///     Внутренний идентификатор процесса.
        /// </summary>
        [Key]
        [Column("id")]
        public int PrivateId { get; set; }

        /// <summary>
        ///     Внешний идентификатор процесса.
        /// </summary>
        [Required]
        [Column("guid")]
        public Guid PublicId { get; set; }

        /// <summary>
        ///     Наименование процесса.
        /// </summary>
        [Required]
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Ссылка на тип процесса.
        /// </summary>
        [Required]
        [Column("type")]
        public string TypeName { get; set; }
        
        /// <summary>
        /// Версия объекта.
        /// </summary>
        [Required]
        [Column("version")]
        public int Version { get; set; }
    }
}
