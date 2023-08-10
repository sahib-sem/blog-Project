using blogApi.Data;
using blogApi.Models;
using blogApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace blogApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CommentsController:ControllerBase{
    

    private readonly CommentService _commentService;

    public CommentsController(BlogContext context)
        {
            _commentService = new CommentService(context);
        }

    [HttpGet]
    public async Task<IActionResult> GetComments()
    {
        var comments = await _commentService.GetComments();
        return Ok(comments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCommentById(int id)
    {
        var comment = await _commentService.GetCommentById(id);
        if (comment == null)
        {
            return NotFound();
        }
        return Ok(comment);
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CommentModel commentModel)
    {
        var createdComment = await _commentService.CreateComment(commentModel.Text, commentModel.PostId);
        
        if (createdComment == null)
        {
            return BadRequest("Post not found");
        }
        return Ok(createdComment);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateComment(int id, [FromBody] CommentModel commentModel)
    {
        var updatedComment = await _commentService.UpdateComment(id, commentModel.Text);
        if (updatedComment == null)
        {
            return BadRequest("Comment not found");
        }
        return Ok(updatedComment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var deletedComment = await _commentService.DeleteComment(id);
        if (deletedComment == null)
        {
            return NotFound();
        }
        return Ok(deletedComment);
    }
}