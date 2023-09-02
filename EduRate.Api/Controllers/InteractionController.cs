using EduRate.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EduRate.Api.Services;

namespace EduRate.Api.Controllers
{
    [ApiController]
    [Route("api/interactions")]
    public class InteractionController : ControllerBase
    {
        private readonly IInteractionService _interactionService;

        public InteractionController(IInteractionService interactionService)
        {
            _interactionService = interactionService;
        }

        [HttpPost("upvote/{commentId}")]
        public IActionResult UpvoteComment(int commentId)
        {
            var result = _interactionService.UpvoteComment(commentId);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpPost("downvote/{commentId}")]
        public IActionResult DownvoteComment(int commentId)
        {
            var result = _interactionService.DownvoteComment(commentId);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}