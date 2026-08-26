using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aspdotnetkar.Migrations
{
    /// <inheritdoc />
    public partial class _3mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_blogCategories_BlogCategoriesId",
                table: "blogs");

            migrationBuilder.DropIndex(
                name: "IX_blogs_BlogCategoriesId",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "BlogCategoriesId",
                table: "blogs");

            migrationBuilder.RenameColumn(
                name: "BlogsId",
                table: "blogs",
                newName: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_CategoryId",
                table: "blogs",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_blogCategories_CategoryId",
                table: "blogs",
                column: "CategoryId",
                principalTable: "blogCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_blogCategories_CategoryId",
                table: "blogs");

            migrationBuilder.DropIndex(
                name: "IX_blogs_CategoryId",
                table: "blogs");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "blogs",
                newName: "BlogsId");

            migrationBuilder.AddColumn<int>(
                name: "BlogCategoriesId",
                table: "blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_blogs_BlogCategoriesId",
                table: "blogs",
                column: "BlogCategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_blogCategories_BlogCategoriesId",
                table: "blogs",
                column: "BlogCategoriesId",
                principalTable: "blogCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
