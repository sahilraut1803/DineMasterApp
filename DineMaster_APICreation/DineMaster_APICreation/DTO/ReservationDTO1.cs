namespace DineMaster_APICreation.DTO
{
    public class ReservationDTO1
    {
        public string CustomerName { get; set; }
        public string Contact { get; set; }
        public int GuestsCount { get; set; }
        public string Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TableId { get; set; }
        public string CreatedBy { get; set; }
    }
}
