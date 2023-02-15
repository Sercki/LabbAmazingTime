namespace AT.Common.DTOs;

public class FilmDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime? Released { get; set; }
    public bool? Free { get; set; }
    public string? Description { get; set; }
    public string? Thumbnail { get; set; }
    public string? FilmUrl { get; set; }

    public int DirectorId { get; set; }                    
    public string? DirectorName { get; set;}               
    public List<SimilarFilmsDTO>? SimilarFilms { get; set; }
    public List<GenreDTO>? Genres { get; set; }
    }

public class FilmCreateDTO
{
    public string? Title { get; set; }
    public DateTime? Released { get; set; }
    public bool? Free { get; set; }
    public string? Description { get; set; }
    public string? Thumbnail { get; set; }
    public string? FilmUrl { get; set; }

    public int DirectorId { get; set; }  
}

public class FilmEditDTO : FilmCreateDTO
{
    public int Id { get; set; }    
}