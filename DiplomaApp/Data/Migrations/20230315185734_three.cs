using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomaApp.Data.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlassPaneParent_AspNetUsers_UserId",
                table: "GlassPaneParent");

            migrationBuilder.DropForeignKey(
                name: "FK_Wing_GlassPaneParent_ContragentID",
                table: "Wing");

            migrationBuilder.DropIndex(
                name: "IX_Wing_ContragentID",
                table: "Wing");

            migrationBuilder.DropColumn(
                name: "ContragentID",
                table: "Wing");

            migrationBuilder.AlterColumn<string>(
                name: "PPDType",
                table: "PPD",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GlassPaneParent",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Wing_GlassPaneId",
                table: "Wing",
                column: "GlassPaneId");

            migrationBuilder.AddForeignKey(
                name: "FK_GlassPaneParent_AspNetUsers_UserId",
                table: "GlassPaneParent",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wing_GlassPaneParent_GlassPaneId",
                table: "Wing",
                column: "GlassPaneId",
                principalTable: "GlassPaneParent",
                principalColumn: "GlassPaneId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlassPaneParent_AspNetUsers_UserId",
                table: "GlassPaneParent");

            migrationBuilder.DropForeignKey(
                name: "FK_Wing_GlassPaneParent_GlassPaneId",
                table: "Wing");

            migrationBuilder.DropIndex(
                name: "IX_Wing_GlassPaneId",
                table: "Wing");

            migrationBuilder.AddColumn<int>(
                name: "ContragentID",
                table: "Wing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PPDType",
                table: "PPD",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GlassPaneParent",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wing_ContragentID",
                table: "Wing",
                column: "ContragentID");

            migrationBuilder.AddForeignKey(
                name: "FK_GlassPaneParent_AspNetUsers_UserId",
                table: "GlassPaneParent",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wing_GlassPaneParent_ContragentID",
                table: "Wing",
                column: "ContragentID",
                principalTable: "GlassPaneParent",
                principalColumn: "GlassPaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
