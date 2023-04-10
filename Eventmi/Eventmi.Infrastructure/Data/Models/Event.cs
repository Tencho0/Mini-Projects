using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Eventmi.Infrastructure.Data.Models
{
    /// <summary>
    /// Събития
    /// </summary>
    [Comment("Събития")]
    public class Event
    {
        /// <summary>
        /// Идентификатор на запис
        /// </summary>
        [Key]
        [Comment("Идентификатор на запис")]
        public int Id { get; set; }

        /// <summary>
        /// Име на събитието
        /// </summary>
        [Required]
        [StringLength(50)]
        [Comment("Име на събитието")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Начална дата и час
        /// </summary>
        [Required]
        [Comment("Начална дата и час")]
        public DateTime Start { get; set; }

        /// <summary>
        /// Крайна дата и час
        /// </summary>
        [Required]
        [Comment("Крайна дата и час")]
        public DateTime End { get; set; }

        /// <summary>
        /// Място на провеждане
        /// </summary>
        [Required]
        [StringLength(100)]
        [Comment("Място на провеждане")]
        public string Place { get; set; } = null!;
    }
}