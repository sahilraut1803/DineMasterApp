using System.ComponentModel.DataAnnotations;
namespace DineMaster_APICreation.Models
{
    public class IngradientMaster
    {
        [Key]
        public int IngrediantID { get; set; }
        public string IngrediantName { get; set; }

        public  ICollection<MenuIngradients> MenuIngredients { get; set; }
    }
}
