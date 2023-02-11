namespace AT.Membership.Database.Entities;

public class FilmGenre: IReferenceEntity
{
    public int GenreId { get; set; }

    public int FilmId { get; set; }

    public virtual Genre? Genre { get; set; }

    public virtual Film? Film { get; set; }
}
