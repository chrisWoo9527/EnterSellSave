using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterSellSave.SqlData.Migrations
{
    /// <inheritdoc />
    public partial class addmenuxh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SerialNumber",
                table: "T_Menu",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "T_Menu");
        }
    }
}
