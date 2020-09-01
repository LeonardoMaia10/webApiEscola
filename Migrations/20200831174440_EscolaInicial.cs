using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace escola.Migrations
{
    public partial class EscolaInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    tituloDaTurma = table.Column<string>(maxLength: 60, nullable: false),
                    qtdDeAlunos = table.Column<int>(nullable: false),
                    idadeMedia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.tituloDaTurma);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    nome = table.Column<string>(maxLength: 60, nullable: false),
                    matricula = table.Column<int>(nullable: false),
                    dataDeNascimento = table.Column<DateTime>(nullable: false),
                    turma = table.Column<string>(nullable: false),
                    TurmastituloDaTurma = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.nome);
                    table.ForeignKey(
                        name: "FK_Alunos_Turmas_TurmastituloDaTurma",
                        column: x => x.TurmastituloDaTurma,
                        principalTable: "Turmas",
                        principalColumn: "tituloDaTurma",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmastituloDaTurma",
                table: "Alunos",
                column: "TurmastituloDaTurma");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Turmas");
        }
    }
}
