using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "Personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonagemHabilidades",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonagemHabilidades", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_Habilidades_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_Personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Foto", "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 78, 232, 2, 78, 219, 185, 47, 20, 26, 20, 41, 161, 249, 243, 224, 172, 29, 16, 213, 182, 11, 211, 87, 106, 225, 241, 185, 8, 39, 221, 74, 28, 208, 82, 17, 17, 166, 42, 146, 201, 38, 253, 38, 47, 129, 43, 141, 177, 165, 54, 198, 144, 131, 21, 240, 207, 160, 183, 114, 216, 217, 20, 180, 178 }, new byte[] { 78, 232, 2, 78, 219, 185, 47, 20, 26, 20, 41, 161, 249, 243, 224, 172, 29, 16, 213, 182, 11, 211, 87, 106, 225, 241, 185, 8, 39, 221, 74, 28, 208, 82, 17, 17, 166, 42, 146, 201, 38, 253, 38, 47, 129, 43, 141, 177, 165, 54, 198, 144, 131, 21, 240, 207, 160, 183, 114, 216, 217, 20, 180, 178 }, new byte[] { 146, 246, 9, 23, 126, 130, 169, 197, 59, 31, 252, 111, 215, 30, 201, 31, 219, 162, 224, 88, 124, 225, 114, 11, 12, 78, 137, 6, 5, 91, 167, 153, 104, 41, 75, 15, 25, 12, 250, 201, 10, 193, 145, 49, 124, 144, 229, 48, 124, 92, 202, 146, 1, 227, 141, 10, 251, 247, 18, 229, 203, 82, 100, 194, 21, 68, 80, 1, 184, 233, 147, 107, 132, 39, 176, 190, 227, 196, 28, 184, 220, 8, 210, 59, 187, 167, 175, 106, 17, 226, 227, 69, 134, 118, 25, 199, 246, 2, 220, 82, 133, 34, 152, 41, 90, 74, 8, 25, 176, 48, 68, 174, 177, 0, 88, 77, 235, 40, 160, 168, 6, 222, 135, 205, 236, 120, 135, 195 } });

            migrationBuilder.InsertData(
                table: "PersonagemHabilidades",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonagemHabilidades_HabilidadeId",
                table: "PersonagemHabilidades",
                column: "HabilidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonagemHabilidades");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "Personagens");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Foto", "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 243, 144, 5, 215, 196, 70, 91, 242, 62, 176, 95, 253, 152, 184, 52, 204, 81, 63, 81, 143, 146, 209, 136, 3, 183, 71, 12, 31, 224, 218, 90, 244, 13, 153, 24, 208, 39, 130, 171, 232, 164, 4, 219, 184, 255, 227, 129, 9, 35, 64, 151, 72, 48, 145, 75, 213, 217, 111, 151, 158, 205, 86, 120, 60 }, new byte[] { 243, 144, 5, 215, 196, 70, 91, 242, 62, 176, 95, 253, 152, 184, 52, 204, 81, 63, 81, 143, 146, 209, 136, 3, 183, 71, 12, 31, 224, 218, 90, 244, 13, 153, 24, 208, 39, 130, 171, 232, 164, 4, 219, 184, 255, 227, 129, 9, 35, 64, 151, 72, 48, 145, 75, 213, 217, 111, 151, 158, 205, 86, 120, 60 }, new byte[] { 238, 222, 40, 133, 104, 204, 133, 43, 183, 206, 129, 126, 195, 242, 233, 231, 243, 244, 68, 208, 47, 123, 248, 251, 31, 68, 203, 112, 243, 0, 15, 55, 234, 168, 123, 9, 37, 236, 73, 81, 38, 173, 186, 137, 190, 64, 111, 32, 105, 136, 235, 115, 103, 152, 174, 223, 38, 161, 51, 112, 58, 128, 213, 221, 124, 96, 217, 122, 228, 174, 126, 50, 121, 156, 220, 251, 55, 210, 50, 53, 35, 218, 160, 74, 21, 198, 71, 233, 192, 159, 157, 180, 89, 179, 51, 79, 150, 133, 164, 124, 68, 177, 51, 162, 25, 217, 111, 86, 25, 210, 131, 38, 161, 85, 195, 63, 126, 77, 209, 2, 80, 54, 240, 85, 129, 70, 229, 187 } });
        }
    }
}
