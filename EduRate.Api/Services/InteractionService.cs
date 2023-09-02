using EduRate.Api.Data;
using EduRate.Api.Interfaces;
using EduRate.Api.Models;

namespace EduRate.Api.Services;

public class InteractionService : IInteractionService
{
    private readonly AppDbContext _context;

    public InteractionService(AppDbContext context)
    {
        _context = context;
    }

    public bool UpvoteComment(int commentId)
    {
        // Logic to upvote
        _context.Interactions.Add(new Interaction { CommentId = commentId, IsUpvote = true });
        _context.SaveChanges();
        return true;
    }

    public bool DownvoteComment(int commentId)
    {
        // Logic to downvote
        _context.Interactions.Add(new Interaction { CommentId = commentId, IsUpvote = false });
        _context.SaveChanges();
        return true;
    }

    public int GetCommentVotes(int commentId)
    {
        // Logic to count votes
        int upvotes = _context.Interactions.Count(i => i.CommentId == commentId && i.IsUpvote);
        int downvotes = _context.Interactions.Count(i => i.CommentId == commentId && !i.IsUpvote);
        return upvotes - downvotes;
    }
}
