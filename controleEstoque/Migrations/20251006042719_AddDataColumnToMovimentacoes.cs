using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace controleEstoque.Migrations
{
    /// <inheritdoc />
    public partial class AddDataColumnToMovimentacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materiais_TBCategorias_categoriaId",
                table: "Materiais");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Materiais_MateriaId",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Usuarios_UsuarioId",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Relatorios_Usuarios_UsuarioId",
                table: "Relatorios");

            migrationBuilder.DropIndex(
                name: "IX_Relatorios_UsuarioId",
                table: "Relatorios");

            migrationBuilder.DropIndex(
                name: "IX_Movimentacoes_MateriaId",
                table: "Movimentacoes");

            migrationBuilder.DropColumn(
                name: "ConfirmarSenha",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Relatorios");

            migrationBuilder.DropColumn(
                name: "MateriaId",
                table: "Movimentacoes");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Movimentacoes",
                newName: "MaterialId");

            migrationBuilder.RenameColumn(
                name: "DataMovimentacao",
                table: "Movimentacoes",
                newName: "Data");

            migrationBuilder.RenameIndex(
                name: "IX_Movimentacoes_UsuarioId",
                table: "Movimentacoes",
                newName: "IX_Movimentacoes_MaterialId");

            migrationBuilder.RenameColumn(
                name: "categoriaId",
                table: "Materiais",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Materiais_categoriaId",
                table: "Materiais",
                newName: "IX_Materiais_CategoriaId");

            migrationBuilder.AlterColumn<int>(
                name: "Tipo",
                table: "Movimentacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Materiais_TBCategorias_CategoriaId",
                table: "Materiais",
                column: "CategoriaId",
                principalTable: "TBCategorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Materiais_MaterialId",
                table: "Movimentacoes",
                column: "MaterialId",
                principalTable: "Materiais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materiais_TBCategorias_CategoriaId",
                table: "Materiais");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Materiais_MaterialId",
                table: "Movimentacoes");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "Movimentacoes",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Movimentacoes",
                newName: "DataMovimentacao");

            migrationBuilder.RenameIndex(
                name: "IX_Movimentacoes_MaterialId",
                table: "Movimentacoes",
                newName: "IX_Movimentacoes_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Materiais",
                newName: "categoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Materiais_CategoriaId",
                table: "Materiais",
                newName: "IX_Materiais_categoriaId");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmarSenha",
                table: "Usuarios",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Relatorios",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Movimentacoes",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "MateriaId",
                table: "Movimentacoes",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorios_UsuarioId",
                table: "Relatorios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_MateriaId",
                table: "Movimentacoes",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materiais_TBCategorias_categoriaId",
                table: "Materiais",
                column: "categoriaId",
                principalTable: "TBCategorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Materiais_MateriaId",
                table: "Movimentacoes",
                column: "MateriaId",
                principalTable: "Materiais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Usuarios_UsuarioId",
                table: "Movimentacoes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Relatorios_Usuarios_UsuarioId",
                table: "Relatorios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
