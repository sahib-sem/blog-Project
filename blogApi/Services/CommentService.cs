using blogApi.Data;
using blogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace blogApi.Services;

public class CommentService{

    private readonly BlogContext _context;

    public CommentService(BlogContext context)
    {
        _context = context;
    }

    public async Task<Comment?> CreateComment(string text , int postId)
    {   
        try{
            var post = await _context.Posts.FindAsync(postId);
        if (post == null)
        {
            return null;
        }
        var comment = new Comment{
            Text = text,
            PostId = postId,
            CreatedAt = DateTime.Now.ToUniversalTime(),
        };

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        return comment;

        }catch(Exception e){
            Console.WriteLine(e.Message);
            return null;
        }
        
    }

    public async Task<Comment?> GetCommentById(int id)
    {
        return await _context.Comments.FindAsync(id);
    }

    public async Task<List<Comment>> GetComments()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment?> UpdateComment(int id, string Text)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null)
        {
            return null;
        }
        comment.Text = Text;
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment?> DeleteComment(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null)
        {
            return null;
        }
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return comment;
    }
}