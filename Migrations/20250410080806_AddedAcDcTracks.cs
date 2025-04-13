using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicalCollection.Migrations
{
    /// <inheritdoc />
    public partial class AddedAcDcTracks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Biography", "Country", "DisbandDate", "FormationDate", "Genres", "Name" },
                values: new object[] { 2, "AC/DC is a cool rocking band", "Australia", new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock, Rock'n'Roll", "AC/DC" });

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 4, 10, 8, 8, 6, 128, DateTimeKind.Utc).AddTicks(3927));

            migrationBuilder.UpdateData(
                table: "UserCollections",
                keyColumn: "UserCollectionId",
                keyValue: 1,
                column: "AdditionDate",
                value: new DateTime(2025, 4, 10, 8, 8, 6, 128, DateTimeKind.Utc).AddTicks(3898));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 4, 10, 8, 8, 6, 128, DateTimeKind.Utc).AddTicks(3883));

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "AlbumId", "ArtistId", "Format", "Genres", "Label", "NumberOfTracks", "ReleaseDate", "Title" },
                values: new object[] { 2, 2, 0, "Rock,Glam", "Republick Records", 13, new DateOnly(1982, 9, 26), "Thundertruck" });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "TrackId", "AlbumId", "Length", "PositionInAlbum", "Songwriters", "Title" },
                values: new object[,]
                {
                    { 3, 2, new TimeSpan(0, 0, 2, 5, 0), 5, "George Harrison", "Thundertruck" },
                    { 4, 2, new TimeSpan(0, 0, 3, 5, 0), 6, "George Harrison", "Hells Bells" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 4, 10, 5, 11, 41, 77, DateTimeKind.Utc).AddTicks(4067));

            migrationBuilder.UpdateData(
                table: "UserCollections",
                keyColumn: "UserCollectionId",
                keyValue: 1,
                column: "AdditionDate",
                value: new DateTime(2025, 4, 10, 5, 11, 41, 77, DateTimeKind.Utc).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 4, 10, 5, 11, 41, 77, DateTimeKind.Utc).AddTicks(4025));
        }
    }
}
