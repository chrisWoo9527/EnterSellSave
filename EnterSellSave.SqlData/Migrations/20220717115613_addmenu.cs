using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterSellSave.SqlData.Migrations
{
    /// <inheritdoc />
    public partial class addmenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Menu",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NamespaceClassName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<long>(type: "bigint", nullable: true),
                    LastModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Menu_T_Role_ParentId",
                        column: x => x.ParentId,
                        principalTable: "T_Role",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_T_Menu_T_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "T_User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_T_Menu_T_User_LastModifierId",
                        column: x => x.LastModifierId,
                        principalTable: "T_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Menu_CreatorId",
                table: "T_Menu",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Menu_Index",
                table: "T_Menu",
                column: "Index");

            migrationBuilder.CreateIndex(
                name: "IX_T_Menu_LastModifierId",
                table: "T_Menu",
                column: "LastModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Menu_ParentId",
                table: "T_Menu",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Menu");
        }
    }
}
