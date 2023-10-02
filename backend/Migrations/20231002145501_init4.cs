using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phonenumber",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AgeGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesVaccines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesVaccines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAgeGroups = table.Column<int>(type: "int", nullable: false),
                    IdTypesVaccines = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgeGroupsId = table.Column<int>(type: "int", nullable: true),
                    TypesVaccinesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationSchedules_AgeGroups_AgeGroupsId",
                        column: x => x.AgeGroupsId,
                        principalTable: "AgeGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VaccinationSchedules_AgeGroups_IdAgeGroups",
                        column: x => x.IdAgeGroups,
                        principalTable: "AgeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinationSchedules_TypesVaccines_IdTypesVaccines",
                        column: x => x.IdTypesVaccines,
                        principalTable: "TypesVaccines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinationSchedules_TypesVaccines_TypesVaccinesId",
                        column: x => x.TypesVaccinesId,
                        principalTable: "TypesVaccines",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AgeGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Noworodek" },
                    { 2, "2 miesiąc życia" },
                    { 3, "3-4 miesiąc życia" },
                    { 4, "5-6 miesiąc życia" },
                    { 5, "7 miesiąc życia" },
                    { 6, "13-14 miesiąc życia" },
                    { 7, "16-18 miesiąc życia" },
                    { 8, "6 rok życia" },
                    { 9, "10 rok życia" },
                    { 10, "14 rok życia" },
                    { 11, "19 rok życia" }
                });

            migrationBuilder.InsertData(
                table: "TypesVaccines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Gruźlica BCG" },
                    { 2, "wzw B" },
                    { 3, "DTP" },
                    { 4, "Hib" },
                    { 5, "polio IPV" },
                    { 6, "odra, świnka, różyczka" },
                    { 7, "DTaP" },
                    { 8, "Td" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationSchedules_AgeGroupsId",
                table: "VaccinationSchedules",
                column: "AgeGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationSchedules_IdAgeGroups",
                table: "VaccinationSchedules",
                column: "IdAgeGroups");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationSchedules_IdTypesVaccines",
                table: "VaccinationSchedules",
                column: "IdTypesVaccines");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationSchedules_TypesVaccinesId",
                table: "VaccinationSchedules",
                column: "TypesVaccinesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccinationSchedules");

            migrationBuilder.DropTable(
                name: "AgeGroups");

            migrationBuilder.DropTable(
                name: "TypesVaccines");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Phonenumber",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "User");
        }
    }
}
