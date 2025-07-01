using System.ComponentModel.DataAnnotations;

namespace DineMaster_APICreation.Models
{
    public class OnlineOrder
    {

        [Key]
        public int OrderID { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerEmail { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        public string CreatedBy { get; set; }

        public bool IsCompleted { get; set; } = false;

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public virtual ICollection<OrderTracking> OrderTrackings { get; set; } = new List<OrderTracking>();
    }
}
