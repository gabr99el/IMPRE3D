using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEmpresa3d.Migrations
{
    /// <inheritdoc />
    public partial class migração2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Projeto",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Material",
                table: "Projeto");
        }
    }
}
