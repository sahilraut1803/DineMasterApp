namespace DineMaster_APICreation.DTO
{
    public class UserDTO
    {
        public int UserID { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
