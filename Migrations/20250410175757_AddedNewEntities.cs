using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicalCollection.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlaylistTracks",
                keyColumns: new[] { "PlaylistId", "TrackId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 2,
                column: "Label",
                value: "Republic Records");

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Biography", "Country", "DisbandDate", "FormationDate", "Genres", "Name" },
                values: new object[,]
                {
                    { 3, "Linkin Park was an American rock band known for blending nu metal, alternative rock, and rap.", "USA", new DateTime(2017, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock, Nu Metal, Alternative", "Linkin Park" },
                    { 4, "Taylor Swift is an American singer-songwriter known for narrative songs and genre-crossing albums.", "USA", null, new DateTime(2006, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pop, Country, Folk", "Taylor Swift" },
                    { 5, "Imagine Dragons is an American pop rock band from Las Vegas known for energetic hits and anthemic sound.", "USA", null, new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pop Rock, Electropop", "Imagine Dragons" }
                });

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 4, 10, 17, 57, 57, 188, DateTimeKind.Utc).AddTicks(4223));

            migrationBuilder.UpdateData(
                table: "UserCollections",
                keyColumn: "UserCollectionId",
                keyValue: 1,
                column: "AdditionDate",
                value: new DateTime(2025, 4, 10, 17, 57, 57, 188, DateTimeKind.Utc).AddTicks(4190));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 4, 10, 17, 57, 57, 188, DateTimeKind.Utc).AddTicks(4173));

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "AlbumId", "ArtistId", "Format", "Genres", "Label", "NumberOfTracks", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 3, 3, 0, "Nu Metal,Alternative", "Warner Bros.", 12, new DateOnly(2000, 10, 24), "Hybrid Theory" },
                    { 4, 4, 0, "Pop,Synth-pop", "Big Machine", 13, new DateOnly(2014, 10, 27), "1989" },
                    { 5, 5, 2, "Pop Rock,Alternative", "KIDinaKORNER, Interscope", 11, new DateOnly(2017, 6, 23), "Evolve" },
                    { 6, 3, 0, "Nu Metal,Alternative", "Warner Bros.", 13, new DateOnly(2003, 3, 25), "Meteora" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "TrackId", "AlbumId", "Length", "PositionInAlbum", "Songwriters", "Title" },
                values: new object[,]
                {
                    { 5, 3, new TimeSpan(0, 0, 3, 36, 0), 8, "Linkin Park", "In the End" },
                    { 6, 4, new TimeSpan(0, 0, 3, 51, 0), 2, "Taylor Swift, Max Martin, Shellback", "Blank Space" },
                    { 7, 5, new TimeSpan(0, 0, 3, 24, 0), 1, "Imagine Dragons", "Believer" },
                    { 8, 6, new TimeSpan(0, 0, 3, 7, 0), 13, "Linkin Park", "Numb" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 2,
                column: "Label",
                value: "Republick Records");

            migrationBuilder.InsertData(
                table: "PlaylistTracks",
                columns: new[] { "PlaylistId", "TrackId", "Position" },
                values: new object[] { 1, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 4, 10, 15, 44, 2, 536, DateTimeKind.Utc).AddTicks(2398));

            migrationBuilder.UpdateData(
                table: "UserCollections",
                keyColumn: "UserCollectionId",
                keyValue: 1,
                column: "AdditionDate",
                value: new DateTime(2025, 4, 10, 15, 44, 2, 536, DateTimeKind.Utc).AddTicks(2373));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 4, 10, 15, 44, 2, 536, DateTimeKind.Utc).AddTicks(2359));
        }
    }
}
