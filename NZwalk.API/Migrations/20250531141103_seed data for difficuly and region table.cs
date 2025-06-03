using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZwalk.API.Migrations
{
    /// <inheritdoc />
    public partial class seeddatafordifficulyandregiontable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0a9bd599-69e7-4903-a0e5-3f51117192f1"), "Medium" },
                    { new Guid("c6c57173-772f-452a-bb7d-20e8d043c03b"), "Hard" },
                    { new Guid("ef63833b-47d7-4ab3-873a-3ad68444973b"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("2caea0ac-28de-4e21-bef5-5df893afbc23"), "NSN", "Nelson", "http://www.gettyimages.com/detail/503939548" },
                    { new Guid("8b872e8c-1ba1-4fa1-9cbf-04626675fe22"), "AKL", "Aukland", "https://www.alltrails.com/new-zealand/auckland/walking" },
                    { new Guid("a5300ed1-2603-4eb6-b810-c702f4a9c840"), "WGN", "Wellington", "https://www.eaxmple.com/Wellington/images" },
                    { new Guid("ca769d6b-19b6-45ba-ac37-74730d0eb1d0"), "NTL", "Northland", "https://www.eaxmple.com/Northland/images" },
                    { new Guid("d183a2fd-7256-4781-ad94-ca54c3e68277"), "STL", "Southland", "https://www.eaxmple.com/Southland/images" },
                    { new Guid("e7020c0f-931b-4fde-99bf-cbdff85c8c8f"), "BOP", "Bay of Plenty", "https://www.eaxmple.com/bayofplenty/images" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0a9bd599-69e7-4903-a0e5-3f51117192f1"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c6c57173-772f-452a-bb7d-20e8d043c03b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ef63833b-47d7-4ab3-873a-3ad68444973b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2caea0ac-28de-4e21-bef5-5df893afbc23"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8b872e8c-1ba1-4fa1-9cbf-04626675fe22"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a5300ed1-2603-4eb6-b810-c702f4a9c840"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ca769d6b-19b6-45ba-ac37-74730d0eb1d0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d183a2fd-7256-4781-ad94-ca54c3e68277"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e7020c0f-931b-4fde-99bf-cbdff85c8c8f"));
        }
    }
}
