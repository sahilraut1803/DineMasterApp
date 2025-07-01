using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DineMaster_APICreation.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int TableId { get; set; }  // FK 
        public string OrderType { get; set; }  // DineIn, TakeAway
        public string OrderedBy { get; set; }  // FK (maybe StaffId or UserId)
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }  // Pending, Completed, etc.
        [ForeignKey("TableId")]
        public Table Table { get; set; }
        // Navigation
        //public ICollection<OrderItem> OrderItems { get; set; }
        //public ICollection<OrderCart> OrderCarts { get; set; }
    }
}
