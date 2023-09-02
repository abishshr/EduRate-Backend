using EduRate.Api.Models;

namespace EduRate.Api.Interfaces
{
    public interface IRatingService
    {
        bool SubmitRating(Rating rating);
        List<Rating> GetRatingsForModule(int moduleId);
        double GetAverageRating(int moduleId);
    }
}