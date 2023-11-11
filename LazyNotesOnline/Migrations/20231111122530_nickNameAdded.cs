using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LazyNotesOnline.Migrations
{
    /// <inheritdoc />
    public partial class nickNameAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "User",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_User_NickName",
                table: "User",
                column: "NickName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_NickName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "User");
        }
    }
}
