using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miclea_Adela_Proiect.Migrations
{
    public partial class Producer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Producer",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProducerID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProducerID1",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    ProducerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProducerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProducerCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.ProducerID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProducerID1",
                table: "Product",
                column: "ProducerID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Producer_ProducerID1",
                table: "Product",
                column: "ProducerID1",
                principalTable: "Producer",
                principalColumn: "ProducerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Producer_ProducerID1",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProducerID1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProducerID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProducerID1",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Producer",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
