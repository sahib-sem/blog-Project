using blogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace blogApi.Data;

public class BlogContext: DbContext {
    public BlogContext(DbContextOptions<BlogContext> options): base(options) {

    }

    

    public  DbSet<Post> Posts { get; set; } 
    public  DbSet<Comment> Comments { get; set; } 

  


    }