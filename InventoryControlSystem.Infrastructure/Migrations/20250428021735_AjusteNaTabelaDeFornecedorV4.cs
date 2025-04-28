using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryControlSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNaTabelaDeFornecedorV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Fornecedores_TB_Enderecos_EnderecoId",
                table: "TB_Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_TB_Fornecedores_EnderecoId",
                table: "TB_Fornecedores");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "TB_Enderecos");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Fornecedores_EnderecoId",
                table: "TB_Fornecedores",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Fornecedores_TB_Enderecos_EnderecoId",
                table: "TB_Fornecedores",
                column: "EnderecoId",
                principalTable: "TB_Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Fornecedores_TB_Enderecos_EnderecoId",
                table: "TB_Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_TB_Fornecedores_EnderecoId",
                table: "TB_Fornecedores");

            migrationBuilder.AddColumn<string>(
                name: "FornecedorId",
                table: "TB_Enderecos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Fornecedores_EnderecoId",
                table: "TB_Fornecedores",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Fornecedores_TB_Enderecos_EnderecoId",
                table: "TB_Fornecedores",
                column: "EnderecoId",
                principalTable: "TB_Enderecos",
                principalColumn: "Id");
        }
    }
}
