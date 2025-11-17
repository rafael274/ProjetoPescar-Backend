using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace controleEstoque.Migrations
{
    /// <inheritdoc />
    public partial class terceiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "usuarioId",
                table: "Movimentacoes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usuarioId",
                table: "Movimentacoes");
        }
    }
}
