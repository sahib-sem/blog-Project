using blogApi.Services;

namespace unitTest;

public class PostTest
{

    private readonly PostService _postService;
    public PostTest()
    {
        _postService = new PostService(ContextGenerator.Generate());
    }

    [Fact]
    public async void createPostTest(){
        var post = await _postService.CreatePostAsync("post title" , "post Content");
        Assert.NotNull(post);
        Assert.Equal("post title" , post.Title);
        Assert.Equal("post Content" , post.Content);
    }

    [Fact]
    public async void GetPostsTest()
    {
        
        var posts = await _postService.GetAllPostsAsync();
        Assert.Equal(0,  posts.Count);
        
    }

    [Fact]
    public async void GetPostByIdTest()
    {

        await _postService.CreatePostAsync("post title" , "post Content");
        var post = await _postService.GetPostByIdAsync(1);
        Assert.NotNull(post);
        Assert.Equal("post title" , post.Title);
        Assert.Equal("post Content" , post.Content);
    }

    [Fact]
    public async void UpdatePostTest()
    {
        await _postService.CreatePostAsync("post title" , "post Content");
        var post = await _postService.UpdatePostAsync(1 , "new title" , "new Content");
        Assert.NotNull(post);
        Assert.Equal("new title" , post.Title);
        Assert.Equal("new Content" , post.Content);
    }

    [Fact]
    public async void DeletePostTest()
    {
        await _postService.CreatePostAsync("post title" , "post Content");
        var post = await _postService.DeletePostAsync(1);
        Assert.NotNull(post);
        Assert.Equal("post title" , post.Title);
        Assert.Equal("post Content" , post.Content);
    }

}