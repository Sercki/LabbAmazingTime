using System.Net.Http.Json;
using System.Text;

namespace AT.Common.Services;

public class AdminService : IAdminService
{
	readonly MembershipHttpClient _http;

	public AdminService(MembershipHttpClient httpClient)
	{
		_http = httpClient;
	}

	public async Task<List<TDto>> GetAsync<TDto>(string uri)
	{
		try
		{
			using HttpResponseMessage response = await _http.Client.GetAsync(uri); 
            response.EnsureSuccessStatusCode();

			var result = JsonSerializer.Deserialize<List<TDto>>(await response.Content.ReadAsStreamAsync(),
					new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

			return result ?? new List<TDto>();
		}
		catch (Exception)
		{

			throw;
		}
	}

    public async Task<TDto?> SingleAsync<TDto>(string uri)
    {
        try
        {
            using HttpResponseMessage response = await _http.Client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var result = JsonSerializer.Deserialize<TDto>(await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? default;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task CreateAsync<TDto>(string uri, TDto dto)
    {
        try
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await _http.Client.PostAsync(uri, jsonContent);

            response.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task EditAsync<TDto>(string uri, TDto dto)
    {
        try
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await _http.Client.PutAsync(uri, jsonContent);

            response.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            throw;
        }
    }

	public async Task DeleteAsync<TDto>(string uri)
	{
		try
		{
			using HttpResponseMessage response = await _http.Client.DeleteAsync(uri);

			response.EnsureSuccessStatusCode();
		}
		catch (Exception ex)
		{
			throw;
		}
	}

    public async Task DeleteReferenceAsync<TDto>(string uri, TDto dto)
    {
        try
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            requestMessage.Content = JsonContent.Create(dto);
            using var response = await _http.Client.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();
            requestMessage.Dispose();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

}
