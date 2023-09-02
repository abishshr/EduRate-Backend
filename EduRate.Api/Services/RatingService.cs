using EduRate.Api.Interfaces;
using EduRate.Api.Models;
using EduRate.Api.Data;

namespace EduRate.Api.Services
{
    public class RatingService : IRatingService
    {
        private readonly AppDbContext _context;

        public RatingService(AppDbContext context)
        {
            _context = context;
        }

        public bool SubmitRating(Rating rating)
        {
            if (rating == null || rating.ModuleId <= 0 || rating.Value <= 0)
            {
                return false;
            }

            // Save the rating to the database
            _context.Ratings.Add(rating);
            _context.SaveChanges();

            return true;
        }

        public List<Rating> GetRatingsForModule(int moduleId)
        {
            // Fetch ratings for a specific module from the database
            return _context.Ratings.Where(r => r.ModuleId == moduleId).ToList();
        }

        public double GetAverageRating(int moduleId)
        {
            // Fetch and calculate the average rating for a specific module from the database
            var ratings = _context.Ratings.Where(r => r.ModuleId == moduleId);

            if (!ratings.Any())
            {
                return 0.0;
            }

            return ratings.Average(r => r.Value) ?? 0.0;

        }
    }
}