using blogApi.Data;
using blogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace blogApi.Services;

    public class PostService 
    {
        private readonly BlogContext _context;
        public PostService(BlogContext context)
        {
            _context = context;
        }

        public async Task<Post> CreatePostAsync(string title , string content)
        {
            var post = new Post{
                Title = title,
                Content = content,
                CreatedAt = DateTime.Now.ToUniversalTime(),
            };
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }
       

        public async Task<Post?> DeletePostAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return null;
            }
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _context.Posts.AsNoTracking().Include(p => p.Comments).ToListAsync();
        }

        public  Post? GetPostByIdAsync(int id)
        {
            return _context.Posts.Include(p => p.Comments).AsNoTracking().SingleOrDefault(p => p.Id == id);
        }

        public async Task<Post?> UpdatePostAsync(int id, string title , string content)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return null;
            }
            post.Title = title;
            post.Content = content;
            await _context.SaveChangesAsync();
            return post;
        }
        
    }

