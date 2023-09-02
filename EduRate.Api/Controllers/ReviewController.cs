using EduRate.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EduRate.Api.Models;
using EduRate.Api.Services;

namespace EduRate.Api.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public IActionResult AddComment([FromBody] Comment comment)
        {
            var result = _reviewService.AddComment(comment);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpGet("{moduleId}")]
        public IActionResult GetAllCommentsForModule(int moduleId)
        {
            var comments = _reviewService.GetAllCommentsForModule(moduleId);
            return Ok(comments);
        }

        [HttpGet("recent/{moduleId}")]
        public IActionResult GetRecentComments(int moduleId)
        {
            var comments = _reviewService.GetRecentComments(moduleId);
            return Ok(comments);
        }
    }
}