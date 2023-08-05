using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class distance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "dist",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dist",
                table: "Customers");
        }
    }
}
