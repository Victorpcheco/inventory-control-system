using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryControlSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteFornecedorEnderecoV1 : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TB_Enderecos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Enderecos_TB_Fornecedores_Id",
                table: "TB_Enderecos",
                column: "Id",
                principalTable: "TB_Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Enderecos_TB_Fornecedores_Id",
                table: "TB_Enderecos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TB_Enderecos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
