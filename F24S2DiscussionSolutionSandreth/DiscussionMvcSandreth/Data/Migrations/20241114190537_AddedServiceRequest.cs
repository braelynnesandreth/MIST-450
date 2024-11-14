using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscussionMvcSandreth.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedServiceRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceRequest",
                columns: table => new
                {
                    ServiceRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRequestMade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfficerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    SupervisorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ServiceRequestDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequest", x => x.ServiceRequestId);
                    table.ForeignKey(
                        name: "FK_ServiceRequest_AspNetUsers_OfficerId",
                        column: x => x.OfficerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceRequest_AspNetUsers_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceRequest_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_OfficerId",
                table: "ServiceRequest",
                column: "OfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_SupervisorId",
                table: "ServiceRequest",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_VehicleId",
                table: "ServiceRequest",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceRequest");
        }
    }
}
