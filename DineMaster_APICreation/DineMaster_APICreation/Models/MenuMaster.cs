using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DineMaster_APICreation.Models
{
    public class MenuMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuID { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        [Required]
        public string MenuName { get; set; }

        public string? MenuImage { get; set; }

        public string? Description { get; set; }

        public string? Prize { get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedAt { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual CategoryMaster Category { get; set; }

        public virtual ICollection<MenuIngradients> MenuIngredients { get; set; } = new List<MenuIngradients>();
    }
}
