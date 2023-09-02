using EduRate.Api.Interfaces;
using EduRate.Api.Models;
using EduRate.Api.Data;


namespace EduRate.Api.Services
{
    public class ReviewService : IReviewService
    {
        private readonly AppDbContext _context;

        public ReviewService(AppDbContext context)
        {
            _context = context;
        }

        public bool AddComment(Comment comment)
        {
            // Logic to add a comment to the database
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return true;
        }

        public List<Comment> GetAllCommentsForModule(int moduleId)
        {
            // Fetch all comments for a specific module from the database
            return _context.Comments.Where(c => c.ModuleId == moduleId).ToList();
        }

        public List<Comment> GetRecentComments(int moduleId)
        {
            // Fetch recent comments for a specific module from the database
            return _context.Comments
                .Where(c => c.ModuleId == moduleId)
                .OrderByDescending(c => c.CreatedAt)
                .Take(10)
                .ToList();
        }
    }
}