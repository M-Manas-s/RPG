﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPG.Migrations
{
    /// <inheritdoc />
    public partial class FightProperties2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Defeats",
                table: "Characters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fights",
                table: "Characters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Victories",
                table: "Characters",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Defeats",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Fights",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Victories",
                table: "Characters");
        }
    }
}
