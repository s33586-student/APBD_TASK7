using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APBD_TASK7.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Components",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2147483647,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ComponentManufacturers",
                columns: new[] { "Id", "Abbreviation", "FoundationDate", "FullName" },
                values: new object[,]
                {
                    { 1, "INT", new DateTime(1968, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Corporation" },
                    { 2, "NVD", new DateTime(1993, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "NVIDIA Corporation" },
                    { 3, "RZR", new DateTime(1998, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Razer Incorporation" }
                });

            migrationBuilder.InsertData(
                table: "ComponentTypes",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 1, "CPU", "Processor" },
                    { 2, "GPU", "Graphics Card" },
                    { 3, "RAM", "Memory" }
                });

            migrationBuilder.InsertData(
                table: "PCs",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Beast X", 5, 36, 12.5 },
                    { 2, new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Office Mini Pro", 12, 24, 4.2000000000000002 },
                    { 3, new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student Basic PC", 20, 12, 6.7999999999999998 }
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Code", "ComponentManufacturerId", "ComponentTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { "CPU001", 1, 1, "High performance processor", "Intel i7" },
                    { "GPU001", 2, 2, "Gaming graphics card", "RTX 4070" },
                    { "RAM001", 3, 3, "Memory module", "Razer Blade 32GB" }
                });

            migrationBuilder.InsertData(
                table: "PCComponents",
                columns: new[] { "ComponentCode", "PcId", "Amount" },
                values: new object[,]
                {
                    { "CPU001", 1, 1 },
                    { "GPU001", 1, 1 },
                    { "RAM001", 1, 2 },
                    { "CPU001", 2, 1 },
                    { "RAM001", 2, 1 },
                    { "RAM001", 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "CPU001", 1 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "GPU001", 1 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "RAM001", 1 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "CPU001", 2 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "RAM001", 2 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PcId" },
                keyValues: new object[] { "RAM001", 3 });

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "CPU001");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "GPU001");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "RAM001");

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Components",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2147483647);
        }
    }
}
