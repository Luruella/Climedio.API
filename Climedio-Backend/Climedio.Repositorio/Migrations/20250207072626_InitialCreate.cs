using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Climedio.Repositorio.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(130)", maxLength: 130, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    NomeSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    AgendamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsuarioIdProfissional = table.Column<int>(type: "int", nullable: false),
                    UsuarioIdPaciente = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Usuarios_UsuarioIdPaciente",
                        column: x => x.UsuarioIdPaciente,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                    table.ForeignKey(
                        name: "FK_Agendamentos_Usuarios_UsuarioIdProfissional",
                        column: x => x.UsuarioIdProfissional,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_UsuarioIdPaciente",
                table: "Agendamentos",
                column: "UsuarioIdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_UsuarioIdProfissional",
                table: "Agendamentos",
                column: "UsuarioIdProfissional");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
