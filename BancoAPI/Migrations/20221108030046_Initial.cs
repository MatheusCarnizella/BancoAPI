using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Nome = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    chavePix = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Nome);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    chaveOrigem = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    chaveDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chavePix = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.chaveOrigem);
                    table.ForeignKey(
                        name: "FK_Transacao_Cliente_chavePix",
                        column: x => x.chavePix,
                        principalTable: "Cliente",
                        principalColumn: "Nome");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_chavePix",
                table: "Transacao",
                column: "chavePix");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
