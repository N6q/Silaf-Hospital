namespace Silaf_Hospital.DTOs
{
    public class NotificationInputDTO
    {
        public string RecipientId { get; set; }
        public string Role { get; set; } // Accept role as string; convert to enum inside service
        public string Message { get; set; }
    }
}
