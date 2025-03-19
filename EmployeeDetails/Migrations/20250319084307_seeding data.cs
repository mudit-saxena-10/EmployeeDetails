using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeDetails.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tblDepartment",
                columns: new[] { "DepartmentId", "CreationDate", "DepartmentName", "Description", "LastUpdateDate", "Status" },
                values: new object[] { 100, new DateTime(2025, 3, 19, 12, 22, 50, 78, DateTimeKind.Local).AddTicks(1817), "Default_Department", "Unassigned Department or default department", new DateTime(2025, 3, 19, 12, 22, 50, 78, DateTimeKind.Local).AddTicks(1817), true });

            migrationBuilder.InsertData(
                table: "tblSystemConfig",
                columns: new[] { "id", "DefaultDepartment", "EmployeeDeletion" },
                values: new object[] { 100, true, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblDepartment",
                keyColumn: "DepartmentId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "tblSystemConfig",
                keyColumn: "id",
                keyValue: 100);

        }
    }
}
