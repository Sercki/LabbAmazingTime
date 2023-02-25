namespace AT.Common.Services;
public class MembershipService : IMembershipService
{
	private readonly MembershipHttpClient _http;

	public MembershipService(MembershipHttpClient http)
	{
		_http = http;
	}

	public async Task<List<FilmDTO>> GetFilmsAsync()
	{
		try
		{

			bool freeOnly = false;

			using HttpResponseMessage response = await _http.Client.GetAsync($"films?freeOnly={freeOnly}");

			response.EnsureSuccessStatusCode();

			var result = JsonSerializer.Deserialize<List<FilmDTO>>(await response.Content.ReadAsStreamAsync(),
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

			return result ?? new List<FilmDTO>();
		}
		catch
		{
			return new List<FilmDTO>();
		}
	}

	public async Task<FilmDTO> GetFilmAsync(int? id)
	{
		try
		{
			if (id is null) return new FilmDTO();
			using HttpResponseMessage response = await _http.Client.GetAsync($"films/{id}");
			response.EnsureSuccessStatusCode();

			response.EnsureSuccessStatusCode();

			var result = JsonSerializer.Deserialize<FilmDTO>(await response.Content.ReadAsStreamAsync(),
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

			return result ?? new FilmDTO();
		}
		catch
		{
			return new FilmDTO();
		}
	}
	public async Task<List<GenreDTO>> GetGenresAsync()
	{
		try
		{
			using HttpResponseMessage response = await _http.Client.GetAsync($"genres");

			response.EnsureSuccessStatusCode();

			var result = JsonSerializer.Deserialize<List<GenreDTO>>(await response.Content.ReadAsStreamAsync(),
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

			return result ?? new List<GenreDTO>();
		}
		catch
		{
			return new List<GenreDTO>();
		}
	}
	public async Task<List<FilmGenreDTO>> GetFilmGenresAsync()
	{
		try
		{
			using HttpResponseMessage response = await _http.Client.GetAsync($"filmgenres");

			response.EnsureSuccessStatusCode();

			var result = JsonSerializer.Deserialize<List<FilmGenreDTO>>(await response.Content.ReadAsStreamAsync(),
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

			return result ?? new List<FilmGenreDTO>();
		}
		catch
		{
			return new List<FilmGenreDTO>();
		}
	}
	public async Task<List<SimilarFilmsDTO>> GetSimilarFilmsAsync()
	{
		try
		{
			using HttpResponseMessage response = await _http.Client.GetAsync($"similarfilms");

			response.EnsureSuccessStatusCode();

			var result = JsonSerializer.Deserialize<List<SimilarFilmsDTO>>(await response.Content.ReadAsStreamAsync(),
				new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

			return result ?? new List<SimilarFilmsDTO>();
		}
		catch
		{
			return new List<SimilarFilmsDTO>();
		}
	}
}
