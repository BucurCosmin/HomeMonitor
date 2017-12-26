using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebMonitor.Data.Migrations
{
    public partial class AddItems3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DeadBand",
                table: "Sensors",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "Logging",
                table: "Sensors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "MaxValue",
                table: "Sensors",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MinValue",
                table: "Sensors",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeadBand",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "Logging",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "MaxValue",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "MinValue",
                table: "Sensors");
        }
    }
}
