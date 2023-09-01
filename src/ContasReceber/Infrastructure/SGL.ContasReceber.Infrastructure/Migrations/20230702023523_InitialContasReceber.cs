using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGL.ContasReceber.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialContasReceber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContasReceber",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ClienteId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Situacao = table.Column<string>(type: "longtext", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CriadoPor = table.Column<int>(type: "int", nullable: false),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasReceber", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasReceber");
        }
    }
}
