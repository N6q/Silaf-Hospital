namespace Silaf_Hospital.DTOs
{
    public class TestOutputDTO
    {
        public string Id { get; set; }
        public string TestName { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string? Result { get; set; }
        public bool IsCompleted { get; set; }
    }
}
