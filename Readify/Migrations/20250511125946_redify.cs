using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Readify.Migrations
{
    /// <inheritdoc />
    public partial class redify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "585c3e0d-c65a-4fbf-a2c9-35ef81bf8b36", "267d300d-6457-4f86-a428-68a7a0ba0dc9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "585c3e0d-c65a-4fbf-a2c9-35ef81bf8b36");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "267d300d-6457-4f86-a428-68a7a0ba0dc9");

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DiscountPercentage = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    isOnSale = table.Column<bool>(type: "boolean", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da5a81ea-67b3-4e66-9088-2345f5c62c55", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ac7cf42c-faf0-4f8f-836e-0cd0bd197a3c", 0, "8856d4f3-3e19-4611-8295-02dc909cc929", "amoshhamal7@gmail.com", true, false, null, "ADMIN@YOURAPP.COM", "AMOSHHAMAL7@gmail.com", "AQAAAAIAAYagAAAAEO/KdDqeX3/EbYIahMwimo9HJzj3yoQwxwiL0hVbNzN8F3TV+CsBBFo2nqWatbFbIg==", null, false, "16d1cc5b-bca7-4e98-a6c2-adf0c9e6c85c", false, "amoshhamal7@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "da5a81ea-67b3-4e66-9088-2345f5c62c55", "ac7cf42c-faf0-4f8f-836e-0cd0bd197a3c" });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_BookId",
                table: "Discounts",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "da5a81ea-67b3-4e66-9088-2345f5c62c55", "ac7cf42c-faf0-4f8f-836e-0cd0bd197a3c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da5a81ea-67b3-4e66-9088-2345f5c62c55");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac7cf42c-faf0-4f8f-836e-0cd0bd197a3c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "585c3e0d-c65a-4fbf-a2c9-35ef81bf8b36", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "267d300d-6457-4f86-a428-68a7a0ba0dc9", 0, "230a33b0-bc72-46d1-90a0-1fda78a39ace", "amoshhamal7@gmail.com", true, false, null, "ADMIN@YOURAPP.COM", "AMOSHHAMAL7@gmail.com", "AQAAAAIAAYagAAAAEOiSdfKlVs0HiDlUxrC3TyKYtoDtiBlnwpUf9hydWMaRvIHJQR7KL4eL7m2cNk+01w==", null, false, "fc9d626e-1370-46e3-bb11-401356a5f5a0", false, "amoshhamal7@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "585c3e0d-c65a-4fbf-a2c9-35ef81bf8b36", "267d300d-6457-4f86-a428-68a7a0ba0dc9" });
        }
    }
}
