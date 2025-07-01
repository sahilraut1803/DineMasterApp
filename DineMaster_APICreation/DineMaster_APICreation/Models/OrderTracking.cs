using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DineMaster_APICreation.Models
{
    public class OrderTracking
    {
        [Key]
        public int TrackingID { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }

        public string Status { get; set; }  // "Pending", "Processing", "Shipped", "Delivered"
        public DateTime StatusUpdatedAt { get; set; } = DateTime.Now;

        public virtual OnlineOrder Order { get; set; }
    }
}
