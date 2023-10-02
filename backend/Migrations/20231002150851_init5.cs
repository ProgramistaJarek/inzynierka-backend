using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TypesVaccines",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "polio OPV");

            migrationBuilder.InsertData(
                table: "TypesVaccines",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Td" });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "VaccinationSchedules",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TypesVaccines",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "TypesVaccines",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Td");
        }
    }
}
