namespace EduRate.Api.Interfaces
{
    public interface IInteractionService
    {
        bool UpvoteComment(int commentId);
        bool DownvoteComment(int commentId);
    }
}