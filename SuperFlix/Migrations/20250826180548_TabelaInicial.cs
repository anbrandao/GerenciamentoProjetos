using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleProjetos.Migrations
{
    /// <inheritdoc />
    public partial class TabelaInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diretorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diretorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiretoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaboradores_Diretorias_DiretoriaId",
                        column: x => x.DiretoriaId,
                        principalTable: "Diretorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColaboradoresProjetos",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradoresProjetos", x => new { x.ColaboradorId, x.ProjetoId });
                    table.ForeignKey(
                        name: "FK_ColaboradoresProjetos_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColaboradoresProjetos_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_DiretoriaId",
                table: "Colaboradores",
                column: "DiretoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradoresProjetos_ProjetoId",
                table: "ColaboradoresProjetos",
                column: "ProjetoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColaboradoresProjetos");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Diretorias");
        }
    }
}
