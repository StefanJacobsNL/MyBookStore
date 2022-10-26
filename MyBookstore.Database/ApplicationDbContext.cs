using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBookstore.Database.Entities;

namespace MyBookstore.Database
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AuthorDTO> Authors { get; set; }
        public DbSet<GenreDTO> Genres { get; set; }
        public DbSet<BookDTO> Books { get; set; }
        public DbSet<BookAuthorDTO> BookAuthors { get; set; }
        public DbSet<BookGenreDTO> BookGenres { get; set; }
    }
}