﻿using System;
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
                name: "Babysitters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PESEL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kinship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Babysitters", x => x.Id);
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
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfDeclaration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfAbandonment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeOfVaccination = table.Column<int>(type: "int", nullable: false)
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Series = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfProduction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Left = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientBabysitter",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    BabysitterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientBabysitter", x => new { x.PatientId, x.BabysitterId });
                    table.ForeignKey(
                        name: "FK_PatientBabysitter_Babysitters_BabysitterId",
                        column: x => x.BabysitterId,
                        principalTable: "Babysitters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientBabysitter_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Summons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avoid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Send = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Summons_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Received = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Send = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lack = table.Column<bool>(type: "bit", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emigration = table.Column<bool>(type: "bit", nullable: false),
                    Archive = table.Column<bool>(type: "bit", nullable: false),
                    BirthType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationCard_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherVaccination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostponementOfVaccination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostVaccinationReaction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeVaccination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Appointment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledVaccination = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaccinationCardId = table.Column<int>(type: "int", nullable: false),
                    VaccinationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherVaccination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherVaccination_VaccinationCard_VaccinationCardId",
                        column: x => x.VaccinationCardId,
                        principalTable: "VaccinationCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherVaccination_Vaccinations_VaccinationId",
                        column: x => x.VaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostponementOfVaccination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostVaccinationReaction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Appointment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledVaccination = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaccinationCardId = table.Column<int>(type: "int", nullable: false),
                    VaccinationId = table.Column<int>(type: "int", nullable: false),
                    AgeGroupId = table.Column<int>(type: "int", nullable: false),
                    TypeVaccinationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationInfo_AgeGroups_AgeGroupId",
                        column: x => x.AgeGroupId,
                        principalTable: "AgeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinationInfo_TypesVaccines_TypeVaccinationId",
                        column: x => x.TypeVaccinationId,
                        principalTable: "TypesVaccines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinationInfo_VaccinationCard_VaccinationCardId",
                        column: x => x.VaccinationCardId,
                        principalTable: "VaccinationCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinationInfo_Vaccinations_VaccinationId",
                        column: x => x.VaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_OtherVaccination_VaccinationCardId",
                table: "OtherVaccination",
                column: "VaccinationCardId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherVaccination_VaccinationId",
                table: "OtherVaccination",
                column: "VaccinationId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientBabysitter_BabysitterId",
                table: "PatientBabysitter",
                column: "BabysitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Summons_PatientId",
                table: "Summons",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationCard_PatientId",
                table: "VaccinationCard",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationInfo_AgeGroupId",
                table: "VaccinationInfo",
                column: "AgeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationInfo_TypeVaccinationId",
                table: "VaccinationInfo",
                column: "TypeVaccinationId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationInfo_VaccinationCardId",
                table: "VaccinationInfo",
                column: "VaccinationCardId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationInfo_VaccinationId",
                table: "VaccinationInfo",
                column: "VaccinationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtherVaccination");

            migrationBuilder.DropTable(
                name: "PatientBabysitter");

            migrationBuilder.DropTable(
                name: "Summons");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "VaccinationInfo");

            migrationBuilder.DropTable(
                name: "Babysitters");

            migrationBuilder.DropTable(
                name: "AgeGroups");

            migrationBuilder.DropTable(
                name: "TypesVaccines");

            migrationBuilder.DropTable(
                name: "VaccinationCard");

            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}