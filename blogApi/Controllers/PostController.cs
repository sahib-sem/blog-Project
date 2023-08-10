using Blog.Models;
using blogApi.Data;
using blogApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace blogApi.Controllers;

[ApiController]
[Route("[controller]")]

public class PostController:ControllerBase{

    private readonly PostService _postService;

    public PostController(BlogContext context)
        {
            _postService = new PostService(context);
        }

    
    [HttpGet]
    public async Task<IActionResult> GetPosts()
    {
        var posts = await _postService.GetAllPostsAsync();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(int id)
    {
        var post = await _postService.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] PostModel postModel)
    {
        var createdPost = await _postService.CreatePostAsync(postModel.Title, postModel.Content);
        return Ok(createdPost);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdatePost(int id, [FromBody] PostModel postModel)
    {
        var updatedPost = await _postService.UpdatePostAsync(id, postModel.Title, postModel.Content);
        if (updatedPost == null)
        {
            return NotFound();
        }
        return Ok(updatedPost);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var deletedPost = await _postService.DeletePostAsync(id);
        if (deletedPost == null)
        {
            return NotFound();
        }
        return Ok(deletedPost);
    }
}