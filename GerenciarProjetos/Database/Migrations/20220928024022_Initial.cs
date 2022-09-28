using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GerenciarProjetos.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "empregado",
                columns: table => new
                {
                    id_empregado = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    primeironome = table.Column<string>(name: "primeiro-nome", type: "text", nullable: true),
                    ultimonome = table.Column<string>(name: "ultimo-nome", type: "text", nullable: true),
                    telefone = table.Column<long>(type: "bigint", nullable: false),
                    endereco = table.Column<string>(type: "text", nullable: true),
                    excluido = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empregado", x => x.id_empregado);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: true),
                    senhahash = table.Column<string>(name: "senha-hash", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "projeto",
                columns: table => new
                {
                    id_projeto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: true),
                    datacriacao = table.Column<DateTime>(name: "data-criacao", type: "date", nullable: false),
                    datatermino = table.Column<DateTime>(name: "data-termino", type: "date", nullable: false),
                    excluido = table.Column<bool>(type: "boolean", nullable: false),
                    gerente = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projeto", x => x.id_projeto);
                    table.ForeignKey(
                        name: "FK_projeto_empregado_gerente",
                        column: x => x.gerente,
                        principalTable: "empregado",
                        principalColumn: "id_empregado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "refresh_token",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_usuario = table.Column<int>(type: "integer", nullable: false),
                    token = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_token", x => x.id);
                    table.ForeignKey(
                        name: "FK_refresh_token_usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "membros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_projeto = table.Column<int>(type: "integer", nullable: false),
                    id_empregado = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_membros_empregado_id_empregado",
                        column: x => x.id_empregado,
                        principalTable: "empregado",
                        principalColumn: "id_empregado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_membros_projeto_id_projeto",
                        column: x => x.id_projeto,
                        principalTable: "projeto",
                        principalColumn: "id_projeto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_empregado_endereco",
                table: "empregado",
                column: "endereco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_membros_id_empregado",
                table: "membros",
                column: "id_empregado");

            migrationBuilder.CreateIndex(
                name: "IX_membros_id_projeto",
                table: "membros",
                column: "id_projeto");

            migrationBuilder.CreateIndex(
                name: "IX_projeto_gerente",
                table: "projeto",
                column: "gerente");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_id_usuario",
                table: "refresh_token",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_email",
                table: "usuario",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "membros");

            migrationBuilder.DropTable(
                name: "refresh_token");

            migrationBuilder.DropTable(
                name: "projeto");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "empregado");
        }
    }
}
