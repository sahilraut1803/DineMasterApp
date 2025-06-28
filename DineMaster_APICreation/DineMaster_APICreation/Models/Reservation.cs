using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DineMaster_APICreation.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public string CustomerName { get; set; }
        public string Contact { get; set; }
        public int GuestsCount { get; set; }
        public string Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TableId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }

        [ForeignKey("TableId")]
        public Table Table { get; set; }
    }
}
