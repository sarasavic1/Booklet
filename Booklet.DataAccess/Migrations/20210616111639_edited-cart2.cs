using Microsoft.EntityFrameworkCore.Migrations;

namespace Booklet.DataAccess.Migrations
{
    public partial class editedcart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderedConfirmed",
                table: "Cart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OrderedConfirmed",
                table: "Cart",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
