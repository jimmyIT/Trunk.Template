using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template.Trunk.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyEntity : Migration
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
                values: new object[] { 1, null, null, "FHEHT57172", "FHEHT57172", new DateTime(2024, 10, 22, 9, 19, 28, 391, DateTimeKind.Local).AddTicks(5101), "jimmy.vtp94@gmail.com", "Aministrator", "AQAAAAIAAYagAAAAEN/ACUl8jIvKQO4wxXNeYLcldk+sWQGW6qrmu1VgctCLIHNbgFIEJ0VL6UKD6TjESg==" });
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
                values: new object[] { 1, null, null, "NSGRI53511", "NSGRI53511", new DateTime(2024, 10, 22, 9, 16, 34, 495, DateTimeKind.Local).AddTicks(1248), "jimmy.vtp94@gmail.com", "Aministrator", "AQAAAAIAAYagAAAAEOEec7nib/qeN997cOoOqI/F9RfPhl+ydhm8RW41y1Gf9hcLtH+3OongO3SXhlflkw==" });
        }
    }
}
