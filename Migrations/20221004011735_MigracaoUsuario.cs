using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    public partial class MigracaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Personagens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "FotoPersonagem",
                table: "Personagens",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Personagens",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Armas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "Jogador"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Personagens",
                columns: new[] { "Id", "Classe", "Defesa", "Forca", "FotoPersonagem", "Inteligencia", "Nome", "PontosVida", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1, 23, 17, null, 33, "Frodo", 100, null },
                    { 2, 1, 25, 15, null, 30, "Sam", 100, null },
                    { 3, 3, 21, 18, null, 35, "Galadriel", 100, null },
                    { 4, 2, 18, 18, null, 37, "Gandalf", 100, null },
                    { 5, 1, 17, 20, null, 31, "Hobbit", 100, null },
                    { 6, 3, 13, 21, null, 34, "Celeborn", 100, null },
                    { 7, 2, 11, 25, null, 35, "Radagast", 100, null }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "DataAcesso", "Email", "Foto", "Latitude", "Longitude", "PasswordHash", "PasswordSalt", "Perfil", "Username" },
                values: new object[] { 1, null, "usuario@gmail.com", new byte[] { 192, 16, 78, 226, 191, 70, 134, 243, 186, 78, 44, 201, 194, 144, 65, 235, 72, 155, 27, 77, 244, 170, 237, 141, 105, 219, 191, 205, 135, 236, 218, 58, 21, 185, 91, 91, 218, 106, 8, 66, 226, 123, 131, 179, 38, 25, 103, 19, 107, 104, 222, 239, 51, 113, 205, 99, 162, 54, 242, 241, 110, 142, 31, 5 }, null, null, new byte[] { 192, 16, 78, 226, 191, 70, 134, 243, 186, 78, 44, 201, 194, 144, 65, 235, 72, 155, 27, 77, 244, 170, 237, 141, 105, 219, 191, 205, 135, 236, 218, 58, 21, 185, 91, 91, 218, 106, 8, 66, 226, 123, 131, 179, 38, 25, 103, 19, 107, 104, 222, 239, 51, 113, 205, 99, 162, 54, 242, 241, 110, 142, 31, 5 }, new byte[] { 132, 113, 181, 15, 30, 190, 234, 221, 19, 169, 96, 23, 25, 3, 249, 81, 35, 106, 49, 51, 199, 75, 208, 97, 85, 73, 1, 15, 52, 208, 218, 112, 226, 50, 155, 16, 39, 211, 202, 251, 85, 114, 181, 152, 183, 102, 12, 30, 55, 177, 117, 205, 164, 46, 224, 181, 106, 181, 147, 198, 173, 115, 36, 70, 132, 231, 157, 219, 19, 144, 106, 226, 138, 131, 70, 90, 117, 101, 57, 158, 85, 139, 246, 251, 107, 241, 26, 161, 218, 252, 9, 22, 51, 151, 37, 193, 11, 232, 54, 20, 79, 171, 12, 247, 247, 3, 38, 40, 254, 111, 51, 148, 156, 239, 253, 144, 19, 250, 2, 249, 184, 126, 247, 90, 112, 155, 152, 54 }, "Admin", "UsuarioAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_UsuarioId",
                table: "Personagens",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personagens_Usuario_UsuarioId",
                table: "Personagens",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_Usuario_UsuarioId",
                table: "Personagens");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Personagens_UsuarioId",
                table: "Personagens");

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

            migrationBuilder.DropColumn(
                name: "FotoPersonagem",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Personagens");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Personagens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Armas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
