using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomaApp.Data.Migrations
{
    public partial class prices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceValue = table.Column<double>(type: "float", nullable: false),
                    Element = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                });


           migrationBuilder.InsertData(
           table: "Price",
           columns: new[] { "PriceValue", "Element"},
           values: new object[,]
           {
                 { "21.80","PVC"},
                 { "25","Allu"},
                 { "40","Wood"},
                 { "1","Two"},
                 { "1.25","Three"},
                 { "1.50","Four"},
                 { "1.60","Five"},
                 { "1.70","Six"},
                 { "33.60","DoubleWin"},
                 { "40","TripleWin"},
                 { "15","None"},
           });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Price");
        }
    }
}
