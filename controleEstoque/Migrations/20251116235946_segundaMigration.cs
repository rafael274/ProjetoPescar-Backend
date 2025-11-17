using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace controleEstoque.Migrations
{
    /// <inheritdoc />
    public partial class segundaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materiais_TBCategorias_CategoriaId",
                table: "Materiais");

            migrationBuilder.DropTable(
                name: "TBCategorias");

            migrationBuilder.DropIndex(
                name: "IX_Materiais_CategoriaId",
                table: "Materiais");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Materiais");

            migrationBuilder.AddColumn<string>(
                name: "usuarioImagem",
                table: "Usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usuarioImagem",
                table: "Usuarios");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaId",
                table: "Materiais",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "TBCategorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCategorias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_CategoriaId",
                table: "Materiais",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materiais_TBCategorias_CategoriaId",
                table: "Materiais",
                column: "CategoriaId",
                principalTable: "TBCategorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
