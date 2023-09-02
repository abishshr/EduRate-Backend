namespace EduRate.Api.Models
{
    public class Comment
    {
        public int? Id { get; set; }
        public string? Text { get; set; }
        public int? UserId { get; set; }
        public int ModuleId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Additional fields like Timestamp, Upvotes, Downvotes, etc. can be added as needed.
    }
}