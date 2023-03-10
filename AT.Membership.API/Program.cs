using AT.Common.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsAllAccessPolicy", opt =>
    opt.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    );
});

// Add services to the container.
//manage nugget packages => add =>Microsoft.AspNetCore.Mvc.NewtonsoftJson   than change add controllers to:
//builder.Services.AddControllers().AddNewtonsoftJson(options =>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ATContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("ATConnection")));


var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<Director, DirectorDTO>().ReverseMap();
    cfg.CreateMap<DirectorCreateDTO, Director>();
    cfg.CreateMap<DirectorEditDTO, Director>();

    cfg.CreateMap<Film, FilmDTO>()
     .ForMember(dest => dest.DirectorName, src => src.MapFrom(s => s.Director.Name))
     .ReverseMap()
     .ForMember(dest => dest.Director, src => src.Ignore());
    cfg.CreateMap<FilmCreateDTO, Film>();
    cfg.CreateMap<FilmEditDTO, Film>();

    cfg.CreateMap<FilmGenre, FilmGenreDTO>()
     .ForMember(dest => dest.GenreTitle, src => src.MapFrom(s => s.Genre.Name))
     .ForMember(dest => dest.FilmTitle, src => src.MapFrom(s => s.Film.Title))
     .ReverseMap()
     .ForMember(dest => dest.Genre, src => src.Ignore())
     .ForMember(dest => dest.Film, src => src.Ignore());

    cfg.CreateMap<FilmGenrePutDeleteDTO, FilmGenre>();

	cfg.CreateMap<Genre, GenreDTO>().ReverseMap();
	cfg.CreateMap<Genre, GenreBaseDTO>();
	cfg.CreateMap<GenreCreateDTO, Genre>();
    cfg.CreateMap<GenreEditDTO, Genre>();

    cfg.CreateMap<SimilarFilms, SimilarFilmsDTO>()
    .ForMember(dest => dest.ParentFilmTitle, src => src.MapFrom(s => s.ParentFilm.Title))
    .ForMember(dest => dest.SimilarFilmTitle, src => src.MapFrom(s => s.SimilarFilm.Title))
    .ReverseMap()
    .ForMember(dest => dest.ParentFilm, src => src.Ignore())
    .ForMember(dest => dest.SimilarFilm, src => src.Ignore());

	cfg.CreateMap<SimilarFilmsPutDeleteDTO, SimilarFilms>();

	////-----------------------------------EXPERIMENTAL--------------------------------
	//cfg.CreateMap<Director, DirectorDTO>().ReverseMap()
	//.ForMember(dest => dest.Films, src => src.Ignore());

	////?r films filmsDTO ok?
	//cfg.CreateMap<Film, FilmDTO>()
	//.ForMember(dest => dest.DirectorName, src => src.MapFrom(s => s.Director.Name))
	//.ForMember(dest => dest.MainFilmIdinSimilar, src => src.Ignore())
	//.ForMember(dest => dest.SimilarFilmTitles, src => src.MapFrom(s => s.SimilarFilms))
	//.ForMember(dest => dest.GenreTitles, src => src.MapFrom(s => s.Genres))
	//.ReverseMap()
	//.ForMember(dest => dest.Director, src => src.Ignore())
	//.ForMember(dest => dest.SimilarFilms, src => src.Ignore())
	//.ForMember(dest => dest.Genres, src => src.Ignore());

	//cfg.CreateMap<FilmGenre, FilmGenreDTO>().ReverseMap()
	//.ForMember(dest => dest.Genre, src => src.Ignore())
	//.ForMember(dest => dest.Film, src => src.Ignore());

	////?r genre genreDTO ok?
	//cfg.CreateMap<Genre, GenreDTO>().ReverseMap();

	//cfg.CreateMap<SimilarFilms, SimilarFilmsDTO>()
	//.ForMember(dest => dest.ParentFilmTitle, src => src.MapFrom(s => s.ParentFilm.Title))
	//.ForMember(dest => dest.SimilarFilmTitle, src => src.MapFrom(s => s.SimilarFilm.Title))
	//.ReverseMap()
	//.ForMember(dest => dest.ParentFilm, src => src.Ignore())
	//.ForMember(dest => dest.SimilarFilm, src => src.Ignore());

	////----------------------END----------------------------------------------
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IDbService, DbService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsAllAccessPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
