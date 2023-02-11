using AT.Membership.Database.Entities;

namespace AT.Membership.Database.Contexts;

public class ATContext : DbContext
{
    public DbSet<Director> Directors => Set<Director>();
    public DbSet<Film> Films => Set<Film>();
    public DbSet<FilmGenre> FilmGenres => Set<FilmGenre>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<SimilarFilms> FilmsSimilar => Set<SimilarFilms>();

    public ATContext(DbContextOptions<ATContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        base.OnModelCreating(modelBuilder);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelBuilder.Entity<SimilarFilms>().HasKey(ci => new { ci.ParentFilmId, ci.SimilarFilmId });
        modelBuilder.Entity<FilmGenre>().HasKey(ci => new { ci.FilmId, ci.GenreId });

        modelBuilder.Entity<Film>(entity =>
        {
            entity
                .HasMany(d => d.SimilarFilms)
                .WithOne(p => p.ParentFilm)
                .HasForeignKey(d => d.ParentFilmId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity
                  .HasMany(d => d.Genres)
                  .WithMany(p => p.Films)
                  .UsingEntity<FilmGenre>()                  
                  .ToTable("FilmGenres");

            modelBuilder.Entity<Director>().HasData(
            new { Id = 1, Name = "David Benioff" });

            modelBuilder.Entity<Film>().HasData(
                new { Id = 1, Title = "Game of Thrones", Released = "17.04.2011", Free = true,
                    Description = "It is an American fantasy drama television series created for HBO",
                    Thumbnail = "/images/GoT.jpg", FilmUrl = "https://www.youtube.com/watch?v=KPLWWIOCOOQ",
                    DirectorId = 1 });

            modelBuilder.Entity<SimilarFilms>().HasData(
                new SimilarFilms { ParentFilmId = 1, SimilarFilmId = 1 });

            modelBuilder.Entity<Genre>().HasData(
                new { Id = 1, Name = "Action" },
                new { Id = 2, Name = "Sci-Fi" },
                new { Id = 3, Name = "Fantasy" });

            modelBuilder.Entity<FilmGenre>().HasData(
                new FilmGenre { FilmId = 1, GenreId = 3 });
        });
    }
}