using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTestUser.Migrations
{
    /// <inheritdoc />
    public partial class Updatenombretabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Caregorias_idCategoria",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Caregorias",
                table: "Caregorias");

            migrationBuilder.RenameTable(
                name: "Caregorias",
                newName: "Categorias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Categorias_idCategoria",
                table: "Usuarios",
                column: "idCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Categorias_idCategoria",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "Caregorias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Caregorias",
                table: "Caregorias",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Caregorias_idCategoria",
                table: "Usuarios",
                column: "idCategoria",
                principalTable: "Caregorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
