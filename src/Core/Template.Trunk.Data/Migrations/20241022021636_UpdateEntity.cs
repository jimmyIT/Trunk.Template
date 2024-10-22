using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template.Trunk.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AmendedBy", "AmendedOn", "Code", "CreateBy", "CreatedOn", "EmailAddress", "Name", "PasswordHash" },
                values: new object[] { 1, null, null, "NSGRI53511", "NSGRI53511", new DateTime(2024, 10, 22, 9, 16, 34, 495, DateTimeKind.Local).AddTicks(1248), "jimmy.vtp94@gmail.com", "Aministrator", "AQAAAAIAAYagAAAAEOEec7nib/qeN997cOoOqI/F9RfPhl+ydhm8RW41y1Gf9hcLtH+3OongO3SXhlflkw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AmendedBy", "AmendedOn", "Code", "CreateBy", "CreatedOn", "EmailAddress", "Name", "PasswordHash" },
                values: new object[] { 1, null, null, "LMXIA08799", "LMXIA08799", new DateTime(2024, 10, 21, 15, 30, 30, 780, DateTimeKind.Local).AddTicks(5858), "jimmy.vtp94@gmail.com", "Aministrator", "AQAAAAIAAYagAAAAEO5Clk0JItIXK2Q2lqCVVIPdJrlDQw5MgstNkZEaR/eQ3HLceIpf1wVkZ+jKDnYMTg==" });
        }
    }
}
