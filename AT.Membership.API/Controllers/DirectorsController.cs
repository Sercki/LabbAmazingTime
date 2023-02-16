
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using AT.Membership.Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AT.Membership.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DirectorsController : ControllerBase
{
    private readonly IDbService _db;

    public DirectorsController(IDbService db) => _db = db;
    
    // GET: api/<DirectorsController>
    [HttpGet]
    public async Task<IResult> Get()
    {
        try
        {
            _db.Include<Director>();  
            List<DirectorDTO>? directors = await _db.GetAsync<Director, DirectorDTO>();
                        
            return Results.Ok(directors);
        }
        catch
        {          
        }
        return Results.NotFound();
    }

    // GET api/<DirectorsController>/5
    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        try
        {
			_db.Include<Director>();
			var director = await _db.SingleAsync<Director, DirectorDTO>(c => c.Id.Equals(id));

            return Results.Ok(director);
        }
        catch
        {
        }
        return Results.NotFound();
    }

    // POST api/<DirectorsController>
    [HttpPost]
    public async Task<IResult> Post([FromBody] DirectorCreateDTO dto)
    {
        try
        {
            if (dto == null) return Results.BadRequest();

            var director = await _db.AddAsync<Director, DirectorCreateDTO>(dto);

            var success = await _db.SaveChangesAsync();

            if (!success) return Results.BadRequest();

            return Results.Created(_db.GetURI<Director>(director), director);
        }
        catch
        {
        }

        return Results.BadRequest();
    }

    // PUT api/<DirectorsController>/5
    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] DirectorEditDTO dto)
    {
        try
        {
            if (dto == null) return Results.BadRequest("No entity selected");
            if (!id.Equals(dto.Id)) return Results.BadRequest("Ids are different. Please check correct Id");

            var exists = await _db.AnyAsync<Director>(c => c.Id.Equals(id));
            if (!exists) return Results.NotFound("Could not find entity");

            _db.Update<Director, DirectorEditDTO>(dto.Id, dto);

            var success = await _db.SaveChangesAsync();

            if (!success) return Results.BadRequest();

            return Results.NoContent();
        }
        catch
        {
        }

        return Results.BadRequest("Unable to update the entity");

    }

    // DELETE api/<DirectorsController>/5
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        try
        {
            var success = await _db.DeleteAsync<Director>(id);

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
