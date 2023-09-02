namespace EduRate.Api.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int UserId { get; set; }
        public int Value { get; set; }  // Ratings should be between 1 and 5
        // Additional fields like Timestamp, etc. can be added as needed.
    }
}