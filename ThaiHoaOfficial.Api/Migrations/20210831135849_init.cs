using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThaiHoaOfficial.Api.Migrations
{
    public partial class init : Migration
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
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginMode = table.Column<int>(type: "int", nullable: false),
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
                values: new object[] { new Guid("0cf4de41-bd00-4baa-ab4c-eb87309eeb76"), new DateTime(2021, 8, 31, 20, 58, 48, 764, DateTimeKind.Local).AddTicks(2102), "Administrator", null, 3 });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "Name", "Notification", "Status" },
                values: new object[] { new Guid("c2ee9aad-279a-435d-afed-0bb732f23998"), new DateTime(2021, 8, 31, 20, 58, 48, 764, DateTimeKind.Local).AddTicks(6587), "Phòng CNTT", null, 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DateOfBirth", "DepartmentId", "EmailAddress", "FullName", "IsMale", "LoginMode", "Password", "PhoneNumber", "Status" },
                values: new object[] { new Guid("0a58e194-0cb4-4838-83a3-f728253f4494"), new DateTime(2021, 8, 31, 20, 58, 48, 766, DateTimeKind.Local).AddTicks(573), new DateTime(1992, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0cf4de41-bd00-4baa-ab4c-eb87309eeb76"), "hntduy1992@gmail.com", "Hồ Ngọc Tư Duy", true, 1, "", "0939433628", 1 });

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
