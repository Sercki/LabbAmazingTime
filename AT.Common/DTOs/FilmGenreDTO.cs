namespace AT.Common.DTOs;

public class FilmGenreDTO: FilmGenrePutDeleteDTO
{
    //public int GenreId { get; set; }
   //public int FilmId { get; set; }

    public string? GenreTitle { get; set; }
    public string? FilmTitle { get; set; }   
}


public class FilmGenrePutDeleteDTO
{
	public int GenreId { get; set; }
	public int FilmId { get; set; }
}