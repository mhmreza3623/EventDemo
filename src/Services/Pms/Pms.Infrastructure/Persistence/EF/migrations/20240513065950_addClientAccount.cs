using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pms.Infrastructure.persistence.ef.migrations
{
    /// <inheritdoc />
    public partial class addClientAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "Payment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Ips = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "Payment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DisplayTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Identifier = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "Payment",
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClientId",
                schema: "Payment",
                table: "Accounts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "Ix_identifier",
                schema: "Payment",
                table: "Accounts",
                column: "Identifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "Payment");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "Payment");
        }
    }
}
