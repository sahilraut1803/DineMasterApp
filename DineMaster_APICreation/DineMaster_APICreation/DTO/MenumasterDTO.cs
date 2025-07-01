using DineMaster_APICreation.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DineMaster_APICreation.DTO
{
    public class MenumasterDTO
    {
        public int MenuID { get; set; }

        public int CategoryID { get; set; }
        public string MenuName { get; set; }
        public string MenuImage { get; set; }
        public string Description { get; set; }
        public string Prize { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        CategoryMaster Category { get; set; }
    }
}
