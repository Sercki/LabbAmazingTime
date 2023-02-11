namespace AT.Common.DTOs;

public class FilmGenreDTO
{
    public int GenreId { get; set; }
    public int FilmId { get; set; }

    public string? GenreTitle { get; set; }
    //public virtual GenreDTO? Genre { get; set; }
    public string? FilmTitle { get; set; }
    //public virtual FilmDTO? Film { get; set; }

    public FilmGenreDTO(int genreId, int filmId)
    {
        GenreId = genreId;
        FilmId = filmId;        
    }
}
