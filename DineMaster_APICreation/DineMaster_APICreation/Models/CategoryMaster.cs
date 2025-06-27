using System.ComponentModel.DataAnnotations;

namespace DineMaster_APICreation.Models
{
    public class CategoryMaster
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
       
    }
}
