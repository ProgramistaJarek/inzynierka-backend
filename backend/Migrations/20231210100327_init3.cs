using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Patients",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Babysitters",
                newName: "Address");

            migrationBuilder.AddColumn<bool>(
                name: "Archive",
                table: "VaccinationCard",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archive",
                table: "VaccinationCard");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Patients",
                newName: "Adress");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Babysitters",
                newName: "Adress");
        }
    }
}
