using Microsoft.EntityFrameworkCore;
using Registration_Form.Models;

namespace Registration_Form.Data
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext>options ):base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
