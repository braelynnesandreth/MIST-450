using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscussionMvcSandreth.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSupervises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supervises_AspNetUsers_OfficerId",
                table: "Supervises");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervises_AspNetUsers_SupervisorId",
                table: "Supervises");

            migrationBuilder.AlterColumn<string>(
                name: "SupervisorId",
                table: "Supervises",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OfficerId",
                table: "Supervises",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervises_AspNetUsers_OfficerId",
                table: "Supervises",
                column: "OfficerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Supervises_AspNetUsers_SupervisorId",
                table: "Supervises",
                column: "SupervisorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supervises_AspNetUsers_OfficerId",
                table: "Supervises");

            migrationBuilder.DropForeignKey(
                name: "FK_Supervises_AspNetUsers_SupervisorId",
                table: "Supervises");

            migrationBuilder.AlterColumn<string>(
                name: "SupervisorId",
                table: "Supervises",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "OfficerId",
                table: "Supervises",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Supervises_AspNetUsers_OfficerId",
                table: "Supervises",
                column: "OfficerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Supervises_AspNetUsers_SupervisorId",
                table: "Supervises",
                column: "SupervisorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
