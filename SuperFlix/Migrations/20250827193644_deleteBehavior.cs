using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleProjetos.Migrations
{
    /// <inheritdoc />
    public partial class deleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Diretorias_DiretoriaId",
                table: "Colaboradores");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Diretorias_DiretoriaId",
                table: "Colaboradores",
                column: "DiretoriaId",
                principalTable: "Diretorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Diretorias_DiretoriaId",
                table: "Colaboradores");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Diretorias_DiretoriaId",
                table: "Colaboradores",
                column: "DiretoriaId",
                principalTable: "Diretorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
