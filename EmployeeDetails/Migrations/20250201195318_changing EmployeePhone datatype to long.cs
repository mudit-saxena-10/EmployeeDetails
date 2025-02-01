using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeDetails.Migrations
{
    /// <inheritdoc />
    public partial class changingEmployeePhonedatatypetolong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "EmployeePhone",
                table: "tblEmployee",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EmployeePhone",
                table: "tblEmployee",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
