namespace AT.Common.DTOs;

public class FilmDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Released { get; set; }
    public bool? Free { get; set; }
    public string? Description { get; set; }
    public string? Thumbnail { get; set; }
    public string? FilmUrl { get; set; }


    public int DirectorId { get; set; }    
    //test DirectorName
    public string? DirectorName { get; set; }
    // zamiast public virtual DirectorDTO? Director { get; set;}
    public int MainFilmIdinSimilar { get; set; }
    public string? SimilarFilmTitles { get; set; }
    //public List<SimilarFilmsDTO>? SimilarFilms { get; set; }
    public int GenreId { get; set; }
    public string? GenreTitles { get; set; }
    //public List<GenreDTO>? Genres { get; set; }
}
