using EduRate.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        // New method to get the vote count for a comment
        [HttpGet("votes/{commentId}")]
        public IActionResult GetCommentVotes(int commentId)
        {
            int voteCount = _interactionService.GetCommentVotes(commentId);

            // Return the vote count in the response, perhaps as a JSON object
            return Ok(new { votes = voteCount });
        }
    }
}