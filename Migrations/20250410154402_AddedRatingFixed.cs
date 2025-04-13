using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicalCollection.Migrations
{
    /// <inheritdoc />
    public partial class AddedRatingFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 4, 10, 15, 36, 18, 121, DateTimeKind.Utc).AddTicks(8943));

            migrationBuilder.UpdateData(
                table: "UserCollections",
                keyColumn: "UserCollectionId",
                keyValue: 1,
                column: "AdditionDate",
                value: new DateTime(2025, 4, 10, 15, 36, 18, 121, DateTimeKind.Utc).AddTicks(8915));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 4, 10, 15, 36, 18, 121, DateTimeKind.Utc).AddTicks(8898));
        }
    }
}
