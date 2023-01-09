using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "sigortaPrimiIsverenIndirim",
                table: "PersonelSigortas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "cocukSayisi",
                table: "PersonelKimliks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "hesapNo",
                table: "PersonelBanka",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sigortaPrimiIsverenIndirim",
                table: "PersonelSigortas");

            migrationBuilder.DropColumn(
                name: "cocukSayisi",
                table: "PersonelKimliks");

            migrationBuilder.DropColumn(
                name: "hesapNo",
                table: "PersonelBanka");
        }
    }
}
