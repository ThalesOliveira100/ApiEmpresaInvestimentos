using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiEmpresaDeInvestimentos.Migrations
{
    public partial class AdicionandoSaquesAndAtualizandoClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Depositos",
                type: "text",
                nullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Contas",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Agencia",
                table: "Contas",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "text",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Clientes",
                type: "text",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Depositos");

            migrationBuilder.DropColumn(
                name: "OrigemCpf",
                table: "Depositos");

            migrationBuilder.DropColumn(
                name: "OrigemInstituicao",
                table: "Depositos");

            migrationBuilder.DropColumn(
                name: "OrigemNome",
                table: "Depositos");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Contas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Agencia",
                table: "Contas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
