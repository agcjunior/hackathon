using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VirtualRunner.Migrations
{
    public partial class inclusao_referencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Referencia",
                table: "RegistrosRunners");

            migrationBuilder.AddColumn<string>(
                name: "Referencia",
                table: "Doacoes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Referencia",
                table: "Doacoes");

            migrationBuilder.AddColumn<string>(
                name: "Referencia",
                table: "RegistrosRunners",
                nullable: true);
        }
    }
}
