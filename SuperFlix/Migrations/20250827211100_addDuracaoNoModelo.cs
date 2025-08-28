using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleProjetos.Migrations
{
    /// <inheritdoc />
    public partial class addDuracaoNoModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duracao",
                table: "Projetos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duracao",
                table: "Projetos");
        }
    }
}
