using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PI06.Data.Migrations
{
    public partial class fernandoEntitysAndContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consulta",
                schema: "dbo",
                columns: table => new
                {
                    IdConsulta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    IdPaciente = table.Column<int>(nullable: false),
                    IdFuncionarioMedico = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataTermino = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdConsulta", x => x.IdConsulta);
                    table.ForeignKey(
                        name: "FK_FuncionarioConsulta",
                        column: x => x.IdFuncionarioMedico,
                        principalSchema: "dbo",
                        principalTable: "Funcionario",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PacienteConsulta",
                        column: x => x.IdPaciente,
                        principalSchema: "dbo",
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoExame",
                schema: "dbo",
                columns: table => new
                {
                    IdTipoExame = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(nullable: false),
                    ResultadoReferencia = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdTipoExame", x => x.IdTipoExame);
                });

            migrationBuilder.CreateTable(
                name: "TipoProcedimento",
                schema: "dbo",
                columns: table => new
                {
                    IdTipoProcedimento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdTipoProcedimento", x => x.IdTipoProcedimento);
                });

            migrationBuilder.CreateTable(
                name: "Procedimento",
                schema: "dbo",
                columns: table => new
                {
                    idProcedimento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    Observacao = table.Column<string>(nullable: false),
                    IdConsulta = table.Column<int>(nullable: false),
                    IdTipoProcedimento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdProcedimento", x => x.idProcedimento);
                    table.ForeignKey(
                        name: "FK_IdConsulta",
                        column: x => x.IdConsulta,
                        principalSchema: "dbo",
                        principalTable: "Consulta",
                        principalColumn: "IdConsulta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdTipoProcedimento",
                        column: x => x.IdTipoProcedimento,
                        principalSchema: "dbo",
                        principalTable: "TipoProcedimento",
                        principalColumn: "IdTipoProcedimento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cirurgia",
                schema: "dbo",
                columns: table => new
                {
                    IdCirurgiaProcedimento = table.Column<int>(nullable: false),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdCirurgiaProcedimento", x => x.IdCirurgiaProcedimento);
                    table.ForeignKey(
                        name: "PFK_IdProcedimentoCirurgia",
                        column: x => x.IdCirurgiaProcedimento,
                        principalSchema: "dbo",
                        principalTable: "Procedimento",
                        principalColumn: "idProcedimento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exame",
                schema: "dbo",
                columns: table => new
                {
                    IdExame = table.Column<int>(nullable: false),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    Resultado = table.Column<string>(nullable: false),
                    IdTipoExame = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdExame", x => x.IdExame);
                    table.ForeignKey(
                        name: "PFK_ProcedimentoExame",
                        column: x => x.IdExame,
                        principalSchema: "dbo",
                        principalTable: "Procedimento",
                        principalColumn: "idProcedimento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdTipoExame",
                        column: x => x.IdTipoExame,
                        principalSchema: "dbo",
                        principalTable: "TipoExame",
                        principalColumn: "IdTipoExame",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_CodigoCpf",
                schema: "dbo",
                table: "Pessoa",
                column: "CodigoCpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdFuncionarioMedico",
                schema: "dbo",
                table: "Consulta",
                column: "IdFuncionarioMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdPaciente",
                schema: "dbo",
                table: "Consulta",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_IdTipoExame",
                schema: "dbo",
                table: "Exame",
                column: "IdTipoExame");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimento_IdConsulta",
                schema: "dbo",
                table: "Procedimento",
                column: "IdConsulta");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimento_IdTipoProcedimento",
                schema: "dbo",
                table: "Procedimento",
                column: "IdTipoProcedimento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cirurgia",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Exame",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Procedimento",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TipoExame",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Consulta",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TipoProcedimento",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_CodigoCpf",
                schema: "dbo",
                table: "Pessoa");
        }
    }
}
