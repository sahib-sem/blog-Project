using blogApi.Services;

namespace unitTest;


public class CommentTest
{

    private readonly CommentService _commentService;
    private readonly PostService _postService;
    public CommentTest()
    {
        _commentService = new CommentService(ContextGenerator.Generate());
        _postService = new PostService(ContextGenerator.Generate());



    }


    [Fact]
    public async void createCommentTest(){
        await _postService.CreatePostAsync("post title" , "post Content");
        var comment = await _commentService.CreateComment("text" , 1);
        Assert.NotNull(comment);
        Assert.Equal("text" , comment.Text);
        Assert.Equal(1 , comment.PostId);
    }


    [Fact]
    public async void GetCommentsTest()
    {
        
        var comments = await _commentService.GetComments();
        Assert.Equal(0,  comments.Count);
        


    }

    [Fact]
    public async void GetCommentByIdTest(){

        await _commentService.CreateComment("text" , 1);

        var comment = await _commentService.GetCommentById(1);
        Assert.Null(comment);
    }

    [Fact]
    public async void updateCommentTest(){
        await _postService.CreatePostAsync("post title" , "post Content");
        await _commentService.CreateComment("text" , 1);
        var comment = await _commentService.UpdateComment(1 , "new text");
        Assert.NotNull(comment);
        Assert.Equal("new text" , comment.Text);
    }

    [Fact]
    public async void deleteCommentTest(){
        await _postService.CreatePostAsync("post title" , "post Content");
        await _commentService.CreateComment("text" , 1);
        var comment = await _commentService.DeleteComment(1);
        Assert.NotNull(comment);
    }
}