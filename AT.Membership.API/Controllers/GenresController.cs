﻿// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AT.Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenresController : ControllerBase
{
    private readonly IDbService _db;

    public GenresController(IDbService db) => _db = db;

    // GET: api/<GenresController>
    [HttpGet]
    public async Task<IResult> Get()
    {
        try
        {
            
            _db.Include<Genre>();
            //_db.Include<FilmGenre>();  //FUNGERAR INTE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            List<GenreDTO>? genres = await _db.GetAsync<Genre, GenreDTO>();
        
            return Results.Ok(genres);
        }
        catch
        {
        }
        return Results.NotFound();
    }

    // GET api/<GenresController>/5
    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        try
        {
            _db.Include<Genre>();
            var genres = await _db.SingleAsync<Genre, GenreDTO>(c => c.Id.Equals(id));

            return Results.Ok(genres);
        }
        catch
        {
        }
        return Results.NotFound();
    }

    // POST api/<GenresController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] GenreCreateDTO dto)
    {
        try
        {
            if (dto == null) return Results.BadRequest();

            var genre = await _db.AddAsync<Genre, GenreCreateDTO>(dto);

            var success = await _db.SaveChangesAsync();

            if (!success) return Results.BadRequest();

            return Results.Created(_db.GetURI<Genre>(genre), genre);
        }
        catch
        {
        }

        return Results.BadRequest();
    }

    // PUT api/<GenresController>/5
    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] GenreEditDTO dto)
    {
        try
        {
            if (dto == null) return Results.BadRequest("No entity selected");
            if (!id.Equals(dto.Id)) return Results.BadRequest("Ids are different. Please check correct Id");

            var exists = await _db.AnyAsync<Genre>(c => c.Id.Equals(id));
            if (!exists) return Results.NotFound("Could not find entity");

            _db.Update<Genre, GenreEditDTO>(dto.Id, dto);

            var success = await _db.SaveChangesAsync();

            if (!success) return Results.BadRequest();

            return Results.NoContent();
        }
        catch
        {
        }

        return Results.BadRequest("Unable to update the entity");

    }

    // DELETE api/<GenresController>/5
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        try
        {
            var success = await _db.DeleteAsync<Genre>(id);

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
