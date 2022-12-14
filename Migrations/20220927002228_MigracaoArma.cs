using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    public partial class MigracaoArma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Personagens",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.CreateTable(
                name: "Armas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dano = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Armas",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 10, "Ak" },
                    { 2, 4, "Facao" },
                    { 3, 5, "Machado" },
                    { 4, 8, "Espada" },
                    { 5, 2, "Estilingue" },
                    { 6, 7, "Enxada" },
                    { 7, 100, "Cerrinha de Pao" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armas");

            migrationBuilder.InsertData(
                table: "Personagens",
                columns: new[] { "Id", "Classe", "Defesa", "Forca", "Inteligencia", "Nome", "PontosVida" },
                values: new object[,]
                {
                    { 1, 1, 23, 17, 33, "Frodo", 100 },
                    { 2, 1, 25, 15, 30, "Sam", 100 },
                    { 3, 3, 21, 18, 35, "Galadriel", 100 },
                    { 4, 2, 18, 18, 37, "Gandalf", 100 },
                    { 5, 1, 17, 20, 31, "Hobbit", 100 },
                    { 6, 3, 13, 21, 34, "Celeborn", 100 },
                    { 7, 2, 11, 25, 35, "Radagast", 100 }
                });
        }
    }
}
