using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aspdotnetkar.Migrations
{
    /// <inheritdoc />
    public partial class _1mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blogCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogCategoryTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceCategoryTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BlogShortdescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    BlogText = table.Column<string>(type: "nvarchar", nullable: false),
                    BlogCreateDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogVisitCount = table.Column<int>(type: "int", nullable: false),
                    BlogsId = table.Column<int>(type: "int", nullable: false),
                    BlogCategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blogs_blogCategories_BlogCategoriesId",
                        column: x => x.BlogCategoriesId,
                        principalTable: "blogCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServiceShortdescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ServiceText = table.Column<string>(type: "nvarchar", nullable: false),
                    ServiceImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteServiceId = table.Column<int>(type: "int", nullable: false),
                    serviceCategorieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_services_ServiceCategories_serviceCategorieId",
                        column: x => x.serviceCategorieId,
                        principalTable: "ServiceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blogs_BlogCategoriesId",
                table: "blogs",
                column: "BlogCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_services_serviceCategorieId",
                table: "services",
                column: "serviceCategorieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blogs");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "blogCategories");

            migrationBuilder.DropTable(
                name: "ServiceCategories");
        }
    }
}
