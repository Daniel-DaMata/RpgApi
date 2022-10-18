using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    public partial class MigracaoUmParaUm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "Armas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Foto", "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 243, 144, 5, 215, 196, 70, 91, 242, 62, 176, 95, 253, 152, 184, 52, 204, 81, 63, 81, 143, 146, 209, 136, 3, 183, 71, 12, 31, 224, 218, 90, 244, 13, 153, 24, 208, 39, 130, 171, 232, 164, 4, 219, 184, 255, 227, 129, 9, 35, 64, 151, 72, 48, 145, 75, 213, 217, 111, 151, 158, 205, 86, 120, 60 }, new byte[] { 243, 144, 5, 215, 196, 70, 91, 242, 62, 176, 95, 253, 152, 184, 52, 204, 81, 63, 81, 143, 146, 209, 136, 3, 183, 71, 12, 31, 224, 218, 90, 244, 13, 153, 24, 208, 39, 130, 171, 232, 164, 4, 219, 184, 255, 227, 129, 9, 35, 64, 151, 72, 48, 145, 75, 213, 217, 111, 151, 158, 205, 86, 120, 60 }, new byte[] { 238, 222, 40, 133, 104, 204, 133, 43, 183, 206, 129, 126, 195, 242, 233, 231, 243, 244, 68, 208, 47, 123, 248, 251, 31, 68, 203, 112, 243, 0, 15, 55, 234, 168, 123, 9, 37, 236, 73, 81, 38, 173, 186, 137, 190, 64, 111, 32, 105, 136, 235, 115, 103, 152, 174, 223, 38, 161, 51, 112, 58, 128, 213, 221, 124, 96, 217, 122, 228, 174, 126, 50, 121, 156, 220, 251, 55, 210, 50, 53, 35, 218, 160, 74, 21, 198, 71, 233, 192, 159, 157, 180, 89, 179, 51, 79, 150, 133, 164, 124, 68, 177, 51, 162, 25, 217, 111, 86, 25, 210, 131, 38, 161, 85, 195, 63, 126, 77, 209, 2, 80, 54, 240, 85, 129, 70, 229, 187 } });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                principalTable: "Personagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armas_Personagens_PersonagemId",
                table: "Armas");

            migrationBuilder.DropIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "Armas");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Foto", "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 192, 16, 78, 226, 191, 70, 134, 243, 186, 78, 44, 201, 194, 144, 65, 235, 72, 155, 27, 77, 244, 170, 237, 141, 105, 219, 191, 205, 135, 236, 218, 58, 21, 185, 91, 91, 218, 106, 8, 66, 226, 123, 131, 179, 38, 25, 103, 19, 107, 104, 222, 239, 51, 113, 205, 99, 162, 54, 242, 241, 110, 142, 31, 5 }, new byte[] { 192, 16, 78, 226, 191, 70, 134, 243, 186, 78, 44, 201, 194, 144, 65, 235, 72, 155, 27, 77, 244, 170, 237, 141, 105, 219, 191, 205, 135, 236, 218, 58, 21, 185, 91, 91, 218, 106, 8, 66, 226, 123, 131, 179, 38, 25, 103, 19, 107, 104, 222, 239, 51, 113, 205, 99, 162, 54, 242, 241, 110, 142, 31, 5 }, new byte[] { 132, 113, 181, 15, 30, 190, 234, 221, 19, 169, 96, 23, 25, 3, 249, 81, 35, 106, 49, 51, 199, 75, 208, 97, 85, 73, 1, 15, 52, 208, 218, 112, 226, 50, 155, 16, 39, 211, 202, 251, 85, 114, 181, 152, 183, 102, 12, 30, 55, 177, 117, 205, 164, 46, 224, 181, 106, 181, 147, 198, 173, 115, 36, 70, 132, 231, 157, 219, 19, 144, 106, 226, 138, 131, 70, 90, 117, 101, 57, 158, 85, 139, 246, 251, 107, 241, 26, 161, 218, 252, 9, 22, 51, 151, 37, 193, 11, 232, 54, 20, 79, 171, 12, 247, 247, 3, 38, 40, 254, 111, 51, 148, 156, 239, 253, 144, 19, 250, 2, 249, 184, 126, 247, 90, 112, 155, 152, 54 } });
        }
    }
}
