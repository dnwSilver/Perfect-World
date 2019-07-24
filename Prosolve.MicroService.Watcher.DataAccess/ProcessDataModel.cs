using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prosolve.MicroService.Watcher.DataAccess
{
    /// <summary>
    ///     Модель отображающая таблицу в базе данных для объекта <see cref="IProcessEntity" />.
    /// </summary>
    [Table("process")]
    public class ProcessDataModel
    {
        /// <summary>
        ///     Внутренний идентификатор объекта <see cref="IProcessEntity" />.
        /// </summary>
        [Key]
        [Column("id")]
        public int PrivateId { get; set; }


        /// <summary>
        ///     Внешний идентификатор объекта <see cref="IProcessEntity" />.
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
        public int Type { get; set; }
    }
}
