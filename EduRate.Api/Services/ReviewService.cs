using EduRate.Api.Interfaces;
using EduRate.Api.Models;

namespace EduRate.Api.Services;

public class ReviewService : IReviewService
{
    public bool AddComment(Comment comment)
    {
        // Logic to add a comment
        return true;
    }

    public List<Comment> GetAllCommentsForModule(int moduleId)
    {
        // Logic to get all comments for a specific module
        return new List<Comment>();
    }

    public List<Comment> GetRecentComments(int moduleId)
    {
        // Logic to get recent comments for a specific module
        return new List<Comment>();
    }
}