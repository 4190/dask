using Microsoft.EntityFrameworkCore.Migrations;

namespace Dask.Data.Migrations
{
    public partial class NoAuthorAnymore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Surveys",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Surveys");
        }
    }
}
