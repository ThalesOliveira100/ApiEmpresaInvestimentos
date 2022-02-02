using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiEmpresaDeInvestimentos.Migrations
{
    public partial class Atualizando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrigemCpf",
                table: "Depositos");

            migrationBuilder.DropColumn(
                name: "OrigemInstituicao",
                table: "Depositos");

            migrationBuilder.DropColumn(
                name: "OrigemNome",
                table: "Depositos");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Saques",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Saques");

            migrationBuilder.AddColumn<string>(
                name: "OrigemCpf",
                table: "Depositos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrigemInstituicao",
                table: "Depositos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrigemNome",
                table: "Depositos",
                type: "text",
                nullable: true);
        }
    }
}
