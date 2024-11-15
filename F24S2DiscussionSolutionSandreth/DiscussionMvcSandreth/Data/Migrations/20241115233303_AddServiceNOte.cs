using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiscussionMvcSandreth.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceNOte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceNote",
                columns: table => new
                {
                    ServiceNoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceNoteDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceNoteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceRequestId = table.Column<int>(type: "int", nullable: false),
                    ServiceNoteRespondedToServiceNoteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceNote", x => x.ServiceNoteId);
                    table.ForeignKey(
                        name: "FK_ServiceNote_ServiceNote_ServiceNoteRespondedToServiceNoteId",
                        column: x => x.ServiceNoteRespondedToServiceNoteId,
                        principalTable: "ServiceNote",
                        principalColumn: "ServiceNoteId");
                    table.ForeignKey(
                        name: "FK_ServiceNote_ServiceRequest_ServiceRequestId",
                        column: x => x.ServiceRequestId,
                        principalTable: "ServiceRequest",
                        principalColumn: "ServiceRequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceNote_ServiceNoteRespondedToServiceNoteId",
                table: "ServiceNote",
                column: "ServiceNoteRespondedToServiceNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceNote_ServiceRequestId",
                table: "ServiceNote",
                column: "ServiceRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceNote");
        }
    }
}
