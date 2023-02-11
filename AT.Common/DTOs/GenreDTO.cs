using System.ComponentModel.DataAnnotations;

namespace AT.Common.DTOs;

public class GenreDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }


    public int FilmId { get; set; }
    public string? FilmTitle { get; set; }
    //public List<FilmDTO>? Films { get; set; }
}
