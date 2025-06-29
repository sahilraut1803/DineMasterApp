namespace DineMaster_APICreation.DTO
{
    public class OrderDTO1
    {
        public int TableId { get; set; }
        public string OrderType { get; set; } 
        public string OrderedBy { get; set; } 
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
    }
}
