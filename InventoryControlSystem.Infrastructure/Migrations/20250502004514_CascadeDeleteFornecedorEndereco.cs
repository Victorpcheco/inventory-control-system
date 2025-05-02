using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryControlSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteFornecedorEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_Fornecedores_EnderecoId",
                table: "TB_Fornecedores");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_Categorias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TB_Categorias",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Fornecedores_EnderecoId",
                table: "TB_Fornecedores",
                column: "EnderecoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_Fornecedores_EnderecoId",
                table: "TB_Fornecedores");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_Categorias",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "TB_Categorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Fornecedores_EnderecoId",
                table: "TB_Fornecedores",
                column: "EnderecoId");
        }
    }
}
