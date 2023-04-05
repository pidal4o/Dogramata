using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomaApp.Data.Migrations
{
    public partial class eight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Catalog",
            columns: new[] { "Name", "Price", "ImageUrl" },
            values: new object[,]
            {
                   { "PVC","21,80","images/PVC.png"},
                   { "Allu","25","images/Allu.png"},
                   { "Wood","45","images/Wood.png"},



            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
