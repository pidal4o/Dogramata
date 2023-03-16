using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomaApp.Data.Migrations
{
    public partial class Values : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Values",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false),
                Value = table.Column<string>(nullable: true),
                Element = table.Column<string>(nullable: true), 
                Key = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MyTable", x => x.Id);
            });


            migrationBuilder.InsertData(
           table: "ValuesForProfile",
           columns: new[] { "Id", "Element", "Price", "Key"},
           values: new object[,]
           {
                { "1","PVC", "10","1" },
                { "2","Allu", "20","2" },
                { "3","Wood", "30" , "3"},
           });

            migrationBuilder.InsertData(
            table: "ValuesForGlassPane",
            columns: new[] { "Id", "Element", "Price","Key" },
            values: new object[,]
            {
                { "1","Two", "10" , "1"},
                { "2","Three", "20" , "2"},
                { "3","Four", "30" , "3"},
                {"4","Five","40" , "4"},
                {"5","Six","50" , "5"}
            });

            migrationBuilder.InsertData(
           table: "ValuesForWindowType",
           columns: new[] { "Id", "Element", "Price", "Key" },
           values: new object[,]
           {
                { "1","DoubleWin", "20","1" },
                { "2","TripleWin", "30","2" },
                { "3","None", "10","3" },
           });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
             name: "Values");
        }
    }
}
