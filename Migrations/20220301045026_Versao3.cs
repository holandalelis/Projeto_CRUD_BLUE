using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAgenda.Migrations
{
    public partial class Versao3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Grupo_grupoIdGrupo",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_grupoIdGrupo",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "grupoIdGrupo",
                table: "Usuario");

            migrationBuilder.AlterColumn<int>(
                name: "IdGrupo",
                table: "Usuario",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdGrupo",
                table: "Usuario",
                column: "IdGrupo");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Grupo_IdGrupo",
                table: "Usuario",
                column: "IdGrupo",
                principalTable: "Grupo",
                principalColumn: "IdGrupo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Grupo_IdGrupo",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdGrupo",
                table: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "IdGrupo",
                table: "Usuario",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "grupoIdGrupo",
                table: "Usuario",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_grupoIdGrupo",
                table: "Usuario",
                column: "grupoIdGrupo");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Grupo_grupoIdGrupo",
                table: "Usuario",
                column: "grupoIdGrupo",
                principalTable: "Grupo",
                principalColumn: "IdGrupo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
