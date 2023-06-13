using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApi.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PERFIL",
                columns: table => new
                {
                    IDPERFIL = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFIL", x => x.IDPERFIL);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    IDUSUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DATAHORACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDPERFIL = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.IDUSUARIO);
                    table.ForeignKey(
                        name: "FK_USUARIO_PERFIL_IDPERFIL",
                        column: x => x.IDPERFIL,
                        principalTable: "PERFIL",
                        principalColumn: "IDPERFIL");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PERFIL_NOME",
                table: "PERFIL",
                column: "NOME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_EMAIL",
                table: "USUARIO",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_IDPERFIL",
                table: "USUARIO",
                column: "IDPERFIL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "PERFIL");
        }
    }
}
