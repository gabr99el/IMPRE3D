using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEmpresa3d.Migrations
{
    /// <inheritdoc />
    public partial class migracao5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estoque",
                table: "Produto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Preço",
                table: "Produto",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estoque",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Preço",
                table: "Produto");
        }
    }
}
