using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Template.Trunk.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTypes", x => x.Id);
                    table.UniqueConstraint("AK_MessageTypes_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmendedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmendedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "WsRequestResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ErrorCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    MessageDefinitionCode = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WsRequestResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WsRequestResponses_MessageTypes_MessageDefinitionCode",
                        column: x => x.MessageDefinitionCode,
                        principalTable: "MessageTypes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastActivityAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserCode = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSessions_Users_UserCode",
                        column: x => x.UserCode,
                        principalTable: "Users",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MessageTypes",
                columns: new[] { "Id", "Category", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "", "USER001", "Generate token (Create user session)" },
                    { 2, "", "USER002", "Refresh token (Re-generate user session)" },
                    { 3, "", "USER003", "Revoke token (Delete user session)" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AmendedBy", "AmendedOn", "Code", "CreateBy", "CreatedOn", "EmailAddress", "Name", "PasswordHash" },
                values: new object[] { 1, null, null, "LMXIA08799", "LMXIA08799", new DateTime(2024, 10, 21, 15, 30, 30, 780, DateTimeKind.Local).AddTicks(5858), "jimmy.vtp94@gmail.com", "Aministrator", "AQAAAAIAAYagAAAAEO5Clk0JItIXK2Q2lqCVVIPdJrlDQw5MgstNkZEaR/eQ3HLceIpf1wVkZ+jKDnYMTg==" });

            migrationBuilder.CreateIndex(
                name: "IX_MessageTypes_Code",
                table: "MessageTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessageTypes_Id",
                table: "MessageTypes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Code",
                table: "Users",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_Code",
                table: "UserSessions",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_Id",
                table: "UserSessions",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_UserCode",
                table: "UserSessions",
                column: "UserCode");

            migrationBuilder.CreateIndex(
                name: "IX_WsRequestResponses_Code",
                table: "WsRequestResponses",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WsRequestResponses_Id",
                table: "WsRequestResponses",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WsRequestResponses_MessageDefinitionCode",
                table: "WsRequestResponses",
                column: "MessageDefinitionCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSessions");

            migrationBuilder.DropTable(
                name: "WsRequestResponses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MessageTypes");
        }
    }
}
