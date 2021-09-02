using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThaiHoaOfficial.Api.Migrations
{
    public partial class removeLoginMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c2ee9aad-279a-435d-afed-0bb732f23998"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0a58e194-0cb4-4838-83a3-f728253f4494"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("0cf4de41-bd00-4baa-ab4c-eb87309eeb76"));

            migrationBuilder.DropColumn(
                name: "LoginMode",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "Name", "Notification", "Status" },
                values: new object[] { new Guid("d0ea1209-c1df-45cc-b713-9797d6e997d4"), new DateTime(2021, 9, 1, 22, 34, 15, 471, DateTimeKind.Local).AddTicks(4814), "Administrator", null, 3 });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "Name", "Notification", "Status" },
                values: new object[] { new Guid("afa7a04c-77d7-4782-b178-8ba44111ddf9"), new DateTime(2021, 9, 1, 22, 34, 15, 471, DateTimeKind.Local).AddTicks(9065), "Phòng CNTT", null, 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DateOfBirth", "DepartmentId", "EmailAddress", "FullName", "IsMale", "Password", "PhoneNumber", "Status" },
                values: new object[] { new Guid("f89735cf-6b3b-4054-a961-cc88ecae0146"), new DateTime(2021, 9, 1, 22, 34, 15, 473, DateTimeKind.Local).AddTicks(2743), new DateTime(1992, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d0ea1209-c1df-45cc-b713-9797d6e997d4"), "hntduy1992@gmail.com", "Hồ Ngọc Tư Duy", true, "", "0939433628", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("afa7a04c-77d7-4782-b178-8ba44111ddf9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f89735cf-6b3b-4054-a961-cc88ecae0146"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("d0ea1209-c1df-45cc-b713-9797d6e997d4"));

            migrationBuilder.AddColumn<int>(
                name: "LoginMode",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
