using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VaccinationCardId",
                table: "VaccinationInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationInfo_VaccinationCardId",
                table: "VaccinationInfo",
                column: "VaccinationCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationInfo_VaccinationCard_VaccinationCardId",
                table: "VaccinationInfo",
                column: "VaccinationCardId",
                principalTable: "VaccinationCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationInfo_VaccinationCard_VaccinationCardId",
                table: "VaccinationInfo");

            migrationBuilder.DropIndex(
                name: "IX_VaccinationInfo_VaccinationCardId",
                table: "VaccinationInfo");

            migrationBuilder.DropColumn(
                name: "VaccinationCardId",
                table: "VaccinationInfo");
        }
    }
}
