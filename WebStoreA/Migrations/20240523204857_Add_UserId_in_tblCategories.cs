using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStoreA.Migrations
{
    /// <inheritdoc />
    public partial class Add_UserId_in_tblCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "tblCategories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_tblCategories_UserId",
                table: "tblCategories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCategories_AspNetUsers_UserId",
                table: "tblCategories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCategories_AspNetUsers_UserId",
                table: "tblCategories");

            migrationBuilder.DropIndex(
                name: "IX_tblCategories_UserId",
                table: "tblCategories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tblCategories");
        }
    }
}
