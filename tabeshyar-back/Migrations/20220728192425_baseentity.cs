using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tabeshyar_back.Migrations
{
    public partial class baseentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Read",
                table: "SmsInboxes");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "SmsOutboxes",
                newName: "RemoveDate");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "SmsInboxes",
                newName: "RemoveDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "SmsOutboxes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "SmsOutboxes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Read",
                table: "SmsOutboxes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "SmsInboxes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "SmsInboxes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "SmsInboxes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "LatteryCodes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyDate",
                table: "LatteryCodes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveDate",
                table: "LatteryCodes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "SmsOutboxes");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "SmsOutboxes");

            migrationBuilder.DropColumn(
                name: "Read",
                table: "SmsOutboxes");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "SmsInboxes");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "SmsInboxes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SmsInboxes");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "LatteryCodes");

            migrationBuilder.DropColumn(
                name: "ModifyDate",
                table: "LatteryCodes");

            migrationBuilder.DropColumn(
                name: "RemoveDate",
                table: "LatteryCodes");

            migrationBuilder.RenameColumn(
                name: "RemoveDate",
                table: "SmsOutboxes",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "RemoveDate",
                table: "SmsInboxes",
                newName: "CreateAt");

            migrationBuilder.AddColumn<bool>(
                name: "Read",
                table: "SmsInboxes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
