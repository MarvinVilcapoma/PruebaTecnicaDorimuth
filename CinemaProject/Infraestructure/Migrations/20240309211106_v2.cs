using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Names = table.Column<string>(nullable: true),
                    LastNames = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    DNI = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CinemaRoomID = table.Column<int>(nullable: false),
                    MovieID = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_Reservations_CinemaRooms_CinemaRoomID",
                        column: x => x.CinemaRoomID,
                        principalTable: "CinemaRooms",
                        principalColumn: "CinemaRoomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CinemaRoomID",
                table: "Reservations",
                column: "CinemaRoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MovieID",
                table: "Reservations",
                column: "MovieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
