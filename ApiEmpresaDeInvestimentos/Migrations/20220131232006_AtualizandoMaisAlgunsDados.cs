using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiEmpresaDeInvestimentos.Migrations
{
    public partial class AtualizandoMaisAlgunsDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContaOrigemId",
                table: "Depositos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContaOrigemId",
                table: "Depositos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
