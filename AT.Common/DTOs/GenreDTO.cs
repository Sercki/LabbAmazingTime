namespace AT.Common.DTOs;

public class GenreDTO :GenreBaseDTO
{
    public List<FilmDTO>? Films { get; set; } = new();
}

public class GenreCreateDTO
{    
    public string? Name { get; set; }
}

public class GenreEditDTO : GenreCreateDTO
{
    public int Id { get; set; }    
}

public class GenreBaseDTO
{
	public int Id { get; set; }
	public string? Name { get; set; }
}