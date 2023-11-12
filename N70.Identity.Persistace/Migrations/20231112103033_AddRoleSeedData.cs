using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace N70.Identity.Persistace.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 12, 10, 30, 33, 578, DateTimeKind.Utc).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d07ea1f-9be7-48f0-ad91-5b83a5806baf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 12, 10, 30, 33, 578, DateTimeKind.Utc).AddTicks(3036));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("df290f92-dd78-4fa7-9ce3-6b0056a8b68f"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 12, 10, 30, 33, 578, DateTimeKind.Utc).AddTicks(3038));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 12, 10, 29, 9, 599, DateTimeKind.Utc).AddTicks(7505));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d07ea1f-9be7-48f0-ad91-5b83a5806baf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 12, 10, 29, 9, 599, DateTimeKind.Utc).AddTicks(7507));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("df290f92-dd78-4fa7-9ce3-6b0056a8b68f"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 12, 10, 29, 9, 599, DateTimeKind.Utc).AddTicks(7508));
        }
    }
}
