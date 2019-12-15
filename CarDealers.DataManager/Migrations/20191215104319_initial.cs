using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealers.DataManager.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                schema: "Advertisement",
                table: "Advertisement",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Advertisement",
                table: "Advertisement",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                schema: "Advertisement",
                table: "Advertisement",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditOn",
                schema: "Advertisement",
                table: "Advertisement",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EdtedBy",
                schema: "Advertisement",
                table: "Advertisement",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                schema: "Advertisement",
                table: "Advertisement",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Modal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Modal",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Modal",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditOn",
                table: "Modal",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EdtedBy",
                table: "Modal",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "Modal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Location",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Location",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditOn",
                table: "Location",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EdtedBy",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "Location",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Category",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Category",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditOn",
                table: "Category",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EdtedBy",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "Category",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Brand",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Brand",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Brand",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EditOn",
                table: "Brand",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EdtedBy",
                table: "Brand",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "Brand",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                schema: "Advertisement",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Advertisement",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                schema: "Advertisement",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "EditOn",
                schema: "Advertisement",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "EdtedBy",
                schema: "Advertisement",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                schema: "Advertisement",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Modal");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Modal");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Modal");

            migrationBuilder.DropColumn(
                name: "EditOn",
                table: "Modal");

            migrationBuilder.DropColumn(
                name: "EdtedBy",
                table: "Modal");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "Modal");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "EditOn",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "EdtedBy",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "EditOn",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "EdtedBy",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "EditOn",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "EdtedBy",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "Brand");
        }
    }
}
