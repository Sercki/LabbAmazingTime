namespace AT.Common.DTOs;

public class SimilarFilmsDTO : SimilarFilmsPutDeleteDTO
{
	//public int ParentFilmId { get; set; }
	//public int SimilarFilmId { get; set; }

	public string? ParentFilmTitle { get; set; }
	public string? SimilarFilmTitle { get; set; }
}

public class SimilarFilmsPutDeleteDTO
{
	public int ParentFilmId { get; set; }
	public int SimilarFilmId { get; set; }
}