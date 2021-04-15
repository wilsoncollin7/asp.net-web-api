using Microsoft.EntityFrameworkCore;

namespace PostApi.Models
{
    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions<PostContext> options) : base(options) { }

        public DbSet<Post> posts { get; set; }
    }
}
