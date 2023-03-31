using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackingAppReact.Migrations
{
    public partial class migration310323 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inbox",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingNumber = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    Handling = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    Delay = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    DispatchNote = table.Column<string>(type: "nvarchar(40)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inbox", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderChange",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackingNumber = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    ContainerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderChange", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inbox");

            migrationBuilder.DropTable(
                name: "OrderChange");
        }
    }
}
