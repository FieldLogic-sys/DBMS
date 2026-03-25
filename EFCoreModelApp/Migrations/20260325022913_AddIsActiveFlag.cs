using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreModelApp.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Employees",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Departments",
                newName: "DepartmentId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                columns: new[] { "HireDate", "IsActive" },
                values: new object[] { new DateTime(2026, 3, 24, 22, 29, 12, 586, DateTimeKind.Local).AddTicks(6472), true });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                columns: new[] { "HireDate", "IsActive" },
                values: new object[] { new DateTime(2026, 3, 24, 22, 29, 12, 590, DateTimeKind.Local).AddTicks(3507), true });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Employees",
                newName: "DepartmentID");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_DepartmentID");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Departments",
                newName: "DepartmentID");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2026, 3, 24, 19, 49, 36, 689, DateTimeKind.Local).AddTicks(5054));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2026, 3, 24, 19, 49, 36, 691, DateTimeKind.Local).AddTicks(1676));

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentID",
                table: "Employees",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
