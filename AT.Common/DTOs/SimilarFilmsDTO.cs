﻿namespace AT.Common.DTOs;

public class SimilarFilmsDTO
{
    public int ParentFilmId { get; set; }
    public int SimilarFilmId { get; set; }
    public string? ParentFilmTitle { get; set; }
    public string? SimilarFilmTitle { get; set; }
    //public virtual FilmDTO? ParentFilm { get; set; }
    //public virtual FilmDTO? SimilarFilm { get; set; }
}