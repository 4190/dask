using Microsoft.EntityFrameworkCore.Migrations;

namespace Dask.Data.Migrations
{
    public partial class AddedQuestionTableToDatabaseButDeletedSurveyIdprop2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Surveys_SurveyId1",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SurveyId1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SurveyId1",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "SurveyId",
                table: "Questions",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions");

            migrationBuilder.AlterColumn<string>(
                name: "SurveyId",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SurveyId1",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyId1",
                table: "Questions",
                column: "SurveyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Surveys_SurveyId1",
                table: "Questions",
                column: "SurveyId1",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
