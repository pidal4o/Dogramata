using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomaApp.Data.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlassPaneParent",
                columns: table => new
                {
                    GlassPaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileType = table.Column<int>(type: "int", nullable: false),
                    ProfileTypeMaterial = table.Column<int>(type: "int", nullable: false),
                    WindowType = table.Column<int>(type: "int", nullable: false),
                    WingsCount = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Hight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlassPaneParent", x => x.GlassPaneId);
                    table.ForeignKey(
                        name: "FK_GlassPaneParent_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wing",
                columns: table => new
                {
                    WingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    IsCombined = table.Column<bool>(type: "bit", nullable: false),
                    OpenDirection = table.Column<int>(type: "int", nullable: true),
                    GlassPaneId = table.Column<int>(type: "int", nullable: false),
                    ContragentID = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Hight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wing", x => x.WingId);
                    table.ForeignKey(
                        name: "FK_Wing_GlassPaneParent_ContragentID",
                        column: x => x.ContragentID,
                        principalTable: "GlassPaneParent",
                        principalColumn: "GlassPaneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlassPaneParent_UserId",
                table: "GlassPaneParent",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wing_ContragentID",
                table: "Wing",
                column: "ContragentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wing");

            migrationBuilder.DropTable(
                name: "GlassPaneParent");
        }
    }
}
