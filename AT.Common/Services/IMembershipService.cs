namespace AT.Common.Services
{
    public interface IMembershipService
    {
		Task<FilmDTO> GetFilmAsync(int? id);
		Task<List<FilmGenreDTO>> GetFilmGenresAsync();
		Task<List<SimilarFilmsDTO>> GetSimilarFilmsAsync();
		Task<List<FilmDTO>> GetFilmsAsync();
		Task<List<GenreDTO>> GetGenresAsync();
	}
}