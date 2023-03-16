using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomaApp.Data.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.InsertData(
           table: "AspNetRoles",
           columns: new[] {"Id", "Name", "NormalizedName" },
           values: new object[,]
           {
                { "1","Admin", "ADMIN" },
                { "2","Client", "CLIENT" },
                { "3","Company", "COMPANY" },
           });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
