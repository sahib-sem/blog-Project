using blogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace blogApi.Data;

public class BlogContext: DbContext {
    public BlogContext(DbContextOptions<BlogContext> options): base(options) {

    }

    

    public virtual DbSet<Post> Posts { get; set; } 
    public virtual DbSet<Comment> Comments { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasOne(p => p.Post)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.PostId)
                .HasConstraintName("FK_Post_Id");
        });



    }}