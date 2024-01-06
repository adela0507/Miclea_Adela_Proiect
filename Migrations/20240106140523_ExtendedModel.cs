using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Miclea_Adela_Proiect.Migrations
{
    public partial class ExtendedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BrandProducer",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandProducer", x => new { x.ProductID, x.BrandID });
                    table.ForeignKey(
                        name: "FK_BrandProducer_Brand_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brand",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandProducer_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandProducer_BrandID",
                table: "BrandProducer",
                column: "BrandID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandProducer");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
