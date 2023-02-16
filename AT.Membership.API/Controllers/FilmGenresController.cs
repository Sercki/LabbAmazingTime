// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace AT.Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmGenresController : ControllerBase
{

    private readonly IDbService _db;

    public FilmGenresController(IDbService db) => _db = db;

    // GET: api/<FilmGenresController>

    [HttpGet]
    public async Task<IResult> Get()
    {
        try
        {
            _db.Include<FilmGenre>();
            List<FilmGenreDTO>? filmgenre = await _db.GetReferenceAsync<FilmGenre, FilmGenreDTO>();

            return Results.Ok(filmgenre);
        }
        catch
        {
        }
        return Results.NotFound();
    }


    // POST api/<FilmGenresController>    
    [HttpPost]
    public async Task<IResult> Post([FromBody] FilmGenreDTO dto)
    {
        try
        {
            if (dto == null) return Results.BadRequest();

            var filmgenre = await _db.AddReferenceAsync<FilmGenre, FilmGenreDTO>(dto);

            var success = await _db.SaveChangesAsync();

            if (!success) return Results.BadRequest();
            
            return Results.Ok(filmgenre);
        }
        catch
        {
        }

        return Results.BadRequest();
    }

    // DELETE api/<FilmGenresController>
    [HttpDelete]
    public async Task<IResult> Delete(FilmGenreDTO dto)
    {
        try
        {
            var success = _db.Delete<FilmGenre,FilmGenreDTO>(dto); 

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