using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscussionMvcSandreth.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedServiceRequestStatusToDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceRequestStatus",
                table: "ServiceRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceRequestStatus",
                table: "ServiceRequest");
        }
    }
}
