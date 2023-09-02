namespace EduRate.Api.Models
{
    public class Interaction
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public bool IsUpvote { get; set; }  // true for upvote, false for downvote
        // Additional fields like UserId, etc.
    }
}