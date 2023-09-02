using EduRate.Api.Interfaces;
using EduRate.Api.Models;

namespace EduRate.Api.Services
{
    public class RatingService : IRatingService
    {
        public bool SubmitRating(Rating rating)
        {
            // Logic to submit a rating
            return true;
        }

        public List<Rating> GetRatingsForModule(int moduleId)
        {
            // Logic to get all ratings for a specific module
            return new List<Rating>();
        }

        public double GetAverageRating(int moduleId)
        {
            // Logic to get the average rating for a specific module
            return 4.0;
        }
    }
}