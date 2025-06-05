using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZwalk.API.Migrations.NZWalksAuthDb
{
    /// <inheritdoc />
    public partial class Seedingdataupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "038bac7f-2346-4020-840c-aff60edbc9a4", "038bac7f-2346-4020-840c-aff60edbc9a4", "Writer", "WRITER" },
                    { "3bd12744-e173-4262-9ba2-96ef652eb871", "3bd12744-e173-4262-9ba2-96ef652eb871", "Reader", "READER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "038bac7f-2346-4020-840c-aff60edbc9a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bd12744-e173-4262-9ba2-96ef652eb871");
        }
    }
}
