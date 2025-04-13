﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicalCollection.Data;

#nullable disable

namespace MusicalCollection.Migrations
{
    [DbContext(typeof(MusicalCollectionDbContext))]
    partial class MusicalCollectionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MusicalCollection.Entities.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumId"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("Format")
                        .HasColumnType("int");

                    b.Property<string>("Genres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Length")
                        .HasColumnType("time");

                    b.Property<int>("NumberOfTracks")
                        .HasColumnType("int");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            AlbumId = 1,
                            ArtistId = 1,
                            Format = 1,
                            Genres = "Rock,Pop",
                            Label = "Apple Records",
                            Length = new TimeSpan(0, 0, 0, 0, 0),
                            NumberOfTracks = 17,
                            ReleaseDate = new DateOnly(1969, 9, 26),
                            Title = "Abbey Road"
                        },
                        new
                        {
                            AlbumId = 2,
                            ArtistId = 2,
                            Format = 0,
                            Genres = "Rock,Glam",
                            Label = "Republic Records",
                            Length = new TimeSpan(0, 0, 0, 0, 0),
                            NumberOfTracks = 13,
                            ReleaseDate = new DateOnly(1982, 9, 26),
                            Title = "Thundertruck"
                        },
                        new
                        {
                            AlbumId = 3,
                            ArtistId = 3,
                            Format = 0,
                            Genres = "Nu Metal,Alternative",
                            Label = "Warner Bros.",
                            Length = new TimeSpan(0, 0, 0, 0, 0),
                            NumberOfTracks = 12,
                            ReleaseDate = new DateOnly(2000, 10, 24),
                            Title = "Hybrid Theory"
                        },
                        new
                        {
                            AlbumId = 4,
                            ArtistId = 4,
                            Format = 0,
                            Genres = "Pop,Synth-pop",
                            Label = "Big Machine",
                            Length = new TimeSpan(0, 0, 0, 0, 0),
                            NumberOfTracks = 13,
                            ReleaseDate = new DateOnly(2014, 10, 27),
                            Title = "1989"
                        },
                        new
                        {
                            AlbumId = 5,
                            ArtistId = 5,
                            Format = 2,
                            Genres = "Pop Rock,Alternative",
                            Label = "KIDinaKORNER, Interscope",
                            Length = new TimeSpan(0, 0, 0, 0, 0),
                            NumberOfTracks = 11,
                            ReleaseDate = new DateOnly(2017, 6, 23),
                            Title = "Evolve"
                        },
                        new
                        {
                            AlbumId = 6,
                            ArtistId = 3,
                            Format = 0,
                            Genres = "Nu Metal,Alternative",
                            Label = "Warner Bros.",
                            Length = new TimeSpan(0, 0, 0, 0, 0),
                            NumberOfTracks = 13,
                            ReleaseDate = new DateOnly(2003, 3, 25),
                            Title = "Meteora"
                        });
                });

            modelBuilder.Entity("MusicalCollection.Entities.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArtistId"));

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DisbandDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FormationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            ArtistId = 1,
                            Biography = "The Beatles were an English rock band formed in Liverpool in 1960.",
                            Country = "United Kingdom",
                            DisbandDate = new DateTime(1970, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FormationDate = new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genres = "Rock, Pop",
                            Name = "The Beatles"
                        },
                        new
                        {
                            ArtistId = 2,
                            Biography = "AC/DC is a cool rocking band",
                            Country = "Australia",
                            DisbandDate = new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FormationDate = new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genres = "Rock, Rock'n'Roll",
                            Name = "AC/DC"
                        },
                        new
                        {
                            ArtistId = 3,
                            Biography = "Linkin Park was an American rock band known for blending nu metal, alternative rock, and rap.",
                            Country = "USA",
                            DisbandDate = new DateTime(2017, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FormationDate = new DateTime(1996, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genres = "Rock, Nu Metal, Alternative",
                            Name = "Linkin Park"
                        },
                        new
                        {
                            ArtistId = 4,
                            Biography = "Taylor Swift is an American singer-songwriter known for narrative songs and genre-crossing albums.",
                            Country = "USA",
                            FormationDate = new DateTime(2006, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genres = "Pop, Country, Folk",
                            Name = "Taylor Swift"
                        },
                        new
                        {
                            ArtistId = 5,
                            Biography = "Imagine Dragons is an American pop rock band from Las Vegas known for energetic hits and anthemic sound.",
                            Country = "USA",
                            FormationDate = new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genres = "Pop Rock, Electropop",
                            Name = "Imagine Dragons"
                        });
                });

            modelBuilder.Entity("MusicalCollection.Entities.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaylistId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlaylistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistId");

                    b.HasIndex("UserId");

                    b.ToTable("Playlists");

                    b.HasData(
                        new
                        {
                            PlaylistId = 1,
                            CreationDate = new DateTime(2025, 4, 11, 12, 24, 47, 180, DateTimeKind.Utc).AddTicks(5618),
                            PlaylistName = "Favorites",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("MusicalCollection.Entities.PlaylistTrack", b =>
                {
                    b.Property<int>("PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("PlaylistId", "TrackId");

                    b.HasIndex("TrackId");

                    b.ToTable("PlaylistTracks");

                    b.HasData(
                        new
                        {
                            PlaylistId = 1,
                            TrackId = 1,
                            Position = 1
                        });
                });

            modelBuilder.Entity("MusicalCollection.Entities.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("AlbumId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            ReviewId = 1,
                            AlbumId = 1,
                            Comment = "One of the best albums ever!",
                            Rating = 5,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("MusicalCollection.Entities.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrackId"));

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Length")
                        .HasColumnType("time");

                    b.Property<int>("PositionInAlbum")
                        .HasColumnType("int");

                    b.Property<string>("Songwriters")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrackId");

                    b.HasIndex("AlbumId");

                    b.ToTable("Tracks");

                    b.HasData(
                        new
                        {
                            TrackId = 1,
                            AlbumId = 1,
                            Length = new TimeSpan(0, 0, 4, 19, 0),
                            PositionInAlbum = 1,
                            Songwriters = "John Lennon, Paul McCartney",
                            Title = "Come Together"
                        },
                        new
                        {
                            TrackId = 2,
                            AlbumId = 1,
                            Length = new TimeSpan(0, 0, 3, 2, 0),
                            PositionInAlbum = 2,
                            Songwriters = "George Harrison",
                            Title = "Something"
                        },
                        new
                        {
                            TrackId = 3,
                            AlbumId = 2,
                            Length = new TimeSpan(0, 0, 2, 5, 0),
                            PositionInAlbum = 5,
                            Songwriters = "George Harrison",
                            Title = "Thundertruck"
                        },
                        new
                        {
                            TrackId = 4,
                            AlbumId = 2,
                            Length = new TimeSpan(0, 0, 3, 5, 0),
                            PositionInAlbum = 6,
                            Songwriters = "George Harrison",
                            Title = "Hells Bells"
                        },
                        new
                        {
                            TrackId = 5,
                            AlbumId = 3,
                            Length = new TimeSpan(0, 0, 3, 36, 0),
                            PositionInAlbum = 8,
                            Songwriters = "Linkin Park",
                            Title = "In the End"
                        },
                        new
                        {
                            TrackId = 6,
                            AlbumId = 4,
                            Length = new TimeSpan(0, 0, 3, 51, 0),
                            PositionInAlbum = 2,
                            Songwriters = "Taylor Swift, Max Martin, Shellback",
                            Title = "Blank Space"
                        },
                        new
                        {
                            TrackId = 7,
                            AlbumId = 5,
                            Length = new TimeSpan(0, 0, 3, 24, 0),
                            PositionInAlbum = 1,
                            Songwriters = "Imagine Dragons",
                            Title = "Believer"
                        },
                        new
                        {
                            TrackId = 8,
                            AlbumId = 6,
                            Length = new TimeSpan(0, 0, 3, 7, 0),
                            PositionInAlbum = 13,
                            Songwriters = "Linkin Park",
                            Title = "Numb"
                        });
                });

            modelBuilder.Entity("MusicalCollection.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CreationDate = new DateTime(2025, 4, 11, 12, 24, 47, 180, DateTimeKind.Utc).AddTicks(5568),
                            FirstName = "John",
                            LastName = "Doe"
                        });
                });

            modelBuilder.Entity("MusicalCollection.Entities.UserCollection", b =>
                {
                    b.Property<int>("UserCollectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserCollectionId"));

                    b.Property<DateTime>("AdditionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserCollectionId");

                    b.HasIndex("AlbumId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCollections");

                    b.HasData(
                        new
                        {
                            UserCollectionId = 1,
                            AdditionDate = new DateTime(2025, 4, 11, 12, 24, 47, 180, DateTimeKind.Utc).AddTicks(5584),
                            AlbumId = 1,
                            Status = 0,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("MusicalCollection.Entities.Album", b =>
                {
                    b.HasOne("MusicalCollection.Entities.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("MusicalCollection.Entities.Playlist", b =>
                {
                    b.HasOne("MusicalCollection.Entities.User", "Creator")
                        .WithMany("Playlists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("MusicalCollection.Entities.PlaylistTrack", b =>
                {
                    b.HasOne("MusicalCollection.Entities.Playlist", "Playlist")
                        .WithMany("PlaylistTracks")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicalCollection.Entities.Track", "Track")
                        .WithMany("PlaylistTracks")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("MusicalCollection.Entities.Review", b =>
                {
                    b.HasOne("MusicalCollection.Entities.Album", "Album")
                        .WithMany("Reviews")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicalCollection.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MusicalCollection.Entities.Track", b =>
                {
                    b.HasOne("MusicalCollection.Entities.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("MusicalCollection.Entities.UserCollection", b =>
                {
                    b.HasOne("MusicalCollection.Entities.Album", "Album")
                        .WithMany("UserCollections")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicalCollection.Entities.User", "User")
                        .WithMany("Collections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MusicalCollection.Entities.Album", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Tracks");

                    b.Navigation("UserCollections");
                });

            modelBuilder.Entity("MusicalCollection.Entities.Artist", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("MusicalCollection.Entities.Playlist", b =>
                {
                    b.Navigation("PlaylistTracks");
                });

            modelBuilder.Entity("MusicalCollection.Entities.Track", b =>
                {
                    b.Navigation("PlaylistTracks");
                });

            modelBuilder.Entity("MusicalCollection.Entities.User", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("Playlists");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
