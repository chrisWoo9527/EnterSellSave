using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterSellSave.SqlData.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Menu_T_Role_ParentId",
                table: "T_Menu");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Menu_T_Menu_ParentId",
                table: "T_Menu",
                column: "ParentId",
                principalTable: "T_Menu",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_Menu_T_Menu_ParentId",
                table: "T_Menu");

            migrationBuilder.AddForeignKey(
                name: "FK_T_Menu_T_Role_ParentId",
                table: "T_Menu",
                column: "ParentId",
                principalTable: "T_Role",
                principalColumn: "Id");
        }
    }
}
