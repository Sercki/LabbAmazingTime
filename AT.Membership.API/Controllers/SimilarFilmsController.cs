// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AT.Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SimilarFilmsController : ControllerBase
{
    private readonly IDbService _db;

    public SimilarFilmsController(IDbService db) => _db = db;

    // GET: api/<SimilarFilmsController>
    [HttpGet]
    public async Task<IResult> Get()
    {
        try
        {
            _db.IncludeReference<SimilarFilms>();

            List<SimilarFilmsDTO>? similarFilms = await _db.GetReferenceAsync<SimilarFilms, SimilarFilmsDTO>();

            return Results.Ok(similarFilms);
        }
        catch
        {
        }
        return Results.NotFound();
    }

    // POST api/<SimilarFilmsController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] SimilarFilmsDTO dto)
    {
        try
        {
            if (dto == null) return Results.BadRequest();

            var similarFilms = await _db.AddReferenceAsync<SimilarFilms, SimilarFilmsDTO>(dto);

            var success = await _db.SaveChangesAsync();

            if (!success) return Results.BadRequest();

            return Results.Ok(similarFilms);
        }
        catch
        {
        }

        return Results.BadRequest();
    }
    // DELETE api/<SimilarFilmsController>/5
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(SimilarFilmsDTO dto)
    {
        try
        {
            var success = _db.Delete<SimilarFilms, SimilarFilmsDTO>(dto);

            if (!success) return Results.NotFound();

            success = await _db.SaveChangesAsync();

            if (!success) return Results.BadRequest();

            return Results.NoContent();
        }
        catch
        {
        }
        return Results.BadRequest();
    }
}
