using Microsoft.EntityFrameworkCore.Migrations;

namespace PI06.Data.Migrations
{
    public partial class resultadoReferenciaMinMax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResultadoReferencia",
                schema: "dbo",
                table: "TipoExame",
                newName: "ResultadoReferenciaMin");

            migrationBuilder.AddColumn<string>(
                name: "ResultadoReferenciaMax",
                schema: "dbo",
                table: "TipoExame",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResultadoReferenciaMax",
                schema: "dbo",
                table: "TipoExame");

            migrationBuilder.RenameColumn(
                name: "ResultadoReferenciaMin",
                schema: "dbo",
                table: "TipoExame",
                newName: "ResultadoReferencia");
        }
    }
}
