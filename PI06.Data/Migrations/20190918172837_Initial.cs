using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PI06.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Cargo",
                schema: "dbo",
                columns: table => new
                {
                    IDCargo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    DescricaoCargo = table.Column<string>(nullable: false),
                    IsHealthProfession = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IDCargo", x => x.IDCargo);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                schema: "dbo",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 300, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Rg = table.Column<string>(nullable: false),
                    Sus = table.Column<int>(nullable: false),
                    CodigoCpf = table.Column<long>(nullable: false),
                    EnderecoEmail = table.Column<string>(maxLength: 150, nullable: false),
                    Logradouro = table.Column<string>(nullable: false),
                    Complemento = table.Column<string>(nullable: true),
                    NumeroEndereco = table.Column<string>(nullable: false),
                    Bairro = table.Column<string>(nullable: false),
                    Cidade = table.Column<string>(nullable: false),
                    Uf = table.Column<int>(nullable: false),
                    NumeroTelefone = table.Column<long>(nullable: false),
                    DDD = table.Column<int>(nullable: false),
                    CepCod = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdPessoa", x => x.IdPessoa);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                schema: "dbo",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(nullable: false),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    DataContratacao = table.Column<DateTime>(nullable: false),
                    DataDemissao = table.Column<DateTime>(nullable: true),
                    IdCargo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdFuncionario", x => x.IdFuncionario);
                    table.ForeignKey(
                        name: "PFK_PessoaFuncionario",
                        column: x => x.IdFuncionario,
                        principalSchema: "dbo",
                        principalTable: "Pessoa",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cargo",
                        column: x => x.IdCargo,
                        principalSchema: "dbo",
                        principalTable: "Cargo",
                        principalColumn: "IDCargo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                schema: "dbo",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(nullable: false),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdPaciente", x => x.IdPaciente);
                    table.ForeignKey(
                        name: "PFK_PessoaPaciente",
                        column: x => x.IdPaciente,
                        principalSchema: "dbo",
                        principalTable: "Pessoa",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conselho",
                schema: "dbo",
                columns: table => new
                {
                    IdConselho = table.Column<int>(nullable: false),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    NumeroConselho = table.Column<int>(nullable: false),
                    DescricaoConselho = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdConselho", x => x.IdConselho);
                    table.ForeignKey(
                        name: "PFK_PessoaFuncionarioConselho",
                        column: x => x.IdConselho,
                        principalSchema: "dbo",
                        principalTable: "Funcionario",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "dbo",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false),
                    DtInclusao = table.Column<DateTime>(nullable: false),
                    DtAlteracao = table.Column<DateTime>(nullable: true),
                    Login = table.Column<string>(nullable: false),
                    Senha = table.Column<byte[]>(nullable: false),
                    TokenAlteracaoDeSenha = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdUsuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "PFK_PessoaFuncionarioUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "dbo",
                        principalTable: "Funcionario",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdCargo",
                schema: "dbo",
                table: "Funcionario",
                column: "IdCargo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conselho",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Paciente",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Funcionario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Pessoa",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cargo",
                schema: "dbo");
        }
    }
}
