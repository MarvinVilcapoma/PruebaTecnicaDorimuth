using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestructure.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "varchar(200)", nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictID);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    MovieGenreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieGenreName = table.Column<string>(type: "varchar(max)", nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => x.MovieGenreID);
                });

            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    CinemaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaName = table.Column<string>(nullable: true),
                    DistrictID = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinemas", x => x.CinemaID);
                    table.ForeignKey(
                        name: "FK_Cinemas_Districts_DistrictID",
                        column: x => x.DistrictID,
                        principalTable: "Districts",
                        principalColumn: "DistrictID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "varchar(max)", nullable: true),
                    MovieGenreID = table.Column<int>(nullable: false),
                    Synopsis = table.Column<string>(type: "varchar(max)", nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    ImgURLOrBase64 = table.Column<string>(type: "varchar(max)", nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieID);
                    table.ForeignKey(
                        name: "FK_Movies_MovieGenres_MovieGenreID",
                        column: x => x.MovieGenreID,
                        principalTable: "MovieGenres",
                        principalColumn: "MovieGenreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CinemaRooms",
                columns: table => new
                {
                    CinemaRoomID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaRoomName = table.Column<string>(type: "varchar(200)", nullable: true),
                    Capacity = table.Column<int>(nullable: false),
                    CinemaID = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaRooms", x => x.CinemaRoomID);
                    table.ForeignKey(
                        name: "FK_CinemaRooms_Cinemas_CinemaID",
                        column: x => x.CinemaID,
                        principalTable: "Cinemas",
                        principalColumn: "CinemaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CinemaRoomDetails",
                columns: table => new
                {
                    CinemaRoomDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketsAvailable = table.Column<int>(nullable: false),
                    CinemaRoomID = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaRoomDetails", x => x.CinemaRoomDetailID);
                    table.ForeignKey(
                        name: "FK_CinemaRoomDetails_CinemaRooms_CinemaRoomID",
                        column: x => x.CinemaRoomID,
                        principalTable: "CinemaRooms",
                        principalColumn: "CinemaRoomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screenings",
                columns: table => new
                {
                    ScreeningID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieID = table.Column<int>(nullable: false),
                    CinemaRoomID = table.Column<int>(nullable: false),
                    StartDateScreening = table.Column<DateTime>(nullable: true),
                    EndDateScreening = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Enabled = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenings", x => x.ScreeningID);
                    table.ForeignKey(
                        name: "FK_Screenings_CinemaRooms_CinemaRoomID",
                        column: x => x.CinemaRoomID,
                        principalTable: "CinemaRooms",
                        principalColumn: "CinemaRoomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Screenings_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaRoomDetails_CinemaRoomID",
                table: "CinemaRoomDetails",
                column: "CinemaRoomID");

            migrationBuilder.CreateIndex(
                name: "IX_CinemaRooms_CinemaID",
                table: "CinemaRooms",
                column: "CinemaID");

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_DistrictID",
                table: "Cinemas",
                column: "DistrictID");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieGenreID",
                table: "Movies",
                column: "MovieGenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_CinemaRoomID",
                table: "Screenings",
                column: "CinemaRoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_MovieID",
                table: "Screenings",
                column: "MovieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaRoomDetails");

            migrationBuilder.DropTable(
                name: "Screenings");

            migrationBuilder.DropTable(
                name: "CinemaRooms");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Cinemas");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "Districts");
        }
    }
}
