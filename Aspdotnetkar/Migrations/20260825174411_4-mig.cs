using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aspdotnetkar.Migrations
{
    /// <inheritdoc />
    public partial class _4mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_services_ServiceCategories_serviceCategorieId",
                table: "services");

            migrationBuilder.DropIndex(
                name: "IX_services_serviceCategorieId",
                table: "services");

            migrationBuilder.DropColumn(
                name: "serviceCategorieId",
                table: "services");

            migrationBuilder.CreateIndex(
                name: "IX_services_SiteServiceId",
                table: "services",
                column: "SiteServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_services_ServiceCategories_SiteServiceId",
                table: "services",
                column: "SiteServiceId",
                principalTable: "ServiceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_services_ServiceCategories_SiteServiceId",
                table: "services");

            migrationBuilder.DropIndex(
                name: "IX_services_SiteServiceId",
                table: "services");

            migrationBuilder.AddColumn<int>(
                name: "serviceCategorieId",
                table: "services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_services_serviceCategorieId",
                table: "services",
                column: "serviceCategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_services_ServiceCategories_serviceCategorieId",
                table: "services",
                column: "serviceCategorieId",
                principalTable: "ServiceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
