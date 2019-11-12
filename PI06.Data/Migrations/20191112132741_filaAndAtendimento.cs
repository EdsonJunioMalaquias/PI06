using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PI06.Data.Migrations
{
    public partial class filaAndAtendimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pessoa_CodigoCpf",
                schema: "dbo",
                table: "Pessoa");

            migrationBuilder.CreateTable(
                name: "Fila",
                schema: "dbo",
                columns: table => new
                {
                    IdFila = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdFila", x => x.IdFila);
                });

            migrationBuilder.CreateTable(
                name: "Atendimento",
                schema: "dbo",
                columns: table => new
                {
                    IdAtendimento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    GrauDeEmergencia = table.Column<int>(nullable: false),
                    DataChegada = table.Column<DateTime>(nullable: false),
                    StatusDeAtendimento = table.Column<bool>(nullable: false),
                    FilaId = table.Column<int>(nullable: false),
                    MedicoId = table.Column<int>(nullable: false),
                    PacienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdAtendimento", x => x.IdAtendimento);
                    table.ForeignKey(
                        name: "FK_IdFila",
                        column: x => x.FilaId,
                        principalSchema: "dbo",
                        principalTable: "Fila",
                        principalColumn: "IdFila",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PFK_IdMedicoFila",
                        column: x => x.MedicoId,
                        principalSchema: "dbo",
                        principalTable: "Funcionario",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PFK_IdPacienteFila",
                        column: x => x.PacienteId,
                        principalSchema: "dbo",
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_CodigoCpf_Uf_Sus",
                schema: "dbo",
                table: "Pessoa",
                columns: new[] { "CodigoCpf", "Uf", "Sus" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_FilaId",
                schema: "dbo",
                table: "Atendimento",
                column: "FilaId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_MedicoId",
                schema: "dbo",
                table: "Atendimento",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_PacienteId",
                schema: "dbo",
                table: "Atendimento",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimento",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Fila",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_CodigoCpf_Uf_Sus",
                schema: "dbo",
                table: "Pessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_CodigoCpf",
                schema: "dbo",
                table: "Pessoa",
                column: "CodigoCpf",
                unique: true);
        }
    }
}
