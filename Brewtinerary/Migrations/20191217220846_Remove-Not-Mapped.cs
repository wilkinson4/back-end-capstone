using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class RemoveNotMapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_ApplicationUserId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ApplicationUserId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Reviews");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ItineraryBreweryViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItineraryId = table.Column<int>(nullable: false),
                    BreweryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItineraryBreweryViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItineraryBreweryViewModel_Breweries_BreweryId",
                        column: x => x.BreweryId,
                        principalTable: "Breweries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItineraryBreweryViewModel_Itineraries_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "Itineraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-fffffffff123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "302f8138-69e9-47f9-8b74-3ed3c881a751", "AQAAAAEAACcQAAAAEG4d7Jb/fNaXHNFL2j4A9xbWAuKxKWi/XuVcAPUece8N6CBSbu3poL+kN5MaT7Jl+w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "285b01b9-4324-450c-9993-754ac58a5224", "AQAAAAEAACcQAAAAEHVKJDEncsI2+r+U5VRO69Z2YUOoVpxhuqk1KKO/iHpHQ6mxSMndyt+MyBYiAdsbMA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryBreweries_BreweryId",
                table: "ItineraryBreweries",
                column: "BreweryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ItineraryId",
                table: "Comments",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryBreweryViewModel_BreweryId",
                table: "ItineraryBreweryViewModel",
                column: "BreweryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryBreweryViewModel_ItineraryId",
                table: "ItineraryBreweryViewModel",
                column: "ItineraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Itineraries_ItineraryId",
                table: "Comments",
                column: "ItineraryId",
                principalTable: "Itineraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItineraryBreweries_Breweries_BreweryId",
                table: "ItineraryBreweries",
                column: "BreweryId",
                principalTable: "Breweries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Itineraries_ItineraryId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_ItineraryBreweries_Breweries_BreweryId",
                table: "ItineraryBreweries");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_UserId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "ItineraryBreweryViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_ItineraryBreweries_BreweryId",
                table: "ItineraryBreweries");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ItineraryId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-fffffffff123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a9a86a2e-86c9-4bf3-9ca2-6e5a2000ae00", "AQAAAAEAACcQAAAAEIf02InSFbRAIGTGauXpICnn8Q59QEFqkcrGxGmGqc0Vo19sB0Z9VVgf5Ll+Li10Sw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "018521f0-bbeb-486f-b7fb-31f643f54127", "AQAAAAEAACcQAAAAEPzise70A5/H4OjqGP6UET15gOyP2EODf+0KHZX4lOdzdhT/otwzpLrm3L0iKVy4aQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ApplicationUserId",
                table: "Reviews",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ApplicationUserId",
                table: "Reviews",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
