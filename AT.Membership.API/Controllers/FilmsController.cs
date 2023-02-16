// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AT.Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmsController : ControllerBase
{
    private readonly IDbService _db;

    public FilmsController(IDbService db) => _db = db;

    // GET: api/<FilmsController>
    [HttpGet]
    public async Task<IResult> Get()
    {
        try
        {
            _db.Include<Film>();
           
            //_db.test();
            //_db.Include<FilmGenre>();  //FUNGERAR INTE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            List<FilmDTO>? films = await _db.GetAsync<Film, FilmDTO>();           

            return Results.Ok(films);
        }
        catch
        {
        }
        return Results.NotFound();
    }

    // GET api/<FilmsController>/5
    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        try
        {
            _db.Include<Film>();
            var film = await _db.SingleAsync<Film, FilmDTO>(c => c.Id.Equals(id));           

            return Results.Ok(film);
        }
        catch
        {
        }
        return Results.NotFound();
    }

    // POST api/<FilmsController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] FilmCreateDTO dto)
    {
        try
        {
            if (dto == null) return Results.BadRequest();

            var film = await _db.AddAsync<Film, FilmCreateDTO>(dto);

            var success = await _db.SaveChangesAsync();

            if (!success) return Results.BadRequest();

            return Results.Created(_db.GetURI<Film>(film), film);
        }
        catch
        {
        }

        return Results.BadRequest();
    }

    // PUT api/<FilmsController>/5
    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] FilmEditDTO dto)
    {
        try
        {
            if (dto == null) return Results.BadRequest("No entity selected");
            if (!id.Equals(dto.Id)) return Results.BadRequest("Ids are different. Please check correct Id");

            var exists = await _db.AnyAsync<Film>(c => c.Id.Equals(id));
            if (!exists) return Results.NotFound("Could not find entity");

            _db.Update<Film, FilmEditDTO>(dto.Id, dto);

            var success = await _db.SaveChangesAsync();

            if (!success) return Results.BadRequest();

            return Results.NoContent();
        }
        catch
        {
        }

        return Results.BadRequest("Unable to update the entity");

    }

    // DELETE api/<FilmsController>/5
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        try
        {
            var success = await _db.DeleteAsync<Film>(id);

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
