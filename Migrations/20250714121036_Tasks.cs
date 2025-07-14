using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentUP.Migrations
{
    /// <inheritdoc />
    public partial class Tasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "taskEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoTask = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriadorId = table.Column<int>(type: "int", nullable: false),
                    AjudanteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_taskEntities_Colaboradores_AjudanteId",
                        column: x => x.AjudanteId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_taskEntities_Colaboradores_CriadorId",
                        column: x => x.CriadorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_taskEntities_AjudanteId",
                table: "taskEntities",
                column: "AjudanteId");

            migrationBuilder.CreateIndex(
                name: "IX_taskEntities_CriadorId",
                table: "taskEntities",
                column: "CriadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "taskEntities");
        }
    }
}
