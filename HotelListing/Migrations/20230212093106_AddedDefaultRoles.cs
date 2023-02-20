using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelListing.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7149c146-b874-4575-9889-c7e04b63266a", "084ed818-1dc4-4bbd-9032-6b8e54767b37", "Administrator", "ADMINISTRATOR" },
                    { "ed71d417-f4c1-4a28-a323-371a6f80ca92", "b13817a4-21ff-497d-8041-932588d74b69", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7149c146-b874-4575-9889-c7e04b63266a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed71d417-f4c1-4a28-a323-371a6f80ca92");
        }
    }
}
