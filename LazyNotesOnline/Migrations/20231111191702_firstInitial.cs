using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LazyNotesOnline.Migrations
{
    /// <inheritdoc />
    public partial class firstInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cat_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Įrašokategorija = table.Column<string>(name: "Įrašo kategorija", type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Content_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentCreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Turinys = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cat_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoteContentContent_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Content_Id);
                    table.ForeignKey(
                        name: "FK_Contents_Categories_Cat_Id",
                        column: x => x.Cat_Id,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contents_Contents_NoteContentContent_Id",
                        column: x => x.NoteContentContent_Id,
                        principalTable: "Contents",
                        principalColumn: "Content_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_Cat_Id",
                table: "Contents",
                column: "Cat_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_NoteContentContent_Id",
                table: "Contents",
                column: "NoteContentContent_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NickName",
                table: "Users",
                column: "NickName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
