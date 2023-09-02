using EduRate.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EduRate.Api.Models;
using EduRate.Api.Services;

namespace EduRate.Api.Controllers
{
    [ApiController]
    [Route("api/ratings")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        public IActionResult SubmitRating([FromBody] Rating rating)
        {
            var result = _ratingService.SubmitRating(rating);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpGet("{moduleId}")]
        public IActionResult GetRatingsForModule(int moduleId)
        {
            var ratings = _ratingService.GetRatingsForModule(moduleId);
            return Ok(ratings);
        }

        [HttpGet("average/{moduleId}")]
        public IActionResult GetAverageRating(int moduleId)
        {
            var averageRating = _ratingService.GetAverageRating(moduleId);
            return Ok(new { Average = averageRating });
        }
    }
}