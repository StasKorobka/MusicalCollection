using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicalCollection.Migrations
{
    /// <inheritdoc />
    public partial class AddedRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
