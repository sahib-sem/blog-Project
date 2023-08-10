using blogApi.Data;
using Microsoft.EntityFrameworkCore;

namespace unitTest;

public static class ContextGenerator{
    public static BlogContext Generate() {
        var options = new DbContextOptionsBuilder<BlogContext>()
            .UseInMemoryDatabase(databaseName: "Blog")
            .Options;
        var context = new BlogContext(options);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        return context;
    }
    
}