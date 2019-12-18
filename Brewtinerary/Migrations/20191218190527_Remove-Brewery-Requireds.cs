using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class RemoveBreweryRequireds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Breweries",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-fffffffff123",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6ee66c45-2cc7-4d13-bb98-e92d875b8b6b", "AQAAAAEAACcQAAAAEJWGe7Ox2HS58nt/pjioVhtu5lpQ3t4JeVJkcwcNcAkOGoDWC14VTp9mgznxca63cw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c89ab8c8-41bd-45a5-b6b2-1b80f2433db7", "AQAAAAEAACcQAAAAEAN2uMVxOI7KD12vCYobrM/6DzjTNe2TEPiQlKGcqP0dAjQnghxLNkKVBknyWyla+A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Breweries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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
        }
    }
}
