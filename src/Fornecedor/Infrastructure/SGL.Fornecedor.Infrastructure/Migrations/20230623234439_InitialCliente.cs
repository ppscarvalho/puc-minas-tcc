using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGL.Fornecedor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NomeFantasia = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Celular = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Logradouro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Complemento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    Cidade = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true),
                    CEP = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true),
                    Estado = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CriadoPor = table.Column<int>(type: "int", nullable: false),
                    ModificadoPor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fornecedor");
        }
    }
}
