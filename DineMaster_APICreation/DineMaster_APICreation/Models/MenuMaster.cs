using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DineMaster_APICreation.Models
{
    public class MenuMaster
    {
        [Key]
        public int MenuID { get; set; }
        [ForeignKey("Category")]

        public int CategoriID { get; set; }
        public string  MenuName { get; set; }
        public string MenuImage { get; set; }
        public string Description { get; set; }
        public string Prize { get; set; }

        public bool IsAvailable {  get; set; }


      

        CategoryMaster Category {  get; set; }
        public  ICollection<MenuIngradients> MenuIngredients { get; set; }

    }
}
