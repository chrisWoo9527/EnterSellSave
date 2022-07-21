using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterSellSave.SqlData.Migrations
{
    /// <inheritdoc />
    public partial class initids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Menu_T_User_LastModifierId",
                table: "T_Menu");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Menu_T_User_LastModifierId",
                table: "T_Menu",
                column: "LastModifierId",
                principalTable: "T_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Menu_T_User_LastModifierId",
                table: "T_Menu");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Menu_T_User_LastModifierId",
                table: "T_Menu",
                column: "LastModifierId",
                principalTable: "T_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
