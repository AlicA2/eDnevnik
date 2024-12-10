using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class CasoviUceniciStudentsInfoAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "CasoviUcenici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "CasoviUcenici",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 1,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Amel", "Musić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 2,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Dragi", "Tiro" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 3,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Adil", "Joldić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 4,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Lejla", "Jazvin" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 5,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Elmir", "Babović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 6,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Maida", "Sulejmanović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 7,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirela", "Bajramović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 8,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Filip", "Lukić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 9,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirza", "Redžović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 10,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Sara", "Bulić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 11,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Amel", "Musić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 12,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Dragi", "Tiro" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 13,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Adil", "Joldić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 14,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Lejla", "Jazvin" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 15,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Elmir", "Babović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 16,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Maida", "Sulejmanović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 17,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirela", "Bajramović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 18,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Filip", "Lukić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 19,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirza", "Redžović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 20,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Sara", "Bulić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 21,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Amel", "Musić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 22,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Dragi", "Tiro" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 23,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Adil", "Joldić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 24,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Lejla", "Jazvin" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 25,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Elmir", "Babović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 26,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Maida", "Sulejmanović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 27,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirela", "Bajramović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 28,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Filip", "Lukić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 29,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirza", "Redžović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 30,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Sara", "Bulić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 31,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Amel", "Musić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 32,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Dragi", "Tiro" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 33,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Adil", "Joldić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 34,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Lejla", "Jazvin" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 35,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Elmir", "Babović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 36,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Maida", "Sulejmanović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 37,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirela", "Bajramović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 38,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Filip", "Lukić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 39,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirza", "Redžović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 40,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Sara", "Bulić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 41,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Amel", "Musić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 42,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Dragi", "Tiro" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 43,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Adil", "Joldić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 44,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Lejla", "Jazvin" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 45,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Elmir", "Babović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 46,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Maida", "Sulejmanović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 47,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirela", "Bajramović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 48,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Filip", "Lukić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 49,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirza", "Redžović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 50,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Sara", "Bulić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 51,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Amel", "Musić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 52,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Dragi", "Tiro" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 53,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Adil", "Joldić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 54,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Lejla", "Jazvin" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 55,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Elmir", "Babović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 56,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Maida", "Sulejmanović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 57,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirela", "Bajramović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 58,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Filip", "Lukić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 59,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirza", "Redžović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 60,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Sara", "Bulić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 61,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Amel", "" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 62,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Dragi", "Tiro" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 63,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Adil", "Joldić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 64,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Lejla", "Jazvin" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 65,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Elmir", "Babović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 66,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Maida", "Sulejmanović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 67,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirela", "Bajramović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 68,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Filip", "Lukić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 69,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirza", "Redžović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 70,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Sara", "Bulić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 71,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Amel", "Musić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 72,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Dragi", "Tiro" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 73,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Adil", "Joldić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 74,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Lejla", "Jazvin" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 75,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Elmir", "Babović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 76,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Maida", "Sulejmanović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 77,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirela", "Bajramović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 78,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Filip", "Lukić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 79,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirza", "Redžović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 80,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Sara", "Bulić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 81,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Amel", "Musić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 82,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Dragi", "Tiro" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 83,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Adil", "Joldić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 84,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Lejla", "Jazvin" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 85,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Elmir", "Babović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 86,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Maida", "Sulejmanović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 87,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirela", "Bajramović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 88,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Filip", "Lukić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 89,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirza", "Redžović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 90,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Sara", "Bulić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 91,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Amel", "Musić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 92,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Dragi", "Tiro" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 93,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Adil", "Joldić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 94,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Lejla", "Jazvin" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 95,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Elmir", "Babović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 96,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Maida", "Sulejmanović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 97,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirela", "Bajramović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 98,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Filip", "Lukić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 99,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirza", "Redžović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 100,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Sara", "Bulić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 101,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Amel", "Musić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 102,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Dragi", "Tiro" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 103,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Adil", "Joldić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 104,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Lejla", "Jazvin" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 105,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Elmir", "Babović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 106,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Maida", "Sulejmanović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 107,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirela", "Bajramović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 108,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Filip", "Lukić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 109,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirza", "Redžović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 110,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Sara", "Bulić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 111,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Amel", "Musić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 112,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Dragi", "Tiro" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 113,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Adil", "Joldić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 114,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Lejla", "Jazvin" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 115,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Elmir", "Babović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 116,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Maida", "Sulejmanović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 117,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirela", "Bajramović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 118,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Filip", "Lukić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 119,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirza", "Redžović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 120,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Sara", "Bulić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 121,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Amel", "Musić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 122,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Dragi", "Tiro" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 123,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Adil", "Joldić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 124,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Lejla", "Jazvin" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 125,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Elmir", "Babović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 126,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Maida", "Sulejmanović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 127,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirela", "Bajramović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 128,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Filip", "Lukić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 129,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirza", "Redžović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 130,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Sara", "Bulić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 131,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Amel", "Musić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 132,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Dragi", "Tiro" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 133,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Adil", "Joldić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 134,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Lejla", "Jazvin" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 135,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Elmir", "Babović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 136,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Maida", "Sulejmanović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 137,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirela", "Bajramović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 138,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Filip", "Lukić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 139,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirza", "Redžović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 140,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "sara", "Bulić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 141,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Amel", "Musić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 142,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Dragi", "Tiro" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 143,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Adil", "Joldić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 144,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Lejla", "Jazvin" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 145,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Elmir", "Babović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 146,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Maida", "Sulejmanović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 147,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirela", "Bajramović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 148,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Filip", "Lukić" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 149,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Mirza", "Redžović" });

            migrationBuilder.UpdateData(
                table: "CasoviUcenici",
                keyColumn: "CasoviUceniciID",
                keyValue: 150,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Sara", "Bulić" });

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8987));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(9024));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(9029));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(9031));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(9033));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8278));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8281));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8286));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8291));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8293));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8295));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8298));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8300));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8302));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8305));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8309));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8311));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8314));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8316));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8318));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8321));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8323));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8325));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8384));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8387));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8392));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8394));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8397));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8399));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8401));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8404));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8406));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8408));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8411));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8413));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8415));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8418));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8425));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8427));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8429));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8432));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8434));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8436));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8438));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8441));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8443));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8448));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 51,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 52,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8452));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 53,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8455));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 54,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 55,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8459));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 56,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8462));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 57,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 58,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8466));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 59,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 60,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8471));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 61,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8473));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 62,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8476));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 63,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 64,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 65,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8483));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 66,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8485));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 67,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8487));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 68,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 69,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 10, 22, 5, 47, 27, DateTimeKind.Local).AddTicks(8492));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ime",
                table: "CasoviUcenici");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "CasoviUcenici");

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 1,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3753));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 2,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3762));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 3,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 4,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3767));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 5,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "Poruke",
                keyColumn: "PorukaID",
                keyValue: 6,
                column: "DatumSlanja",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3771));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(2982));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 3,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3026));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 4,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 5,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 6,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3033));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 7,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3036));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 8,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 9,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3040));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 10,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3043));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 11,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3045));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 12,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 13,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3050));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 14,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3052));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 15,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3054));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 16,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3057));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 17,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3059));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 18,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 19,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 20,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 21,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3068));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 22,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 23,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3073));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 24,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3075));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 25,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3078));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 26,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 27,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 28,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3085));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 29,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3087));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 30,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3090));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 31,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3092));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 32,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 33,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 34,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 35,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 36,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3104));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 37,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3106));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 38,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3108));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 39,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3111));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 40,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3113));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 41,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3115));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 42,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 43,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3120));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 44,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3122));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 45,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3125));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 46,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3127));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 47,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3129));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 48,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 49,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3134));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 50,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3136));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 51,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 52,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 53,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3143));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 54,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3146));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 55,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 56,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3151));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 57,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 58,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 59,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3158));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 60,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 61,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3162));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 62,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3165));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 63,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3167));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 64,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3169));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 65,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3172));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 66,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3174));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 67,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3176));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 68,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3179));

            migrationBuilder.UpdateData(
                table: "korisniciUloges",
                keyColumn: "KorisnikUlogaID",
                keyValue: 69,
                column: "DatumIzmjene",
                value: new DateTime(2024, 12, 9, 20, 21, 38, 3, DateTimeKind.Local).AddTicks(3181));
        }
    }
}
