using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryControlSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjusteNaTabelaDeFornecedorV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FornecedorId",
                table: "TB_Enderecos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "TB_Enderecos");
        }
    }
}
