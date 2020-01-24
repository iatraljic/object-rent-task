using Microsoft.EntityFrameworkCore.Migrations;

namespace backTStask.Migrations
{
    public partial class AddBookingBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuestItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Card = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectRentItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectRentItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(nullable: true),
                    BedNumber = table.Column<string>(nullable: true),
                    PersonNumber = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Dodatno = table.Column<string>(nullable: true),
                    ObjectRentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomItems_ObjectRentItems_ObjectRentID",
                        column: x => x.ObjectRentID,
                        principalTable: "ObjectRentItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fromDate = table.Column<string>(nullable: true),
                    toDate = table.Column<string>(nullable: true),
                    GuestID = table.Column<int>(nullable: false),
                    RoomID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationItems_GuestItems_GuestID",
                        column: x => x.GuestID,
                        principalTable: "GuestItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationItems_RoomItems_RoomID",
                        column: x => x.RoomID,
                        principalTable: "RoomItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationItems_GuestID",
                table: "ReservationItems",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationItems_RoomID",
                table: "ReservationItems",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomItems_ObjectRentID",
                table: "RoomItems",
                column: "ObjectRentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationItems");

            migrationBuilder.DropTable(
                name: "GuestItems");

            migrationBuilder.DropTable(
                name: "RoomItems");

            migrationBuilder.DropTable(
                name: "ObjectRentItems");
        }
    }
}
