using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data;
public class MvcMovieContext(DbContextOptions<MvcMovieContext> options) : DbContext(options)
{
    public DbSet<Movie> Movie => Set<Movie>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.Property(m => m.Title).HasMaxLength(60).IsRequired();
            entity.Property(m => m.Genre).HasMaxLength(30).IsRequired();
            entity.Property(m => m.Price).HasColumnType("decimal(18,2)");
        });
    }
}
