using Microsoft.EntityFrameworkCore.Migrations;

namespace escola.Migrations
{
    public partial class EscolaAjustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_TurmastituloDaTurma",
                table: "Alunos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Turmas",
                table: "Turmas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alunos",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TurmastituloDaTurma",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TurmastituloDaTurma",
                table: "Alunos");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Turmas",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Alunos",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TurmasId",
                table: "Alunos",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Turmas",
                table: "Turmas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alunos",
                table: "Alunos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmasId",
                table: "Alunos",
                column: "TurmasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_TurmasId",
                table: "Alunos",
                column: "TurmasId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_TurmasId",
                table: "Alunos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Turmas",
                table: "Turmas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alunos",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TurmasId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TurmasId",
                table: "Alunos");

            migrationBuilder.AddColumn<string>(
                name: "TurmastituloDaTurma",
                table: "Alunos",
                type: "nvarchar(60)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Turmas",
                table: "Turmas",
                column: "tituloDaTurma");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alunos",
                table: "Alunos",
                column: "nome");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmastituloDaTurma",
                table: "Alunos",
                column: "TurmastituloDaTurma");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_TurmastituloDaTurma",
                table: "Alunos",
                column: "TurmastituloDaTurma",
                principalTable: "Turmas",
                principalColumn: "tituloDaTurma",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
