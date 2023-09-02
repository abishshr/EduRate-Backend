using EduRate.Api.Models;

namespace EduRate.Api.Interfaces
{
    public interface IReviewService
    {
        bool AddComment(Comment comment);
        List<Comment> GetAllCommentsForModule(int moduleId);
        List<Comment> GetRecentComments(int moduleId);
    }
}