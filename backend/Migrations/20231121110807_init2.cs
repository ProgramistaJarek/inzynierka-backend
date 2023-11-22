using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeGroup",
                table: "VaccinationInfo");

            migrationBuilder.DropColumn(
                name: "TypeVaccinations",
                table: "VaccinationInfo");

            migrationBuilder.DropColumn(
                name: "VaccinationName",
                table: "VaccinationInfo");

            migrationBuilder.DropColumn(
                name: "VaccinvationSeries",
                table: "VaccinationInfo");

            migrationBuilder.AddColumn<int>(
                name: "AgeGroupId",
                table: "VaccinationInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeVaccinationId",
                table: "VaccinationInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationInfo_AgeGroupId",
                table: "VaccinationInfo",
                column: "AgeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationInfo_TypeVaccinationId",
                table: "VaccinationInfo",
                column: "TypeVaccinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationInfo_AgeGroups_AgeGroupId",
                table: "VaccinationInfo",
                column: "AgeGroupId",
                principalTable: "AgeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationInfo_TypesVaccines_TypeVaccinationId",
                table: "VaccinationInfo",
                column: "TypeVaccinationId",
                principalTable: "TypesVaccines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationInfo_AgeGroups_AgeGroupId",
                table: "VaccinationInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationInfo_TypesVaccines_TypeVaccinationId",
                table: "VaccinationInfo");

            migrationBuilder.DropIndex(
                name: "IX_VaccinationInfo_AgeGroupId",
                table: "VaccinationInfo");

            migrationBuilder.DropIndex(
                name: "IX_VaccinationInfo_TypeVaccinationId",
                table: "VaccinationInfo");

            migrationBuilder.DropColumn(
                name: "AgeGroupId",
                table: "VaccinationInfo");

            migrationBuilder.DropColumn(
                name: "TypeVaccinationId",
                table: "VaccinationInfo");

            migrationBuilder.AddColumn<string>(
                name: "AgeGroup",
                table: "VaccinationInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeVaccinations",
                table: "VaccinationInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VaccinationName",
                table: "VaccinationInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VaccinvationSeries",
                table: "VaccinationInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
