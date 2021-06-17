using Microsoft.EntityFrameworkCore.Migrations;

namespace Booklet.DataAccess.Migrations
{
    public partial class editedcart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OrderedConfirmed",
                table: "Cart",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderedConfirmed",
                table: "Cart");
        }
    }
}
