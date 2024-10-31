using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscussionMvcSandreth.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSupervises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supervises",
                columns: table => new
                {
                    SupervisesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SupervisorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervises", x => x.SupervisesId);
                    table.ForeignKey(
                        name: "FK_Supervises_AspNetUsers_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Supervises_AspNetUsers_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supervises_OfficerId",
                table: "Supervises",
                column: "OfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_Supervises_SupervisorId",
                table: "Supervises",
                column: "SupervisorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supervises");
        }
    }
}
