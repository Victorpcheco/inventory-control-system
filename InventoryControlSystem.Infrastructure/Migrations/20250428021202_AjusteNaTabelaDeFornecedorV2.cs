using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryControlSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNaTabelaDeFornecedorV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Fornecedores_TB_Enderecos_EnderecoId",
                table: "TB_Fornecedores");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Fornecedores_TB_Enderecos_EnderecoId",
                table: "TB_Fornecedores",
                column: "EnderecoId",
                principalTable: "TB_Enderecos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Fornecedores_TB_Enderecos_EnderecoId",
                table: "TB_Fornecedores");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Fornecedores_TB_Enderecos_EnderecoId",
                table: "TB_Fornecedores",
                column: "EnderecoId",
                principalTable: "TB_Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
