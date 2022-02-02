using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiEmpresaDeInvestimentos.Migrations
{
    public partial class AtualizandoAlgunsDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Clientes_TitularId",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Depositos_Contas_ContaDestinoId",
                table: "Depositos");

            migrationBuilder.DropForeignKey(
                name: "FK_Depositos_Contas_ContaOrigemId",
                table: "Depositos");

            migrationBuilder.DropIndex(
                name: "IX_Depositos_ContaDestinoId",
                table: "Depositos");

            migrationBuilder.DropIndex(
                name: "IX_Depositos_ContaOrigemId",
                table: "Depositos");

            migrationBuilder.DropIndex(
                name: "IX_Contas_TitularId",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "TitularId",
                table: "Contas");

            migrationBuilder.AlterColumn<int>(
                name: "ContaOrigemId",
                table: "Depositos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContaDestinoId",
                table: "Depositos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Contas");

            migrationBuilder.AlterColumn<int>(
                name: "ContaOrigemId",
                table: "Depositos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ContaDestinoId",
                table: "Depositos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TitularId",
                table: "Contas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_ContaDestinoId",
                table: "Depositos",
                column: "ContaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_ContaOrigemId",
                table: "Depositos",
                column: "ContaOrigemId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_TitularId",
                table: "Contas",
                column: "TitularId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Clientes_TitularId",
                table: "Contas",
                column: "TitularId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Depositos_Contas_ContaDestinoId",
                table: "Depositos",
                column: "ContaDestinoId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Depositos_Contas_ContaOrigemId",
                table: "Depositos",
                column: "ContaOrigemId",
                principalTable: "Contas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
