using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThaiHoaOfficial.Api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsMale = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "Name", "Notification", "Status" },
                values: new object[] { new Guid("2ea9b4dc-60d9-4bde-88af-07c878e9229f"), new DateTime(2021, 8, 29, 22, 10, 58, 233, DateTimeKind.Local).AddTicks(289), "Administrator", null, 3 });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "Name", "Notification", "Status" },
                values: new object[] { new Guid("ec7d11f9-0a8e-4488-90e6-16837a88cdd6"), new DateTime(2021, 8, 29, 22, 10, 58, 233, DateTimeKind.Local).AddTicks(5316), "Phòng CNTT", null, 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DateOfBirth", "DepartmentId", "EmailAddress", "FullName", "IsMale", "PhoneNumber", "Status" },
                values: new object[] { new Guid("fe26dc1a-37da-400e-86cf-49a51dcd1554"), new DateTime(2021, 8, 29, 22, 10, 58, 234, DateTimeKind.Local).AddTicks(9728), new DateTime(1992, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2ea9b4dc-60d9-4bde-88af-07c878e9229f"), "hntduy1992@gmail.com", "Hồ Ngọc Tư Duy", true, "0939433628", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
