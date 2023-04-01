using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Startup.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompleteAddress",
                columns: table => new
                {
                    Pincode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DetailedAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompleteAddress", x => x.Pincode);
                });

            migrationBuilder.CreateTable(
                name: "TrainingCenters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenterName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CenterCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressPincode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentCapacity = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCenters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TrainingCenters_CompleteAddress_AddressPincode",
                        column: x => x.AddressPincode,
                        principalTable: "CompleteAddress",
                        principalColumn: "Pincode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCenters_AddressPincode",
                table: "TrainingCenters",
                column: "AddressPincode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingCenters");

            migrationBuilder.DropTable(
                name: "CompleteAddress");
        }
    }
}
