using System.ComponentModel.DataAnnotations;

namespace Eventmi.Core.Models
{
    /// <summary>
    /// Event
    /// </summary>
    public class EventModel
    {
        /// <summary>
        /// Идентификатор на запис
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Име на събитието
        /// </summary>
        [Display(Name = "Име на събитието")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field {0} is required!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Field {0} must be between {2} and {1} symbols length!")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Начална дата и час
        /// </summary>
        [Display(Name = "Начална дата и час")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field '{0}' is required!")]
        public DateTime Start { get; set; }

        /// <summary>
        /// Крайна дата и час
        /// </summary>
        [Display(Name = "Крайна дата и час")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field {0} is required!")]
        public DateTime End { get; set; }

        /// <summary>
        /// Място на провеждане
        /// </summary>
        [Display(Name = "Място на провеждане")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Field {0} is required!")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Field {0} must be between {2} and {1} symbols length!")]
        public string Place { get; set; } = null!;
    }
}