using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DineMaster_APICreation.Models
{
    public class MenuIngradients
    {
        [Key]
        public int MenuIngredientID { get; set; }

        [ForeignKey("MenuMaster")]
        public int MenuID { get; set; }

        [ForeignKey("IngrediantMaster")]
        public int IngrediantID { get; set; }

        public int IngrediantQty { get; set; }

        public  MenuMaster MenuMaster { get; set; }
        public  IngradientMaster IngrediantMaster { get; set; }
    }
}
