using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicalCollection.Migrations
{
    /// <inheritdoc />
    public partial class FixedAlbumLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lenght",
                table: "Albums",
                newName: "Length");

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 4, 11, 12, 24, 47, 180, DateTimeKind.Utc).AddTicks(5618));

            migrationBuilder.UpdateData(
                table: "UserCollections",
                keyColumn: "UserCollectionId",
                keyValue: 1,
                column: "AdditionDate",
                value: new DateTime(2025, 4, 11, 12, 24, 47, 180, DateTimeKind.Utc).AddTicks(5584));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 4, 11, 12, 24, 47, 180, DateTimeKind.Utc).AddTicks(5568));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Length",
                table: "Albums",
                newName: "Lenght");

            migrationBuilder.UpdateData(
                table: "Playlists",
                keyColumn: "PlaylistId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 4, 11, 10, 37, 1, 771, DateTimeKind.Utc).AddTicks(6479));

            migrationBuilder.UpdateData(
                table: "UserCollections",
                keyColumn: "UserCollectionId",
                keyValue: 1,
                column: "AdditionDate",
                value: new DateTime(2025, 4, 11, 10, 37, 1, 771, DateTimeKind.Utc).AddTicks(6449));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 4, 11, 10, 37, 1, 771, DateTimeKind.Utc).AddTicks(6434));
        }
    }
}
