using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceWeb.Identity.Migrations
{
    public partial class IdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6087 - 1fbf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c512c0e-4591-4e40-ac78-0bad9f9a7afe", "AQAAAAIAAYagAAAAENxVL511MBiYQbI338ZHIKXLezXh0oTDocc/8jdvV/G5zcP6oFHe7Ml9CORksrhQDw==", "62209e6e-8b2f-4ae0-8a9d-1cf5eb5052a6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6088 - 1fcf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32e12a01-d58f-44fb-aba9-ccd86b0e6a2a", "AQAAAAIAAYagAAAAEDMeRjuFQoeW8As/MtNLAecWV387KXHovmQ43EpOyB9w3QuFNIrOKLFQVQhnNX0WaA==", "aa4b0e67-ec0c-4d69-9565-8d288796895c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6087 - 1fbf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "666e5771-457e-437b-a1d1-011e9b081493", "AQAAAAIAAYagAAAAEL7/VZHMWLBhi6AmPX148GrDnvpnFCv9OIoN9N/7fT/wm/wwzouIZegXaV7bwrZVPQ==", "06473ee0-fd8a-4a5b-a3a0-b4fb98936fc4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6088 - 1fcf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f981453b-8055-4b11-8b08-d939cf0ed658", "AQAAAAIAAYagAAAAEOWH3mmgJZGkUD4c0C66U3X3XGGICHnNobsjS2u2Cgwwm7KfBZfJ3zKeYnIMhtJ7zA==", "436a3b00-e9fd-453d-80a1-3ac7cfde3ef9" });
        }
    }
}
