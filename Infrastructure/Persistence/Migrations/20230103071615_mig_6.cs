using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonelResim_Personels_Id",
                table: "PersonelResim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonelResim",
                table: "PersonelResim");

            migrationBuilder.RenameTable(
                name: "PersonelResim",
                newName: "PersonelResims");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonelResims",
                table: "PersonelResims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelResims_Personels_Id",
                table: "PersonelResims",
                column: "Id",
                principalTable: "Personels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonelResims_Personels_Id",
                table: "PersonelResims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonelResims",
                table: "PersonelResims");

            migrationBuilder.RenameTable(
                name: "PersonelResims",
                newName: "PersonelResim");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonelResim",
                table: "PersonelResim",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelResim_Personels_Id",
                table: "PersonelResim",
                column: "Id",
                principalTable: "Personels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
