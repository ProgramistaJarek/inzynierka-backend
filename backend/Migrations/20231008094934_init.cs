using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PESEL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
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
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfProduction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.Id);
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
                    { 8, "polio OPV" },
                    { 9, "Td" }
                });

            migrationBuilder.InsertData(
                table: "VaccinationSchedules",
                columns: new[] { "Id", "AgeGroupsId", "Dose", "IdAgeGroups", "IdTypesVaccines", "TypesVaccinesId" },
                values: new object[,]
                {
                    { 1, null, "", 1, 1, null },
                    { 2, null, "1", 1, 2, null },
                    { 3, null, "2", 2, 2, null },
                    { 4, null, "1", 2, 3, null },
                    { 5, null, "1", 2, 4, null },
                    { 6, null, "2", 3, 3, null },
                    { 7, null, "2", 3, 4, null },
                    { 8, null, "1", 3, 5, null },
                    { 9, null, "3", 4, 3, null },
                    { 10, null, "3", 4, 4, null },
                    { 11, null, "2", 4, 5, null },
                    { 12, null, "3", 5, 2, null },
                    { 13, null, "1", 6, 6, null },
                    { 14, null, "4", 7, 3, null },
                    { 15, null, "3", 7, 5, null },
                    { 16, null, "4", 7, 4, null },
                    { 17, null, "1 dawka przypominająca", 8, 7, null },
                    { 18, null, "", 8, 8, null },
                    { 19, null, "2 dawka przypominająca", 9, 6, null },
                    { 20, null, "2 dawka przypominająca", 10, 9, null },
                    { 21, null, "3 dawka przypominająca", 11, 9, null }
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
                name: "Patients");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropTable(
                name: "VaccinationSchedules");

            migrationBuilder.DropTable(
                name: "AgeGroups");

            migrationBuilder.DropTable(
                name: "TypesVaccines");
        }
    }
}
