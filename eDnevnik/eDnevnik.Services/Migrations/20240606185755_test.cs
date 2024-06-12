using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eDnevnik.Services.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proizvodi",
                columns: table => new
                {
                    ProizvodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cijena = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodi", x => x.ProizvodId);
                });

            migrationBuilder.InsertData(
                table: "Proizvodi",
                columns: new[] { "ProizvodId", "Cijena", "Naziv" },
                values: new object[] { 1, 20m, "amar" });

            migrationBuilder.InsertData(
                table: "Proizvodi",
                columns: new[] { "ProizvodId", "Cijena", "Naziv" },
                values: new object[] { 2, 30m, "alic" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proizvodi");
        }
    }
}
