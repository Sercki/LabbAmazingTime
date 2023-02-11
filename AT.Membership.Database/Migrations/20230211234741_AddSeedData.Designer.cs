﻿// <auto-generated />
using System;
using AT.Membership.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AT.Membership.Database.Migrations
{
    [DbContext(typeof(ATContext))]
    [Migration("20230211234741_AddSeedData")]
    partial class AddSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AT.Membership.Database.Entities.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "David Benioff"
                        });
                });

            modelBuilder.Entity("AT.Membership.Database.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<string>("FilmUrl")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<bool?>("Free")
                        .HasColumnType("bit");

                    b.Property<string>("Released")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Thumbnail")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "It is an American fantasy drama television series created for HBO",
                            DirectorId = 1,
                            FilmUrl = "https://www.youtube.com/watch?v=KPLWWIOCOOQ",
                            Free = true,
                            Released = "17.04.2011",
                            Thumbnail = "/images/GoT.jpg",
                            Title = "Game of Thrones"
                        });
                });

            modelBuilder.Entity("AT.Membership.Database.Entities.FilmGenre", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("FilmGenres", (string)null);

                    b.HasData(
                        new
                        {
                            FilmId = 1,
                            GenreId = 3
                        });
                });

            modelBuilder.Entity("AT.Membership.Database.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Fantasy"
                        });
                });

            modelBuilder.Entity("AT.Membership.Database.Entities.SimilarFilms", b =>
                {
                    b.Property<int>("ParentFilmId")
                        .HasColumnType("int");

                    b.Property<int>("SimilarFilmId")
                        .HasColumnType("int");

                    b.HasKey("ParentFilmId", "SimilarFilmId");

                    b.HasIndex("SimilarFilmId");

                    b.ToTable("FilmsSimilar");

                    b.HasData(
                        new
                        {
                            ParentFilmId = 1,
                            SimilarFilmId = 1
                        });
                });

            modelBuilder.Entity("AT.Membership.Database.Entities.Film", b =>
                {
                    b.HasOne("AT.Membership.Database.Entities.Director", "Director")
                        .WithMany("Films")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("AT.Membership.Database.Entities.FilmGenre", b =>
                {
                    b.HasOne("AT.Membership.Database.Entities.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AT.Membership.Database.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("AT.Membership.Database.Entities.SimilarFilms", b =>
                {
                    b.HasOne("AT.Membership.Database.Entities.Film", "ParentFilm")
                        .WithMany("SimilarFilms")
                        .HasForeignKey("ParentFilmId")
                        .IsRequired();

                    b.HasOne("AT.Membership.Database.Entities.Film", "SimilarFilm")
                        .WithMany()
                        .HasForeignKey("SimilarFilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentFilm");

                    b.Navigation("SimilarFilm");
                });

            modelBuilder.Entity("AT.Membership.Database.Entities.Director", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("AT.Membership.Database.Entities.Film", b =>
                {
                    b.Navigation("SimilarFilms");
                });
#pragma warning restore 612, 618
        }
    }
}
