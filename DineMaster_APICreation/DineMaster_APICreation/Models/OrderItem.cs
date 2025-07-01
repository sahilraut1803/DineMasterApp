using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DineMaster_APICreation.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }

        [ForeignKey("MenuMaster")]
        public int MenuID { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual OnlineOrder Order { get; set; }
        public virtual MenuMaster Menu { get; set; }
    }
}
