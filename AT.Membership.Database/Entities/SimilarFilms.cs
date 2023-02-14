namespace AT.Membership.Database.Entities;

public class SimilarFilms : IReferenceEntity
{
    public int ParentFilmId { get; set; }
    public int SimilarFilmId { get; set; }

    public virtual Film? ParentFilm { get; set; }    
    [ForeignKey("SimilarFilmId")]
    public virtual Film? SimilarFilm { get; set; }
}
