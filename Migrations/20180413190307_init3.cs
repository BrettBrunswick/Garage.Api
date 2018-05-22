using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Garage.Api.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "ParkingSpaces",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpaces_ManagerId",
                table: "ParkingSpaces",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpaces_AspNetUsers_ManagerId",
                table: "ParkingSpaces",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpaces_AspNetUsers_ManagerId",
                table: "ParkingSpaces");

            migrationBuilder.DropIndex(
                name: "IX_ParkingSpaces_ManagerId",
                table: "ParkingSpaces");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "ParkingSpaces");
        }
    }
}
