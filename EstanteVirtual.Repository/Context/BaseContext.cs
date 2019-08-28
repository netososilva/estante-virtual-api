using EstanteVirtual.Model;
using Microsoft.EntityFrameworkCore;

namespace EstanteVirtual.Repository.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Login>().ToTable("Login");
            modelBuilder.Entity<User>().ToTable("User")
                .Ignore(x => x.Token);

            modelBuilder.Entity<UserBook>()
                .HasKey(x => new { x.UserId, x.BookId });                
        }
    }
}
