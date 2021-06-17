using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booklet.DataAccess.Migrations
{
    public partial class tableremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookFormats");

            migrationBuilder.AddColumn<int>(
                name: "FormatId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Books_FormatId",
                table: "Books",
                column: "FormatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Formats_FormatId",
                table: "Books",
                column: "FormatId",
                principalTable: "Formats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Formats_FormatId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_FormatId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "FormatId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "BookFormats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FormatId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookFormats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookFormats_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookFormats_Formats_FormatId",
                        column: x => x.FormatId,
                        principalTable: "Formats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookFormats_BookId",
                table: "BookFormats",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookFormats_FormatId",
                table: "BookFormats",
                column: "FormatId");
        }
    }
}
