namespace AT.Membership.Database.Entities;

public class Film : IEntity
{

    public Film()
    {
        SimilarFilms = new HashSet<SimilarFilms>();
        Genres = new HashSet<Genre>();
    }
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string? Title { get; set; }

    [MaxLength(10)]
    public string? Released { get; set; }

    public bool? Free { get; set; }

    [MaxLength(200)]
    public string? Description { get; set; }

    [MaxLength(1024)]
    public string? Thumbnail { get; set; }

    [MaxLength(1024)]
    public string? FilmUrl { get; set; }

    public int DirectorId { get; set; }
    public virtual Director? Director { get; set; }

    public virtual ICollection<SimilarFilms>? SimilarFilms { get; set; }
    public virtual ICollection<Genre>? Genres { get; set; }
}
