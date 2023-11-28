using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEmpresa3d.Migrations
{
    /// <inheritdoc />
    public partial class migracao4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estoque",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Preço",
                table: "Produto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estoque",
                table: "Produto",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Preço",
                table: "Produto",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
